using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Groups.Pages;

public partial class GroupsPage
{
    [Inject]
    private HttpClient Http { get; set; } = null!;
    
    private Group[]? _groups = Array.Empty<Group>();
    private SelectablePermission[]? _selectablePermissions = Array.Empty<SelectablePermission>();
    
    private CreateOrEditGroupModel _createOrEditGroupModel = new();
    
    protected override async Task OnInitializedAsync()
    {
        _groups = await Http.GetFromJsonAsync<Group[]>("groups");
        
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
        await Http.PostAsJsonAsync("groups", _createOrEditGroupModel);
        _groups = await Http.GetFromJsonAsync<Group[]>("groups");
    }

    private Task Edit(Group group)
    {
        throw new NotImplementedException();
    }

    private Task Delete(Group group)
    {
        throw new NotImplementedException();
    }
}