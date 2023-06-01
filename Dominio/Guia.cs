using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasSenderismo.Dominio
{

    public class Guia
    {
        public string NombreGuia { get; set; }
        public string Apellidos { get; set; }
        public string Idiomas { get; set; }
        public string Restricciones { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string RutasRealizadas { get; set; }
        public string RutasPorRealizar { get; set; }
        public int Puntuacion { get; set; }
        public Uri Imagen { get; set; }

        public Guia(string nombreGuia, string apellidos, string idiomas, string restricciones, string telefono, string email, string rutasRealizadas, string rutasPorRealizar, int puntuacion, Uri imagen)
        {
            NombreGuia = nombreGuia;
            Apellidos = apellidos;
            Idiomas = idiomas;
            Restricciones = restricciones;
            Email = email;
            RutasRealizadas = rutasRealizadas;
            RutasPorRealizar = rutasPorRealizar;
            Puntuacion = puntuacion;
            Imagen = imagen;
        }
        public Guia() { }

    }
}

