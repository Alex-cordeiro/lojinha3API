using Lojinha3API.Models;
using Lojinha3API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lojinha3API.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly JogoService _jogoService;

        public JogoController(JogoService jogoService)
        {
            this._jogoService = jogoService;
        }

        // GET: api/<JogoController>
        [HttpGet]
        public IActionResult RetornaJogos()
        {
            var jogosRetornados = _jogoService.FindAll();
            if(jogosRetornados == null)
                return NotFound();
            return Ok(jogosRetornados);
            
        }

        // GET api/<JogoController>/5
        [HttpGet("{idJogo}")]
        public IActionResult RetornaJogoPorId(int idJogo)
        {
            var jogoRetornado = _jogoService.FindById(idJogo);
            if (jogoRetornado != null)
                return Ok(jogoRetornado);
            return NotFound("Jogo não encontrado!");
        }

        // POST api/<JogoController>
        [HttpPost]
        public IActionResult Post([FromBody] Jogo jogo)
        {
            if (_jogoService.Insert(jogo))
                return Ok("Novo jogo inserido!");
            return BadRequest("Não foi possível inserir o registro!");

        }

        // PUT api/<JogoController>/5
        [HttpPut]
        [Route("AlteraJogo/{id}")]
        public IActionResult AlteraJogo(int id, [FromBody] Jogo jogo)
        {
            if(_jogoService.Update(id, jogo))
                return Ok("Jogo Atualizado com sucesso!");
            return BadRequest("Não foi possível atualizar o registro!");
        }

        // DELETE api/<JogoController>/5
        [HttpDelete]
        [Route("DeletaJogo/{id}")]
        public IActionResult ApagaJogo(int id)
        {
            if (_jogoService.Delete(id))
                return Ok("Jogo apagado com sucesso!");
            return BadRequest("Não foi possível apagar o registro!");
        }
    }
}
