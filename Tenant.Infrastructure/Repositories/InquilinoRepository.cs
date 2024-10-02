using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tenant.Core.Interfaces;
using Tenant.Core.Requests.Inquilino;
using Tenant.Core.Responses.Inquilino;
using Tenant.Infrastructure.Data;

namespace Tenant.Infrastructure.Repositories
{
    public class InquilinoRepository : IInquilinoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly string _connectionString;

        public InquilinoRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }   

        public async Task<IEnumerable<SP_LIST_INQUILINO_GRID_Response>> ListadoGrillaInquilino()
        {
            List<SP_LIST_INQUILINO_GRID_Response> list = new List<SP_LIST_INQUILINO_GRID_Response>();
            try
            {
                var parameters = new object[] { };
                var query = await _context.Database.SqlQueryRaw<SP_LIST_INQUILINO_GRID_Response>("SP_LIST_INQUILINO_GRID", parameters).ToListAsync();
                list = query;
            }
            catch (Exception ex)
            {
                list = new List<SP_LIST_INQUILINO_GRID_Response>();
            }
            return list;
        }

        public async Task<int> InsertarInquilino(SP_INSERT_INQUILINO_Request obj)
        {
            int value = -4;
            /*
             "value" values xd 
                 0: Insercion exitosa
                -1: Duplicado
                -2: Cath MSSQL
                -3: Cath API
             */

            try
            {
                var parameters = new Object[]
                {
                   new SqlParameter("@str_apellidos",obj.str_apellidos),
                   new SqlParameter("@str_nombres",obj.str_nombres),
                   new SqlParameter("@int_tipoDocmt",obj.int_tipoDocmt),
                   new SqlParameter("@str_nroDocmt",obj.str_nroDocmt),
                   new SqlParameter("@str_telefono",obj.str_telefono),
                   new SqlParameter("@str_prefijoPais",obj.str_prefijoPais),
                   new SqlParameter("@str_direccion",obj.str_direccion),
                   new SqlParameter("@int_tipo",obj.int_tipo),
                   new SqlParameter("@img_foto",obj.img_foto),
                   new SqlParameter("@bin_document",obj.bin_document)
                };
                var strParams = "@str_apellidos, @str_nombres, @int_tipoDocmt, @str_nroDocmt, @str_telefono, @str_prefijoPais,\r\n\t\t\t\t @str_direccion, @int_tipo, @img_foto, @bin_document";
                var result = await _context.Database.SqlQueryRaw<int>($"SP_INSERT_INQUILINO {strParams}", parameters).ToListAsync();
                value = result.FirstOrDefault();

            }
            catch(Exception ex)
            {
                value = -3;
            }

            return value;
        }
    }
}
