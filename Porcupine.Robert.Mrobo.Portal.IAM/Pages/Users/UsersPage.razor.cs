using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Groups.Pages;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Pages.Users;

public partial class UsersPage
{
    [Inject]
    private HttpClient Http { get; set; } = null!;
    
    [Inject]
    private ExampleJsInterop ExampleJsInterop { get; set; } = null!;
    
    private List<User>? _users;
    private SelectableGroup[]? _selectableGroups = Array.Empty<SelectableGroup>();
    
    private CreateOrEditUserModel _createOrEditUserModel = new();
    
    protected override async Task OnInitializedAsync()
    {
        _users = await Http.GetFromJsonAsync<List<User>>("users");
        var groups = await Http.GetFromJsonAsync<Group[]>("groups");
        
        _selectableGroups = groups?.Select(x => new SelectableGroup
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
        _createOrEditUserModel = _createOrEditUserModel with
        {
            Groups = _selectableGroups?
                .Where(x => x.Selected)
                .Select(x => x.Id)
                .ToList() ?? new List<int>()
        };
        
        await Http.PostAsJsonAsync("users", _createOrEditUserModel);
        _users = await Http.GetFromJsonAsync<List<User>>("users");
        
        _createOrEditUserModel = new ();
        _selectableGroups = _selectableGroups?
            .Select(x => x with { Selected = false })
            .ToArray();
    }

    private async Task Delete(User user)
    {
        var response = await Http.DeleteAsync($"users/{user.Id}");
        if (response.IsSuccessStatusCode && _users is not null)
        {
            _users = _users.Where(u => u.Id != user.Id).ToList();
        }
    }
}