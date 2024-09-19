using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant.Core.Interfaces;
using Tenant.Infrastructure.Data;

namespace Tenant.Infrastructure.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;

        public BaseRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            _context = context;
        }
        public async Task<bool> DataBaseRun()
        {
            try
            {
                await _context.Database.OpenConnectionAsync();
                await _context.Database.CloseConnectionAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
