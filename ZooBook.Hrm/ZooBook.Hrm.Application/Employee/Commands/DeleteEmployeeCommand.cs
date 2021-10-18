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

namespace ZooBook.Hrm.Application.Commands
{
    public class DeleteEmployeeCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteEmployeeCommandHandler : IRequestHandler< DeleteEmployeeCommand, bool>
        {

            private readonly IHrmDbContext _context;
            private readonly ILogger<DeleteEmployeeCommandHandler> _logger;

            public DeleteEmployeeCommandHandler(IHrmDbContext context, ILogger<DeleteEmployeeCommandHandler> logger)
            {
                _logger = logger;
                _context = context;
            }

            public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    Employee employee = await _context.Employee
                        .Where(e => e.Id == request.Id)
                        .SingleAsync(cancellationToken);

                    _context.Employee.Remove(employee);
                    await _context.SaveChangesAsync();

                    return true;
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex.Message);
                }

                return false;
            }
        }
    }
}
