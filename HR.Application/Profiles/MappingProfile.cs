using AutoMapper;
using HR.Application.DTOs.LeaveAllocation;
using HR.Application.DTOs.LeaveRequest;
using HR.Application.DTOs.LeaveType;
using HR.Domain;

namespace HR.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();


        }
    }
}
