using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZooBook.Hrm.Application.Interfaces;
using ZooBook.Hrm.Domain.Entities;

namespace ZooBook.Hrm.Persistence
{
    public class HrmDbContext: DbContext, IHrmDbContext
    {
        public HrmDbContext(DbContextOptions<HrmDbContext> options) : base(options)
        { 
        }

        #region Tables
        public DbSet<Employee> Employee { get; set; }
        #endregion

        #region Methods
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
