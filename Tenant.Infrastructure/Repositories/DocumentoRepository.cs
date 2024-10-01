using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tenant.Core.Interfaces;
using Tenant.Core.Responses.Documento;
using Tenant.Infrastructure.Data;

namespace Tenant.Infrastructure.Repositories
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;

        public DocumentoRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<SP_LIST_DOCUMENTO_GEN_Response>> ListadoGeneralDocumentos()
        {
            List<SP_LIST_DOCUMENTO_GEN_Response> list = new List<SP_LIST_DOCUMENTO_GEN_Response>();
            try
            {
                var parameters = new object[] { };
                var query = await _context.Database.SqlQueryRaw<SP_LIST_DOCUMENTO_GEN_Response>($"SP_LIST_DOCUMENTO_GEN", parameters).ToListAsync();
                list = query;
            }
            catch (Exception ex)
            {
                list = new List<SP_LIST_DOCUMENTO_GEN_Response>();
            }
            return list;
        }
    }
}
