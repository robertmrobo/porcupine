using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Porcupine.Robert.Mrobo.Portal.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.Portal.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Portal.IAM.Permissions.Pages;

public partial class PermissionsPage : ComponentBase
{
    [Inject]
    private HttpClient Http { get; set; } = null!;
    
    private Permission[]? _permissions = Array.Empty<Permission>();
    
    private CreateEditPermissionModel _createEditPermissionModel = new();
    
    protected override async Task OnInitializedAsync()
    {
        _permissions = await Http.GetFromJsonAsync<Permission[]>("permissions");
        
        StateHasChanged();
    }
    
    private async Task OnSubmit()
    {
        await Http.PostAsJsonAsync("permissions", _createEditPermissionModel);
        _permissions = await Http.GetFromJsonAsync<Permission[]>("permissions");
        _createEditPermissionModel = new();
    }
    
    private Task Edit(Permission group) => throw new NotImplementedException();

    private Task Delete(Permission group) => throw new NotImplementedException();
    
}