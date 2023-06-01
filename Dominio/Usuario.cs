using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasSenderismo.Dominio
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public int Telefono { get; set; }
        public string Foto { get; set; }
        public string UserName { get; set; }

        public Usuario(string nombre, string apellidos, string correoElectronico, int telefono, string foto, string userName)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            CorreoElectronico = correoElectronico;
            Telefono = telefono;
            Foto = foto;
            UserName = userName;
        }
    }
}






