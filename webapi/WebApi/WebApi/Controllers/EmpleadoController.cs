using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        public IHttpActionResult List()
        {

            IList<empleado> milista;
            using (pruebaEntities db = new pruebaEntities())
            {

                //milista = (from d in db.empleado
                //           select new empleado
                //           {
                //               id = d.id,
                //               nombre = d.nombre,
                //               edad = d.edad
                //           }).ToList();

                milista = db.empleado.ToList();

            }

            return Ok(milista);

        }

        [HttpGet]
        public IHttpActionResult List_Item(int id)
        {

            empleado oempleado = new empleado();

            using (pruebaEntities db = new pruebaEntities())
            {
                
                var otabla = db.empleado.Find(id);
                oempleado.id = otabla.id;
                oempleado.nombre = otabla.nombre;
                oempleado.edad = otabla.edad;                

            }

            return Ok(oempleado);

        }

        [HttpPost]
        public IHttpActionResult Add(empleadorequest model) {

            using (pruebaEntities db = new pruebaEntities()) {

                var otabla = new empleado();
                otabla.nombre = model.nombre;
                otabla.edad = model.edad;

                db.empleado.Add(otabla);
                db.SaveChanges();

            }

            return Ok("Exito");

        }

        [HttpPut]
        public IHttpActionResult Edit(int id , empleadorequest model)
        {

            using (pruebaEntities db = new pruebaEntities())
            {

                var otabla = db.empleado.Find(id);
                otabla.nombre = model.nombre;
                otabla.edad = model.edad;

                db.Entry(otabla).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Ok("Exito");

        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            using (pruebaEntities db = new pruebaEntities())
            {

                var otabla = db.empleado.Find(id);
                db.empleado.Remove(otabla);
                db.SaveChanges();

            }

            return Ok("Exito");

        }

    }
}
