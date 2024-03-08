using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.DTO;
using Questao5.Domain.Entities;
using Questao5.FlowControls;
using Questao5.Services.Interfaces;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimentoController : ControllerBase
    {
        private readonly ILogger<MovimentoController> _logger;
        private readonly IMovimentoService _service;
        private readonly IMapper _mapper;

        public MovimentoController(ILogger<MovimentoController> logger, IMovimentoService service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpPost(Name = "PostMovimento")]
        public async Task<ActionResult> Post(MovimentoDTO movimentoDto)
        {
            try
            {
                var movimento = _mapper.Map<Movimento>(movimentoDto);
                var ok = await _service.InsereMovimento(movimento: movimento);
                return Ok(ok);
            }
            catch (CustomException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}