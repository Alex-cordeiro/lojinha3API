using AutoMapper;
using Lojinha3.Business.Implementations;
using Lojinha3.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissaoUsuarioController : ControllerBase
    {
        private readonly PermissaoUsuarioBusinessImplementation _permissaoAcessoBusiness;
        private readonly IMapper mapper;

        public PermissaoUsuarioController(IPermissaoUsuarioBusiness permissaoAcessoBusiness, IMapper mapper)
        {
            _permissaoAcessoBusiness = (PermissaoUsuarioBusinessImplementation)permissaoAcessoBusiness;
            this.mapper = mapper;
        }

        // GET: api/<PermissaoMenusController>
        [HttpPost("RetornaPermissaoPorUsuario/{id}")]
        public IActionResult RetornaPermissoesPorUsuario(int id)
        {
            var permissoesRetornadas = _permissaoAcessoBusiness.FindByUserPermission(id);
            if (permissoesRetornadas.Count > 0)
                return Ok(permissoesRetornadas);
            return NotFound("Não foram encontradas permissões atribuidas à este usuario!");
        }

        // GET api/<PermissaoMenusController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/<PermissaoMenusController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<PermissaoMenusController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PermissaoMenusController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
