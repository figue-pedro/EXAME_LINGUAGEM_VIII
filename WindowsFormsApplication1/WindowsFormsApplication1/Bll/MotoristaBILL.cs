using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Dal;
using WindowsFormsApplication1;
using WindowsFormsApplication1.Model;

namespace WindowsFormsApplication1.Bll
{
    class MotoristaBILL
    {
        MotoristaDAL dal = new MotoristaDAL();

        public void Salvar(Motorista m)
        {
            dal.Inserir(m);
        }

        public List<Motorista> Listar()
        {
            return dal.Listar();
        }

        public void Actualizar(Motorista m)
        {
            dal.Actualizar(m);
        }

        public void Eliminar(int id)
        {
            dal.Eliminar(id);
        }
    }
}
