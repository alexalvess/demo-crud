using DemoCRUD.Controller.Data;
using DemoCRUD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCRUD.Controller.Services
{
    public class BaseService<T> where T : BaseClass, new()
    {
        public List<T> RecuperarTodos()
        {
            var repository = new Repository<T>();
            return repository.RecuperarTodos();
        }

        public T RecuperarPorId(int id)
        {
            var repository = new Repository<T>();
            return repository.RecuperarPorId(id);
        }

        public bool Deletar(int id)
        {
            var repository = new Repository<T>();
            return repository.Deletar(id);
        }

        public int Inserir(T obj)
        {
            var repository = new Repository<T>();
            return repository.Inserir(obj);
        }

        public bool Alterar(T obj)
        {
            var repository = new Repository<T>();
            return repository.Alterar(obj);
        }
    }
}
