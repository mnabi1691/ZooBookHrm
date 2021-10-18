using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Hrm.Application.Quaries;
using ZooBook.Hrm.Application.Interfaces;
using AutoMapper;
using ZooBook.Hrm.Domain.Entities;

namespace ZooBook.Hrm.Application.Commands
{
    public class UpsertEmployeeCommand: IRequest<EmployeeDetailsDto>
    {
        public UpsertEmployeeDto EmployeeDto { get; set; }

        public int Id { get; set; }

        public class UpsertEmployeeCommandHandler : IRequestHandler<UpsertEmployeeCommand, EmployeeDetailsDto>
        {
            private readonly IHrmDbContext _context;
            private readonly ILogger<UpsertEmployeeCommandHandler> _logger;
            private readonly IMapper _mapper;

            public UpsertEmployeeCommandHandler(IHrmDbContext context, ILogger<UpsertEmployeeCommandHandler> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<EmployeeDetailsDto> Handle(UpsertEmployeeCommand request, CancellationToken cancellationToken)
            {
                EmployeeDetailsDto dto = null;
                ZooBook.Hrm.Domain.Entities.Employee employee = null;

                try
                {
                    if (request.Id > 0)
                    {
                        employee = await _context.Employee
                            .Where(e => e.Id == request.Id)
                            .SingleAsync();
                    }
                    else
                    {
                        employee = new Domain.Entities.Employee();
                        _context.Employee.Add(employee);
                    }

                    //map
                    _mapper.Map(request.EmployeeDto, employee);
                    await _context.SaveChangesAsync();

                    //map to dto
                    dto = _mapper.Map<Employee, EmployeeDetailsDto>(employee);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                return dto;
            }
        }
    }
}
