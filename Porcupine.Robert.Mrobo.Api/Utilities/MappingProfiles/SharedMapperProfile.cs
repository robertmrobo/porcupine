using AutoMapper;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Groups.GetGroups;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Permissions.GetPermission;
using Porcupine.Robert.Mrobo.Api.Features.IAM.Users.GetUser;
using Porcupine.Robert.Mrobo.IAM.Groups.Models;
using Porcupine.Robert.Mrobo.IAM.Permissions.Models;
using Porcupine.Robert.Mrobo.IAM.Users.Models;

namespace Porcupine.Robert.Mrobo.Api.Utilities.MappingProfiles;

public class SharedMapperProfile : Profile
{
    public SharedMapperProfile()
    {
        CreateMap<Group, GetGroupResult>();
        CreateMap<Permission, GetPermissionResult>();
        CreateMap<User, GetUserResult>();
    }
}