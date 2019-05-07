using EducacionAvanzada.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EducacionAvanzada.WebAdmin.Controllers
{
    public class loginController : Controller
    {
        SeguridaBL _seguridadBl;
        public loginController()
        {
            _seguridadBl = new SeguridaBL();
        }
        // GET: Login
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();

        }


        [HttpPost]
        public ActionResult Index(FormCollection data)
        {
            var nombreUsuario = data["username"];

            var contrasena = data["password"];

            var usuarioValido = _seguridadBl
                .Autorizar(nombreUsuario, contrasena);


            if (usuarioValido)
            {
                FormsAuthentication.SetAuthCookie(nombreUsuario, true);

                return RedirectToAction("Index", "Home");

            }

            ModelState.AddModelError("", "Error de Autenticacion Vuelva a Intentar");

            return View();
        }


    }

}


