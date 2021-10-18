using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooBook.Hrm.Application.Commands;
using ZooBook.Hrm.Application.Quaries;

namespace ZooBook.Hrm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IMediator _mediatr;

        public EmployeesController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            List<EmployeeListDto> list;
            try
            {
                list =
                    await _mediatr.Send(new GetEmployeeListQuery());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error: " + ex.Message);
            }

            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            EmployeeDetailsDto dto;
            try
            {
                dto =
                    await _mediatr.Send(new GetEmployeeDetailsQuery() { Id = id});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error: " + ex.Message);
            }

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmployee(UpsertEmployeeDto employee)
        {
            EmployeeDetailsDto dto;

            try
            {
                dto =
                    await _mediatr.Send(new UpsertEmployeeCommand { Id =0, EmployeeDto = employee});
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error: " + ex.Message);
            }

            return Ok(dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutEmployee(int id, UpsertEmployeeDto employee)
        {
            EmployeeDetailsDto dto;

            try
            {
                dto =
                    await _mediatr.Send(new UpsertEmployeeCommand { Id = id, EmployeeDto = employee });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error: " + ex.Message);
            }

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            bool result;

            try
            {
                result =
                    await _mediatr.Send(new DeleteEmployeeCommand { Id = id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "internal Server Error: " + ex.Message);
            }

            return Ok(result);
        }

    }
}
