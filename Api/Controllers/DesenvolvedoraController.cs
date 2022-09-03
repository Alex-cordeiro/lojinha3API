using AutoMapper;
using Business.Interfaces;
using Lojinha3.Domain.Model;
using Lojinha3API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesenvolvedoraController : ControllerBase
    {
        private readonly IDesenvolvedoraBusiness _desenvolvedoraBusiness;
        private readonly IMapper _mapper;

        public DesenvolvedoraController(IDesenvolvedoraBusiness desenvolvedoraBusiness, IMapper mapper)
        {
            _desenvolvedoraBusiness = desenvolvedoraBusiness;
            _mapper = mapper;
        }

        // GET: DesenvolvedoraController/Details/5
        [HttpGet("RetornaDesenvolvedoras")]
        public IActionResult RetornaDesenvolvedoras()
        {
            return Ok(_desenvolvedoraBusiness.FindAll());
        }

        [HttpPost("NovaDesenvolvedora")]
        public IActionResult NovaDesenvolvedora([FromBody] DesenvolvedoraDto desenvolvedoraDto )
        {
            var novaDesenvolvedora = _mapper.Map<Desenvolvedora>(desenvolvedoraDto);
            var desenvolvedoraCriada = _desenvolvedoraBusiness.Create(novaDesenvolvedora);

            if(desenvolvedoraCriada != null)
                return Ok(desenvolvedoraCriada);
            return BadRequest("Não foi possível realizar a inserção do registro!");
        }

        [HttpPut("AlterarDesenvolvedora")]
        public IActionResult AlterarDesenvolvedora([FromBody] DesenvolvedoraDto desenvolvedora)
        {
            var desenvolvedoraParaEdicao = _mapper.Map<Desenvolvedora>(desenvolvedora);
            var desenvolvedoraAlterada = _desenvolvedoraBusiness.Update(desenvolvedoraParaEdicao);

            if(desenvolvedoraAlterada != null)
                return Ok(desenvolvedoraAlterada);
            return BadRequest("Não foi possível alterar o registro!");


        }

        [HttpDelete("DeletarDesenvolvedora/{Id}")]
        public IActionResult DeletaDesenvolvedora(int Id)
        {
            var retornoDelete = _desenvolvedoraBusiness.Delete(Id);

            if (retornoDelete)
                return Ok("Registro Apagado Com Sucesso!");
            return BadRequest("Não foi possível realizar a operação!");
        }
      
    }
}
