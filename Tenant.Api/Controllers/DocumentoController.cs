using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Tenant.Core.Interfaces;
using Tenant.Core.Responses.Documento;

namespace Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public DocumentoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("ListDocumento")]
        public async Task<IActionResult> ListarDocumentoGeneral()
        {
            try
            {
                IEnumerable<SP_LIST_DOCUMENTO_GEN_Response> res = await _unitOfWork.DocumentoRepository.ListadoGeneralDocumentos();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
