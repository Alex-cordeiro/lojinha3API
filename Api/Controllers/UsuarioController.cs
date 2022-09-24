using AutoMapper;
using Lojinha3.Business.Interfaces;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lojinha3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioBusiness usuarioBusiness, IMapper mapper)
        {
            _usuarioBusiness = usuarioBusiness;
            _mapper = mapper;
        }


        // GET: api/<UsuarioController>
        [HttpGet("RetornaUsuarios")]
        public IActionResult RetornaUsuarios()
        {
            var usuarios = _usuarioBusiness.FindAll();

            if(usuarios != null)
                return Ok(usuarios);
            return NotFound();
        }

        // GET api/<UsuarioController>/5
        [HttpGet("RetornaUsuarioPorId/{id}")]
        public IActionResult RetornaUsuarioPorId(int id)
        {
            
            var usuario = _usuarioBusiness.FindByID(id);
            if (usuario == null)
                return BadRequest("Registro não encontrado!");
            return Ok(usuario);
        }

        // POST api/<UsuarioController>
        [HttpPost("NovoUsuario")]
        public IActionResult Post([FromBody] UsuarioDto usuarioDto)
        {
            var novoUsuario = _mapper.Map<Usuario>(usuarioDto);
            var usuarioCriado = _usuarioBusiness.Create(novoUsuario);
            
            if (usuarioCriado != null)
                return Ok(usuarioCriado);
            return BadRequest("Não foi possivel inserir o registro!");

        }

        // PUT api/<UsuarioController>/5
        [HttpPut("AlterarUsuario/{id}")]
        public IActionResult AlterarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            var usuarioParaEditar = _mapper.Map<Usuario>(usuarioDto);
            var usuarioAlterado = _usuarioBusiness.Update(usuarioParaEditar);

            if (usuarioAlterado != null)
                return Ok(usuarioAlterado);
            return BadRequest("Não foi possivel alterar o registro!");
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("DeletarUsuario/{id}")]
        public IActionResult Delete(int id)
        {
            var retornoDelete = _usuarioBusiness.Delete(id);
            if (retornoDelete)
                return Ok("Registro Apagado com sucesso!");
            return BadRequest("Erro ao excluir");
        }
    }
}
