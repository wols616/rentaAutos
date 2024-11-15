using PrimerAvance.Models;
using Microsoft.AspNetCore.Mvc;
using PrimerAvance.Models;
using System.Diagnostics;
using Avance1P3.Models;

namespace Avance1P3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //========================CONTROLLER AUTOS=============================
        public IActionResult ListadoAutos()
        {
            Autos autos = new Autos();
            ViewBag.autos = autos.listar();

            return View("listaAutos");
        }

        public IActionResult AgregandoAutos(string Marca, string Modelo, string Placa, string Tipo, string Estado, double Costo_dia)
        {
            try
            {
                Autos auto = new Autos();
                auto.Marca = Marca;
                auto.Modelo = Modelo;
                auto.Placa = Placa;
                auto.Tipo = Tipo;
                auto.Estado = Estado;
                auto.Costo_dia = Costo_dia;
                auto.agregar(auto);
                ViewBag.exito = 1;
                ViewBag.autos = auto.listar();
            }
            catch
            {
                ViewBag.exito = 0;
            }

            return View("listaAutos");
        }

        public IActionResult VerAuto(int id)
        {
            Autos objListar = new Autos();
            ViewBag.autos = objListar.listar(id).FirstOrDefault();
            return View("verAuto");
        }

        public IActionResult BorrandoAuto(int id)
        {
            Autos auto = new Autos();
            auto.eliminarAuto(id);
            ViewBag.autos = auto.listar();
            return View("listaAutos");
        }

        public IActionResult EditarAuto(int id)
        {
            Autos autos = new Autos();
            if (autos.listar(id).FirstOrDefault() == null)
            {
                ViewBag.autos = autos.listar();
                return View("listaAutos");
            }
            ViewBag.autos = autos.listar(id).FirstOrDefault();
            return View("editarAuto");
        }

        public IActionResult EditandoAuto(int idauto, string Marca, string Modelo, string Placa, string Tipo, string Estado, double Costo_dia)
        {
            Autos auto = new Autos();
            auto.idauto = idauto;
            auto.Marca = Marca;
            auto.Modelo = Modelo;
            auto.Placa = Placa;
            auto.Tipo = Tipo;
            auto.Estado = Estado;
            auto.Costo_dia = Costo_dia;
            auto.editarAuto(auto);

            ViewBag.autos = auto.listar();
            return View("listaAutos");
        }

        //=====================================================================

        //==========================CONTROLLER EMPLEADOS==================================


        public IActionResult ListadoEmpleados()
        {
            Empleados empleado = new Empleados();
            ViewBag.empleado = empleado.listar();

            return View("listaEmpleado");
        }

        public IActionResult VerEmpleado(int id)
        {
            Empleados objListar = new Empleados();
            ViewBag.empleado = objListar.listar(id).FirstOrDefault();
            return View("verEmpleado");
        }
        public IActionResult AgregandoEmpleados(string Nombre, string Telefono, string Cargo, string Email)
        {
            try
            {
                Empleados empleado = new Empleados();
                empleado.Nombre = Nombre;
                empleado.Telefono = Telefono;
                empleado.Cargo = Cargo;
                empleado.Email = Email;
                empleado.AgregarEmpleado(empleado);
                ViewBag.exito = 1;
                ViewBag.empleado = empleado.listar();
            }
            catch
            {
                ViewBag.exito = 0;
            }

            return View("listaEmpleado");
        }

        public IActionResult BorrandoEmpleados(int id)
        {
            Empleados empleado = new Empleados();
            empleado.eliminarEmpleado(id);
            ViewBag.empleado = empleado.listar();
            return View("listaEmpleado");
        }

        public IActionResult EditarEmpleados(int id)
        {
            Empleados empleado = new Empleados();
            if (empleado.listar(id).FirstOrDefault() == null)
            {
                ViewBag.empleados = empleado.listar();
                return View("listaEmpleado");
            }
            ViewBag.empleados = empleado.listar(id).FirstOrDefault();
            return View("editarEmpleado");
        }


        public IActionResult EditandoEmpleado(int idEmpleado, string Nombre, string Telefono, string Cargo, string Email)
        {
            Empleados empleado = new Empleados();
            empleado.idempleado = idEmpleado;
            empleado.Nombre = Nombre;
            empleado.Telefono = Telefono;
            empleado.Cargo = Cargo;
            empleado.Email = Email;
            
            empleado.editarEmpleado(empleado);

            ViewBag.empleado = empleado.listar();
            return View("listaEmpleado");
        }





        //===============================================================================



        //==========================CONTROLER FACTURA==================================

        public IActionResult ListarFactura()
        {
            Facturas facturas = new Facturas();
            ViewBag.facturas = facturas.VerTodasLasFacturas();

            return View("listaFacturas");
        }

        public IActionResult VerFactura(int id)
        {
            Facturas objListar = new Facturas();
            Facturas facturas = objListar.VerFactura(id);

            return View("verFactura");
        }




        public IActionResult AgregarFacturass(int idCliente, int idAuto, int idEmpleado, DateTime fecha, double subtotal, double iva, double total)
        {
            try
            {
                Facturas factura = new Facturas();
                factura.idCliente = idCliente;
                factura.idAuto = idAuto;
                factura.idEmpleado = idEmpleado;
                factura.fecha = fecha;
                factura.subtotal = subtotal;
                factura.IVA = iva;
                factura.total = total;
                factura.AgregarFactura(factura);
                ViewBag.exito = 1;
                ViewBag.facturas = factura.VerTodasLasFacturas();
            }
            catch
            {
                ViewBag.exito = 0;
            }

            return View("listaFacturas");
        }


        public IActionResult ActualizarFacturass(int idFactura, int idCliente, int idAuto, int idEmpleado, DateTime fecha, double subtotal, double iva, double total)
        {
            try
            {
                Facturas factura = new Facturas();
                Facturas facturaActualizada = new Facturas
                {
                    idFactura = idFactura,
                    idCliente = idCliente,
                    idAuto = idAuto,
                    idEmpleado = idEmpleado,
                    fecha = fecha,
                    subtotal = subtotal,
                    IVA = iva,
                    total = total
                };

                factura.ActualizarFactura(facturaActualizada);
                ViewBag.exito = 1;
                ViewBag.facturas = factura.VerTodasLasFacturas();
            }
            catch
            {
                ViewBag.exito = 0;
            }
            return View("listaFacturas");
        }



        public IActionResult EliminarFactura(int idFactura)
        {
            try
            {
                Facturas factura = new Facturas();
                factura.EliminarFactura(idFactura);

                ViewBag.exito = 1;
            }
            catch (Exception ex)
            {
                ViewBag.exito = 0;
                ViewBag.errorMensaje = ex.Message;
            }

            return RedirectToAction("listaFacturas");
        }





        //===============================================================================



        //==========================CONTROLER Clientes==================================
        public IActionResult listadoClientes()
        {
            Clientes conexion = new Clientes();
            ViewBag.Clientes = conexion.listarClientes();

            // Verifica si la lista es null y crea una lista vacía en caso de serlo
            if (ViewBag.Clientes == null)
            {
                ViewBag.Clientes = new List<Clientes>();
            }

            return View("verCliente");
        }



        public IActionResult editarCliente(int id)
        {
            Clientes conexion = new Clientes();
            ViewBag.datosCliente = conexion.listarCliente(id).FirstOrDefault();
            ViewBag.Clientes = conexion.listarClientes();
            return View("editarCliente");
        }


        public IActionResult eliminando(int idcliente)
        {
            try
            {
                Clientes objConexion = new Clientes();

                objConexion.eliminar(idcliente);
                ViewBag.Clientes = objConexion.listarClientes();
                ViewBag.exito = 1;
            }
            catch (Exception ex)
            {
                ViewBag.exito = 0;
            }
            return View("verCliente");
        }

        public IActionResult editando(string Direccion, string DUI, string Email, string Nombre, string Telefono, int idcliente)
        {
            try
            {
                Clientes conexion = new Clientes();
                conexion.editar(Direccion, DUI, Email, Nombre, Telefono, idcliente);
                ViewBag.exito = 1;
            }
            catch (Exception ex)
            {
                ViewBag.exito = 0;
            }

            return RedirectToAction("verCliente");
        }


        public IActionResult Crear(string Direccion, string DUI, string Email, string Nombre, string Telefono)
        {
            try
            {
                // Crear objeto de conexión
                Clientes conexion = new Clientes();

                // Llamar a la función para agregar la nota (INSERT)
                conexion.agregar(Direccion, DUI, Email, Nombre, Telefono);

                // Si todo sale bien, mostrar un mensaje de éxito
                ViewBag.exito = 1;
                ViewBag.clientes = conexion.listarClientes();
            }
            catch (Exception ex)
            {
                // Si ocurre un error, mostrar mensaje de error
                ViewBag.exito = 0;
            }

            // Regresar a la vista 'Agregar' (si quieres redirigir a otra vista, puedes cambiar esto)
            return View("verCliente");
        }

        public IActionResult agregar()
        {
            return View("agregarCliente");
        }

        public IActionResult verCliente()
        {
            Clientes conexion = new Clientes();
            ViewBag.Clientes = conexion.listarClientes();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
