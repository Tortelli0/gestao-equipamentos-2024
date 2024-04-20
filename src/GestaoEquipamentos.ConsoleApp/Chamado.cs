using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestãoEquipamentos
{
    public class Chamado
    {
        public string Descricao;
        public string Prioridade;
        public DateTime DataAbertura;

        public Chamado(string descricao, string prioridade, DateTime dataabertura)
        {
            this.Descricao = Descricao;
            this.Prioridade = prioridade;
            this.DataAbertura = dataabertura;
        }
    }
}
