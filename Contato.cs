using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20240606
{
    public class Contato
    {
        public int id;
        public string nome;
        public string telefone;

        public Contato(int id, string nome, string telefone)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
        }
    }
}
