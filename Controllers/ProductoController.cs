using Microsoft.AspNetCore.Mvc;
using Tiendaapi.Datos;
using Tiendaapi.Modelo;

namespace Tiendaapi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController:ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Mproducto>>> Get()
        {
            var funcion = new Dproductos();
            var lista = await funcion.Mostrarproductos();
            return lista;
        }
        [HttpGet("{IdProducto}")]
        public async Task<ActionResult<List<Mproducto>>> GetbyId(int IdProducto)
        {
            var parametros = new Mproducto();
            parametros.IdProducto = IdProducto;
            var funcion = new Dproductos();
            var lista = await funcion.MostrarproductoPorId(parametros);
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mproducto parametros)
        {
            var funcion = new Dproductos();
            await funcion.Insertarproductos(parametros);

        }
        [HttpPut("{IdProducto}")]
        public async Task<ActionResult> Put(int IdProducto,[FromBody] Mproducto parametros)
        {
            var funcion = new Dproductos();
            parametros.IdProducto = IdProducto;
            await funcion.Editarproductos(parametros);
            return NoContent();

        }

        [HttpDelete("{IdProducto}")]
        public async Task<ActionResult> Delete(int IdProducto)
        {
            var funcion = new Dproductos();
            var parametros = new Mproducto();
            parametros.IdProducto = IdProducto;
            await funcion.Eliminarproductos(parametros);
            return NoContent();

        }
    


    }
}
