using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Pages;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Users.Pages;

public partial class EditUserPage : ComponentBase
{
    [Parameter] public string Id { get; set; } = string.Empty;
    
    [Inject] private HttpClient Http { get; set; } = null!;
    
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    
    private CreateOrEditUserModel _createOrEditUserModel = new();
    private SelectableGroup[]? _selectableGroups = Array.Empty<SelectableGroup>();

    protected override async Task OnInitializedAsync()
    {
        var groups = await Http.GetFromJsonAsync<Group[]>("groups");
        
        _selectableGroups = groups?.Select(x => new SelectableGroup
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
        
        var user = await Http.GetFromJsonAsync<User>($"users/{Id}");

        if (user is not null)
        {
            _createOrEditUserModel = new CreateOrEditUserModel
            {
                Id = user.Id,
                Name = user.Name,
                ProfileImage = user.ProfileImage,
                Groups = user.Groups.Select(x => x.Id)
            };
            
            //Mark the groups that the user is a member of as selected
            foreach (var group in _selectableGroups ?? Array.Empty<SelectableGroup>())
            {
                if (_createOrEditUserModel.Groups.Contains(group.Id))
                {
                    group.Selected = true;
                }
            }
        }
        
        StateHasChanged();
    }
    
    private async Task OnSubmit()
    {
        _createOrEditUserModel = _createOrEditUserModel with
        {
            Groups = _selectableGroups?
                .Where(x => x.Selected)
                .Select(x => x.Id)
                .ToList() ?? new List<int>()
        };
        
        await Http.PutAsJsonAsync($"users/{_createOrEditUserModel.Id}", _createOrEditUserModel);
        
        NavigationManager.NavigateTo("/users");
    }
}