using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Pages.Users;

public partial class UsersPage
{
    [Inject]
    private HttpClient Http { get; set; } = null!;
    
    [Inject]
    private ExampleJsInterop ExampleJsInterop { get; set; } = null!;
    
    private User[]? _users = Array.Empty<User>();
    //private Group[]? _groups = Array.Empty<Group>();
    private SelectableGroup[]? _selectableGroups = Array.Empty<SelectableGroup>();
    
    private CreateOrEditUserModel _createOrEditUserModel = new();
    
    protected override async Task OnInitializedAsync()
    {
        _users = await Http.GetFromJsonAsync<User[]>("users");
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
        await Http.PostAsJsonAsync("users", _createOrEditUserModel);
        _users = await Http.GetFromJsonAsync<User[]>("users");
        
        _selectableGroups = Array.Empty<SelectableGroup>();
        _createOrEditUserModel = new CreateOrEditUserModel();
    }
}