using LojaApi.Entities;
using LojaApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LojaApi.Infra.DTOs;

namespace LojaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        public CategoriasController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public ActionResult<List<CategoriaDTO>> GetAll()
        {
            var categorias = _categoriaService.ObterTodos();

            var categoriasDto = categorias
                .Select(c => new CategoriaDTO 
                {
                    Id = c.Id,
                    Nome = c.Nome
                })
                .ToList();
            
            // 3. Retorna a lista de DTOs, resolvendo o erro de ciclo.
            return Ok(categoriasDto);
        }

        [HttpGet("{id}")]
        public ActionResult<Categoria> GetById(int id)
        {
            var categoria = _categoriaService.ObterPorId(id);
            if (categoria == null) return NotFound();
            var categoriaDto = new CategoriaDTO
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
            
            return Ok(categoriaDto);
        }

        [HttpPost]
        public ActionResult<Categoria> Add(Categoria novaCategoria)
        {
            try
            {
                var categoriaAdicionada = _categoriaService.Adicionar(novaCategoria);
                return CreatedAtAction(nameof(GetById), new
                {
                    id = categoriaAdicionada.Id
                }, categoriaAdicionada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
