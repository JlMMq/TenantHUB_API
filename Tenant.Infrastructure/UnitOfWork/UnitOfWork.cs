using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tenant.Core.Interfaces;
using Tenant.Infrastructure.Data;
using Tenant.Infrastructure.Repositories;

namespace Tenant.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IConfiguration _configuration;
        
        //Interfaces
        private IBaseRepository _baseRepository;
        private IDocumentoRepository _documentoRepository;

        public UnitOfWork(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IBaseRepository BaseRepository 
        {
            get { return _baseRepository ??= new BaseRepository(_context, _configuration); }
        }

        public IDocumentoRepository DocumentoRepository
        {
            get { return _documentoRepository ??= new DocumentoRepository(_context, _configuration); }
        }
    }
}
