using Blazor_Catalogo.Server.Context;
using Blazor_Catalogo.Server.Utils;
using Blazor_Catalogo.Shared.Models;
using Blazor_Catalogo.Shared.Recursos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogo_Blazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext context;

        public CategoriaController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> Get([FromQuery] Paginacao paginacao)
        {
            var queryable = context.Categorias.AsQueryable();
            await HttpContext.InserirParametroEmPageResponse(queryable, paginacao.QuantidadePorPagina);

            //return await context.Categorias.AsNoTracking().ToListAsync();

            return await queryable.Paginar(paginacao).ToListAsync();
        }

        [HttpGet("{id}", Name = "GetCategoria")]
        public async Task<ActionResult<Categoria>> Get(int id)
        {
            return await context.Categorias.FirstOrDefaultAsync(x => x.CategoriaId == id);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Post(Categoria categoria)
        {
            context.Add(categoria);
            await context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetCategoria", new { id = categoria.CategoriaId }, categoria);
        }

        [HttpPut]
        public async Task<ActionResult<Categoria>> Put(Categoria categoria)
        {
            context.Entry(categoria).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(categoria);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Categoria>> Delete(int id)
        {
            var categoria = new Categoria { CategoriaId = id };
            context.Remove(categoria);
            await context.SaveChangesAsync();
            return Ok(categoria);
        }
    }
}
