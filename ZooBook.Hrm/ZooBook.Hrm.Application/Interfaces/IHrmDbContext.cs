using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Hrm.Domain.Entities;

namespace ZooBook.Hrm.Application.Interfaces
{
    public interface IHrmDbContext
    {
        public DbSet<Employee> Employee { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
