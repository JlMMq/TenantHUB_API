using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tenant.Core.Interfaces;
using Tenant.Core.Requests.Inquilino;
using Tenant.Core.Responses.Inquilino;

namespace Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InquilinoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InquilinoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("ListGridInquilino")]
        public async Task<IActionResult> ListarGridInquilino()
        {
            try
            {
                IEnumerable<SP_LIST_INQUILINO_GRID_Response> res = await _unitOfWork.InquilinoRepository.ListadoGrillaInquilino();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("InsertarInquilino")]
        public async Task<IActionResult> InsertarInquilino(SP_INSERT_INQUILINO_Request req)
        {
            try
            {
                int res = await _unitOfWork.InquilinoRepository.InsertarInquilino(req);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
