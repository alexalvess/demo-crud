using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCRUD.Model
{
    public class Cliente : BaseClass
    {
        public String Nome { get; set; }

        public String Cpf { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataRegistro { get; set; } = DateTime.Now;
    }
}
