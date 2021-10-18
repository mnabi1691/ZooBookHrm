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

namespace ZooBook.Hrm.Application.Quaries
{
    public class GetEmployeeListQuery: IRequest<List<EmployeeListDto>>
    {
        public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeListDto>>
        {
            private readonly IHrmDbContext _context;
            private readonly ILogger<GetEmployeeListQueryHandler> _logger;

            public GetEmployeeListQueryHandler(IHrmDbContext context, ILogger<GetEmployeeListQueryHandler> logger)
            {
                _logger = logger;
                _context = context;
            }

            public async Task<List<EmployeeListDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
            {
                List<EmployeeListDto> list = null;

                try
                {
                    list = await _context.Employee
                        .Select(e => new EmployeeListDto
                        {
                            Id = e.Id,
                            FullName = e.FirstName + " " 
                            + (string.IsNullOrEmpty(e.MiddleName)? "": e.MiddleName + " ")
                            + e.LastName
                        }).ToListAsync(cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                return list;
            }
        }
    }
}
