using ApliVentas.BD.Data;
using ApliVentas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApliVentas.Server.Controllers
{
    [ApiController]
    [Route("api/Productos")]
    public class ProductosController : ControllerBase
    {
        private readonly Context context;

        public ProductosController(Context context)
        {
            this.context = context;
        }

        [HttpGet]

        public async Task <ActionResult<List<Producto>>> Get() 
        { 
            return await context.Productos.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(Producto producto)
        {
            context.Add(producto);
            await context.SaveChangesAsync();
            return producto.id;

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Producto producto, int id)
        {
            if (id != producto.id)
            {
                return BadRequest("EL id del producto no corresponde");
            }

            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if(!existe)
            {
                return NotFound($"El producto de id={id} no existe");
            }

            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok(producto);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El producto de id={id} no existe");
            }

            context.Remove(new Producto { id = id });
            await context.SaveChangesAsync();
            return Ok(existe);
        }

    }
}
