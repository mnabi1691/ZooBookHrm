using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Hrm.Application.Interfaces;
using ZooBook.Hrm.Domain.Entities;

namespace ZooBook.Hrm.Application.Quaries
{
    public class EmployeeDetailsDto: IMapFrom<Employee>
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Employee, EmployeeDetailsDto>();
        }
    }
}
