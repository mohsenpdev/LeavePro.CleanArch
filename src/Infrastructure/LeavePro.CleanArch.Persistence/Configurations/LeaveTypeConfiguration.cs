﻿using LeavePro.CleanArch.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeavePro.CleanArch.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(l => l.Name)
            .IsUnique();

        builder.HasData(new List<LeaveType>
        {
            new LeaveType()
            {
                Id = 1,
                Name = "Vacation",
                DefaultDays = 7,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            },
            new LeaveType()
            {
                Id = 2,
                Name = "Sick",
                DefaultDays = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            }
        });
    }
}
