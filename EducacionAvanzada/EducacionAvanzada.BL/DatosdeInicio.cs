using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducacionAvanzada.BL
{
   public class DatosdeInicio:CreateDatabaseIfNotExists<Contexto>
    {
        protected override void Seed(Contexto contexto)
        {

            var nuevoUsuario = new Usuario();

            nuevoUsuario.Nombre = "Edgar";

            nuevoUsuario.Contrasena = SeguridaBL.Encriptar.CodificarContrasena("1234");


            contexto.Usuarios.Add(nuevoUsuario);
            base.Seed(contexto);
        }


    }
}

