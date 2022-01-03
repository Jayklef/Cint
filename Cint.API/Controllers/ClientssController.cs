using Cint.DataAccess.Dtos;
using Cint.DataAccess.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientssController : ControllerBase
    {
        private readonly IClientRepository _IClientRepository;

        public ClientssController(IClientRepository iClientRepository)
        {
            _IClientRepository = iClientRepository;
        }

        public IActionResult GetAllClients()
        {
            try
            {
                var client = _IClientRepository.GetAllClients();
                return Ok(client);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponseDto
                {
                    ResponseCode = "01",
                    ResponseMessage = ex.Message == null ? null : ex.Message.ToString(),
                    StackTrace = ex.StackTrace
                };

                return BadRequest(errorResponse);
            }
        }
    }
}
