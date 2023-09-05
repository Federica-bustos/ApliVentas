using ApliVentas.BD.Data;
using ApliVentas.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApliVentas.Server.Controllers
{

    [ApiController]
    [Route("api/Ganancias")]
    public class GananciasController : ControllerBase
    {
        private readonly Context context;

        public GananciasController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ganancia>>> Get()
        {
            return await context.Ganancias.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ganancia>> Get(int id)
        {
            var existe = await context.Ganancias.AnyAsync(x => x.Id == id);
            if (existe)
            {
                return NotFound($"La ganancia {id} no existe");
            }
            return await context.Ganancias.FirstOrDefaultAsync(gan => gan.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post (Ganancia ganancia)
        {
            context.Add(ganancia);
            await context.SaveChangesAsync();
            return ganancia.Id;
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Ganancia ganancia, int id)
        {
            if (id != ganancia.Id)
            {
                return BadRequest("EL id de la ganancia no corresponde");
            }

            var existe = await context.Ganancias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La ganancia de id={id} no existe");
            }

            context.Update(ganancia);
            await context.SaveChangesAsync();
            return Ok(ganancia);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Ganancias.AnyAsync(x => x.Id == id );
            if (!existe)
            {
                return NotFound($"la ganancia de id={id} no existe");
            }

            context.Remove(new Ganancia { Id = id });
            await context.SaveChangesAsync();
            return Ok(existe);
        }

    }
}
