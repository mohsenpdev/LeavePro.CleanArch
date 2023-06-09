﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LeavePro.CleanArch.Application.Contracts.Persistence;

namespace LeavePro.CleanArch.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(255).WithMessage("{PropertyName} must be fewer than 255 character");

        RuleFor(p => p.DefaultDays)
            .LessThanOrEqualTo(100).WithMessage("{PropertyName} cannot exceed 100")
            .GreaterThanOrEqualTo(1).WithMessage("{PropertyName} cannot be less than 1");

        RuleFor(q => q)
                .MustAsync(LeaveTypeNameIsUnique)
                .WithMessage("Leave type already exist");
    }

    private async Task<bool> LeaveTypeNameIsUnique(CreateLeaveTypeCommand command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }
}

