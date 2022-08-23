using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.WebServices;

namespace MVCCrud.Controllers
{
    public class EmpleadoController : Controller
    {

        string urlbase = "https://localhost:44332/";
        string urlget = "api/Empleado";
        string urlpost = "api/Empleado/";

        serviceempleado serviceempleado;

        public EmpleadoController() {

            serviceempleado= new serviceempleado();

        }
        // GET: Empleado
        public async Task<ActionResult> Index()
        {
            List<empleado> lista;
            lista =  await serviceempleado.Lista(urlbase, urlget);
            return View(lista);
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            empleado empleado = new empleado();
            return View(empleado);
        }

        // POST: Empleado/Create
        [HttpPost]
        public ActionResult Create(empleado model)
        {

            string resultado = "";

            try
            {

                resultado = serviceempleado.Add<empleado>(urlbase+urlpost, model);

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleado/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            empleado model = new empleado();
            model = await serviceempleado.Lista_Item(id, urlbase, urlget);
            return View(model);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, empleado model)
        {
            string mensaje = "";

            try
            {                
                mensaje = serviceempleado.Editar<empleado>( urlbase + urlpost, id , model);
               
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
