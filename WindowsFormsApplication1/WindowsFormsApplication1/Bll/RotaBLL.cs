using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Dal;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Bll
{
    class RotaBLL
    {
        RotaDAL dal = new RotaDAL();

        public void Salvar(Rota r)
        {
            dal.Inserir(r);
        }

        public List<Rota> Listar()
        {
            return dal.Listar();
        }

        public void Actualizar(Rota r)
        {
            dal.Actualizar(r);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
    }
    
}
