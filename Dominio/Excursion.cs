using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RutasSenderismo.Dominio
{
    public class Excursión
    {
        public List<string> listRutas { get; set; }

        public Guia guiaExc { get; set; }

        public string NombreExc { get; set; }

        public int contador { get; set; }
        public Excursión(List<string> listrutas, Guia guia, string nombreExc, int cont)
        {
            listRutas = listrutas;
            guiaExc = guia;
            NombreExc = nombreExc;
            contador = cont;
        }
    }
}
