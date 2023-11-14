using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Permissions;
using Porcupine.Robert.Mrobo.Portal.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Groups.Pages;

public partial class GroupsPage
{
    [Inject]
    private HttpClient Http { get; set; } = null!;
    
    private List<Group>? _groups;
    private List<GroupUsersCount>? _groupUsersCount = new();
    private SelectablePermission[]? _selectablePermissions = Array.Empty<SelectablePermission>();
    
    private CreateOrEditGroupModel _createOrEditGroupModel = new();
    
    protected override async Task OnInitializedAsync()
    {
        _groups = await Http.GetFromJsonAsync<List<Group>>("groups");
        _groupUsersCount = await Http.GetFromJsonAsync<List<GroupUsersCount>>("groups/users/count");
        var permissions = await Http.GetFromJsonAsync<Permission[]>("permissions");
        
        _selectablePermissions = permissions?.Select(x => new SelectablePermission
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Selected = false
        }).ToArray();
        
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
        await Http.PostAsJsonAsync("groups", _createOrEditGroupModel);
        _groups = await Http.GetFromJsonAsync<List<Group>>("groups");
        _groupUsersCount = await Http.GetFromJsonAsync<List<GroupUsersCount>>("groups/users/count");
        
        _createOrEditGroupModel = new();
        _selectablePermissions = _selectablePermissions?
            .Select(x => x with { Selected = false })
            .ToArray();
    }

    private async Task Delete(Group group)
    {
        var response = await Http.DeleteAsync($"groups/{group.Id}");
        if (response.IsSuccessStatusCode && _groups is not null)
        {
            _groups = _groups.Where(g => g.Id != group.Id).ToList();
            _groupUsersCount = await Http.GetFromJsonAsync<List<GroupUsersCount>>("groups/users/count");
        }
    }
}