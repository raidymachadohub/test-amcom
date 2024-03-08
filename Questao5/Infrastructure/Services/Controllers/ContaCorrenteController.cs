using Microsoft.AspNetCore.Mvc;
using Questao5.FlowControls;
using Questao5.Services.Interfaces;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {  
        private readonly IContaCorrenteService _service;
        
        public ContaCorrenteController(IContaCorrenteService service)
        {
            _service = service;
        }
        
        [HttpGet(Name = "GetContaCorrente")]
        public async Task<ActionResult> Get(string idContaCorrente)
        {
            try
            {
                var ok = await _service.SaldoConta(idContaCorrente);
                return Ok(ok);
            }
            catch (CustomException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}