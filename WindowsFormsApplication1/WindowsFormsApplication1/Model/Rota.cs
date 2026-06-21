using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    class Rota
    {
        public int IdRota { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public double Distancia { get; set; }

        public string TempoEstimado { get; set; }
    }
}
