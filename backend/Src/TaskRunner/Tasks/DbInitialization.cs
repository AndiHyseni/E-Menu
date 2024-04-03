using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskRunner.Tasks
{
    public class DbInitialization
    {
        private readonly ApplicationDbContext _appDbContext;
        public DbInitialization(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Run()
        {
           await _appDbContext.Database.EnsureDeletedAsync(CancellationToken.None);
           await _appDbContext.Database.EnsureCreatedAsync(CancellationToken.None);
        }
    }
}
