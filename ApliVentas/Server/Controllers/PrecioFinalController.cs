using ApliVentas.BD.Data;
using ApliVentas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApliVentas.Server.Controllers
{
    [ApiController]
    [Route("api/PrecioFinal")]
    public class PrecioFinalController : ControllerBase

    {
        private readonly Context context;

        public PrecioFinalController(Context context)
        {
            this.context = context;
        }
    

        [HttpGet]

        public async Task<ActionResult<List<PrecioFinal>>> Get()
        {
            return await context.precioFinals.ToListAsync();
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(PrecioFinal precioFinal)
        {
            context.Add(precioFinal);
            await context.SaveChangesAsync();
            return precioFinal.id;

        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(PrecioFinal precioFinal, int id)
        {
            if (id != precioFinal.id)
            {
                return BadRequest("EL id del precio final no corresponde");
            }

            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El precio final de id={id} no existe");
            }

            context.Update(precioFinal);
            await context.SaveChangesAsync();
            return Ok(precioFinal);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.precioFinals.AnyAsync(x => x.id == id);
            if (!existe)
            {
                return NotFound($"El precio final de id={id} no existe");
            }

            context.Remove(new PrecioFinal { id = id });
            await context.SaveChangesAsync();
            return Ok(existe);
        }
    }

}
