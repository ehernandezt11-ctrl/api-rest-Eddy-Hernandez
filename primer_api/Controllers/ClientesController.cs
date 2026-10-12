using primer_api.Models;
using Microsoft.AspNetCore.Mvc;

namespace primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly BdEmpresaContext _context;

        public EmpleadosController(BdEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarEmpleados")]
        public ActionResult<List<Empleado>> ListarEmpleados()
        {
            return _context.Empleados.ToList();
        }

        [HttpGet("ObtenerEmpleado/{id}")]
        public ActionResult<Empleado> ObtenerEmpleado(int id)
        {
            var empleados = _context.Empleados.FirstOrDefault(e => e.Idempleados == id);
            if (empleados == null)
            {
                return NotFound("Empleado no encontrado");
            }
            return empleados;
        }

        [HttpPost("CrearEmpleado")]
        public ActionResult CrearEmpleado([FromBody] Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            return Ok("Empleado creado correctamente");
        }

        [HttpPut("ActualizarEmpleado/{id}")]
        public ActionResult ActualizarEmpleado(int id, [FromBody] Empleado empleadoDatos)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.Idempleados == id);
            if (empleado == null)
            {
                return NotFound("Empleado no encontrado");
            }

            empleado.Idpuesto = empleadoDatos.Idpuesto;
            empleado.Nombres = empleadoDatos.Nombres;
            empleado.Apellidos = empleadoDatos.Apellidos;

            _context.SaveChanges();
            return Ok("Empleado actualizado correctamente");
        }

        [HttpDelete("EliminarEmpleado/{id}")]
        public ActionResult EliminarEmpleado(int id)
        {
            var empleado = _context.Empleados.FirstOrDefault(e => e.Idempleados == id);
            if (empleado == null)
            {
                return NotFound("Empleado no encontrado");
            }

            _context.Empleados.Remove(empleado);
            _context.SaveChanges();
            return Ok("Empleado eliminado correctamente");
        }
    }
}

namespace mi_primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly BdEmpresaContext _context;

        public ClientesController(BdEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarClientes")]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            return _context.Clientes.ToList();
        }

        [HttpGet("ObtenerCliente/{id}")]
        public ActionResult<Cliente> ObtenerCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Idclientes == id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }
            return cliente;
        }

        [HttpPost("CrearCliente")]
        public ActionResult CrearCliente([FromBody] Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return Ok("Cliente creado correctamente");
        }

        [HttpPut("ActualizarCliente/{id}")]
        public ActionResult ActualizarCliente(int id, [FromBody] Cliente clienteDatos)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Idclientes == id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            cliente.Nombre = clienteDatos.Nombre;
            cliente.Apellidos = clienteDatos.Apellidos;
            cliente.Telefono = clienteDatos.Telefono;

            _context.SaveChanges();
            return Ok("Cliente actualizado correctamente");
        }

        [HttpDelete("EliminarCliente/{id}")]
        public ActionResult EliminarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Idclientes == id);
            if (cliente == null)
            {
                return NotFound("Cliente no encontrado");
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return Ok("Cliente eliminado correctamente");
        }
    }
}


namespace mi_primer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuestosController : ControllerBase
    {
        private readonly BdEmpresaContext _context;

        public PuestosController(BdEmpresaContext ctx)
        {
            _context = ctx;
        }

        [HttpGet("ListarPuestos")]
        public ActionResult<List<Puesto>> ListarPuestos()
        {
            return _context.Puestos.ToList();
        }

        [HttpGet("ObtenerPuesto/{id}")]
        public ActionResult<Puesto> ObtenerPuesto(int id)
        {
            var puesto = _context.Puestos.FirstOrDefault(p => p.Idpuestos == id);
            if (puesto == null)
            {
                return NotFound("Puesto no encontrado");
            }
            return puesto;
        }

        [HttpPost("CrearPuesto")]
        public ActionResult CrearPuesto([FromBody] Puesto puesto)
        {
            _context.Puestos.Add(puesto);
            _context.SaveChanges();
            return Ok("Puesto creado correctamente");
        }

        [HttpPut("ActualizarPuesto/{id}")]
        public ActionResult ActualizarPuesto(int id, [FromBody] Puesto puestoDatos)
        {
            var puesto = _context.Puestos.FirstOrDefault(p => p.Idpuestos == id);
            if (puesto == null)
            {
                return NotFound("Puesto no encontrado");
            }

            puesto.Nombre = puestoDatos.Nombre;

            _context.SaveChanges();
            return Ok("Puesto actualizado correctamente");
        }

        [HttpDelete("EliminarPuesto/{id}")]
        public ActionResult EliminarPuesto(int id)
        {
            var puesto = _context.Puestos.FirstOrDefault(p => p.Idpuestos == id);
            if (puesto == null)
            {
                return NotFound("Puesto no encontrado");
            }

            _context.Puestos.Remove(puesto);
            _context.SaveChanges();
            return Ok("Puesto eliminado correctamente");
        }
    }
}
