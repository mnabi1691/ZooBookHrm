using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Hrm.Application.Interfaces;
using ZooBook.Hrm.Domain.Entities;

namespace ZooBook.Hrm.Application.Quaries
{
    public class GetEmployeeDetailsQuery: IRequest<EmployeeDetailsDto>
    {
        public int Id { get; set; }

        public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsDto>
        {
            private readonly IHrmDbContext _context;
            private readonly ILogger<GetEmployeeDetailsQueryHandler> _logger;
            private readonly IMapper _mapper;

            public GetEmployeeDetailsQueryHandler(IHrmDbContext context, ILogger<GetEmployeeDetailsQueryHandler> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<EmployeeDetailsDto> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
            {
                EmployeeDetailsDto dto = null;

                try
                {
                    if (request.Id > 0)
                    {
                        Employee employee = await _context.Employee
                            .Where(e => e.Id == request.Id)
                            .SingleAsync(cancellationToken);

                        dto = _mapper.Map<EmployeeDetailsDto>(employee);
                    }
                    else
                    {
                        dto = new EmployeeDetailsDto();
                        dto.Id = 0;
                    }
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

