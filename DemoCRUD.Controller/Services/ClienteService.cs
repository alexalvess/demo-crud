using DemoCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Controller.Services
{
    public class ClienteService : BaseService<Cliente>
    {
        public int InserirComValidacao(Cliente obj)
        {
            if (obj.DataNascimento > DateTime.Now)
                throw new Exception("Data de nascimento inválida!");

            return Inserir(obj);
        }
    }
}
