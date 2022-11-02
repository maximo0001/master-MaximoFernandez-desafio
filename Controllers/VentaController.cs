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
        public void Agregar([FromBody] Venta ven)
        {
            ADO_Venta.AgregarVenta(ven);
        }
    }
}
