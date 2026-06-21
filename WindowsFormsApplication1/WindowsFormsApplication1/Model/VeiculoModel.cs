using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    class VeiculoModel
    {
         public int IdVeiculo { get; set; }

        public string Matricula { get; set; }

        public string Tipo { get; set; }

        public double Capacidade { get; set; }

        public double Consumo { get; set; }

        public string Estado { get; set; }
    
    }
}
