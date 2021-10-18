using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZooBook.Hrm.Application.Interfaces;
using ZooBook.Hrm.Domain.Entities;

namespace ZooBook.Hrm.Application.Commands
{
    public class UpsertEmployeeDto : IMapFrom<Employee>
    {

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpsertEmployeeDto, Employee>();
        }
    }
}
