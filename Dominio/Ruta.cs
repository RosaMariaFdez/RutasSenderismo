using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasSenderismo.Dominio
{
    public class Ruta
    {
        public string Nombre { get; set; }
        public string Informacion { get; set; }
        public string Dificultad { get; set; }
        public int DuracionHoras { get; set; }
        public int DistanciaKm { get; set; }
        public Uri Imagen { get; set; }

        public Ruta(string nombre, string informacion, string dificultad, int duracionHoras, int distanciaKm, Uri imagen)
        {
            Nombre = nombre;
            Informacion = informacion;
            Dificultad = dificultad;
            DuracionHoras = duracionHoras;
            DistanciaKm = distanciaKm;
            Imagen = imagen;    
        }
    }//voy a asesinar a alguien como esto vuelva a borrarse
}
