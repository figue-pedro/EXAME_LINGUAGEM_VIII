using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Model;
using WindowsFormsApplication1.Dal;

namespace WindowsFormsApplication1.Bll
{
    class veiculo
    {
        VeiculoDal dal = new VeiculoDal();

        public void Salvar(VeiculoModel v)
        {
            dal.Inserir(v);
        }

        public List<VeiculoModel> Listar()
        {
            return dal.Listar();
        }

        public void Actualizar(VeiculoModel v)
        {
            dal.Actualizar(v);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
    }
    
}
