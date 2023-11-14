using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Permissions;
using Porcupine.Robert.Mrobo.Portal.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Groups.Pages;

public partial class EditGroupPage : ComponentBase
{
    [Parameter] public string Id { get; set; } = string.Empty;
    
    [Inject] private HttpClient Http { get; set; } = null!;
    
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    
    private CreateOrEditGroupModel _createOrEditGroupModel = new();
    
    private SelectablePermission[]? _selectablePermissions = Array.Empty<SelectablePermission>();

    protected override async Task OnInitializedAsync()
    {
        var permissions = await Http.GetFromJsonAsync<Permission[]>("permissions");
        
        _selectablePermissions = permissions?.Select(x => new SelectablePermission
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Selected = false
        }).ToArray();
        
        if (string.IsNullOrEmpty(Id))
        {
            return;
        }
        
        var group = await Http.GetFromJsonAsync<Group>($"groups/{Id}");

        if (group is not null)
        {
            _createOrEditGroupModel = new CreateOrEditGroupModel
            {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                Permissions = group.Permissions.Select(x => x.Id)
            };
            
            //Mark the permissions that the group has as selected
            foreach (var permission in _selectablePermissions ?? Array.Empty<SelectablePermission>())
            {
                if (_createOrEditGroupModel.Permissions.Contains(permission.Id))
                {
                    permission.Selected = true;
                }
            }
        }
        
        StateHasChanged();
    }
    
    private async Task OnSubmit()
    {
        _createOrEditGroupModel = _createOrEditGroupModel with
        {
            Permissions = _selectablePermissions?
                .Where(x => x.Selected)
                .Select(x => x.Id)
                .ToList() ?? new List<int>()
        };
        
        await Http.PutAsJsonAsync($"groups/{Id}", _createOrEditGroupModel);
        NavigationManager.NavigateTo("/groups");
    }
}