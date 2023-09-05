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
        
        [HttpGet("{id:int}")]

        public async Task<ActionResult<Producto>> Get(int id)
        {
            var existe = await context.Productos.AnyAsync(x => x.id == id);
            if (existe)
            {
                return NotFound($"El producto {id} no existe");
            }
            return await context.Productos.FirstOrDefaultAsync(prod => prod.id == id);
        }   

        [HttpPost]

        public async Task<ActionResult<int>> Post(Producto producto)
        {
            context.Add(producto);
            await context.SaveChangesAsync();
            return producto.id;

        }//productoDTO

        //     if (entidad != null)
    //        {
    //            return BadRequest("Ya existe un producto con ese ID");
    //}
    //        try
    //        {
    //            Producto x = new Producto();
    //            x.Nombre = producto.nombre;
    //            x.PrecioProducto = producto.PrecioProducto;
    //            

    //            context.producto.Add(x);
    //            await context.SaveChangesAsync();
    //            return x.Id;

    //        }
    //        catch (Exception ex) { return BadRequest(ex); }


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
        }//productoDTO

        //        var responseApi = new ResponseAPI<int>();
        //            try
        //            {
        //                var dbproducto = await context.producto.FirstOrDefaultAsync(e => e.NombreProducto == Nc);
        //                if (dbproducto != null)
        //                {
        //                    dbproducto.Nombre = producto.Nombre;
        //                    dbproducto.Nombre = producto.PrecioFinal;
        //                    
        //                    context.productos.Update(dbproducto);
        //                    await context.SaveChangesAsync();
        //                  responseApi.EsCorrecto = true;
        //                    responseApi.Valor = dbproducto.NombreProducto;

        //                }
        //                else
        //                {
        //                    responseApi.EsCorrecto = false;
        //                    responseApi.Mensaje = "producto no encontrada";
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //    responseApi.EsCorrecto = false;
        //    responseApi.Mensaje = ex.Message;
        //}
        //return Ok(responseApi);

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
