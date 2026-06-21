using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Model
{
    class Viagem
    {
        public int IdViagem { get; set; }

        public int IdVeiculo { get; set; }

        public int IdMotorista { get; set; }

        public int IdRota { get; set; }

        public DateTime DataViagem { get; set; }

        public double PrecoCombustivel { get; set; }

        public double CustoTotal { get; set; }

    }
}
