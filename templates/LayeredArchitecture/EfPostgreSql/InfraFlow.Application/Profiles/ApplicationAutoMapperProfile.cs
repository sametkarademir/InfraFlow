using AutoMapper;
using InfraFlow.Application.DTOs.AppSnapshots;
using InfraFlow.Application.DTOs.Common;
using InfraFlow.Domain.Snapshot.Entities;
using InfraFlow.EntityFramework.Core.Models;

namespace InfraFlow.Application.Profiles;

public class ApplicationAutoMapperProfile : Profile
{
    public ApplicationAutoMapperProfile()
    {
        CreateMap<Paginate<AppSnapshot>, PaginatedResponseDto<AppSnapshotResponseDto>>().ReverseMap();
        CreateMap<AppSnapshot, AppSnapshotResponseDto>()
            .AfterMap((src, dest) =>
            {
                dest.InterfaceNames = src.InterfaceName?.Split(',').ToList();
                dest.IpAddresses = src.IpAddress?.Split(',').ToList();
            })
            .ReverseMap();
    }
}