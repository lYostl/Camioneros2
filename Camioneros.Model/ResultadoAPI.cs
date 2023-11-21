using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camioneros.Model
{
    public class ResultadoAPI
    {
        public string mensaje { get; set; }
        public List<Camion> listaCamion { get; set; }
        public List<Camionero> listaCamionero { get; set; }
        public Camion objeto { get; set; }
        public Camionero objeto2 { get; set; }
    }
}
