﻿using AutoMapper;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.DeleteLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Commands.UpdateLeaveType;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using LeavePro.CleanArch.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using LeavePro.CleanArch.Domain;

namespace LeavePro.CleanArch.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveType, LeaveTypeDetailsDto>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
        CreateMap<DeleteLeaveTypeCommand, LeaveType>();

    }
}