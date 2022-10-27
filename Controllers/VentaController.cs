using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController
    {
        [HttpPost]
        public void Agregar([FromBody] List<Producto> prod, int id)
        {
            ADO_Venta.AgregarVenta(prod,id);
        }
    }
}
