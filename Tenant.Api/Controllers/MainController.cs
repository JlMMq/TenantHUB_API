using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Tenant.Core.Interfaces;

namespace Tenant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MainController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("run")]
        public async Task<IActionResult> SystemResponse()
        {
            return Ok(true);
        }

        [HttpGet("dbrun")]
        public async Task<IActionResult> DataBaseResponse()
        {
            try
            {
                bool res = await _unitOfWork.BaseRepository.DataBaseRun();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
