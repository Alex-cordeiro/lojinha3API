using AutoMapper;
using Lojinha3.Business.Interfaces;
using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lojinha3API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaMenuAcessoController : ControllerBase
    {
        private readonly ICategoriaMenuAcessoBussiness _categoriaMenuAcesso;
        private readonly IMapper _mapper;

        public CategoriaMenuAcessoController(ICategoriaMenuAcessoBussiness IcategoriaMenuAcesso, IMapper mapper)
        {
            _categoriaMenuAcesso = IcategoriaMenuAcesso;
            _mapper = mapper;
        }


        // GET: CategoriaMenuAcessoController/Details/5
        [HttpGet("RetornaCategoriasMenuAcesso")]
        public IActionResult RetornaCategoriaMenuAcessos()
        {
            var retornoCategorias = _categoriaMenuAcesso.FindAll();
            
            if(retornoCategorias.Count > 0)
                return Ok(_mapper.Map<List<CategoriaMenuAcessoDto>>(retornoCategorias));
            return Ok("Não existem categorias cadastradas");


        }

        [HttpPost("NovaCategoriaMenuAcesso")]
        public IActionResult NovaCategoriaMenuAcesso([FromBody] CategoriaMenuAcessoDto categoriaMenuAcesso)
        {
            var novaCategoriaMenuAcesso = _mapper.Map<CategoriaAcesso>(categoriaMenuAcesso);
            var desenvolvedoraCriada = _categoriaMenuAcesso.Create(novaCategoriaMenuAcesso);

            if (desenvolvedoraCriada != null)
                return Ok(desenvolvedoraCriada);
            return BadRequest("Não foi possível realizar a inserção do registro!");
        }

        [HttpPut("AlterarCategoriaMenuAcesso")]
        public IActionResult AlterarCategoriaMenuAcesso([FromBody] CategoriaMenuAcessoDto desenvolvedora)
        {
            var desenvolvedoraParaEdicao = _mapper.Map<CategoriaAcesso>(desenvolvedora);
            var desenvolvedoraAlterada = _categoriaMenuAcesso.Update(desenvolvedoraParaEdicao);

            if (desenvolvedoraAlterada != null)
                return Ok(desenvolvedoraAlterada);
            return BadRequest("Não foi possível alterar o registro!");


        }

        [HttpDelete("DeletarCategoriaMenuAcesso/{Id}")]
        public IActionResult DeletaCategoriaMenuAcesso(int Id)
        {
            var retornoDelete = _categoriaMenuAcesso.Delete(Id);

            if (retornoDelete)
                return Ok("Registro Apagado Com Sucesso!");
            return BadRequest("Não foi possível realizar a operação!");
        }
    }
}
