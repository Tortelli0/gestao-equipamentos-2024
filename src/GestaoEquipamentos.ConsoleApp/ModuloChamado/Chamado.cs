using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class Chamado
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        private DateTime dataAbertura;
        public Equipamento EquipamentoSelecionado;

        public int QuantidadeDiasEmAberto
        {
            get
            {
                DateTime dataHoje = DateTime.Now;

                TimeSpan diferenca = dataHoje.Subtract(dataAbertura);

                int diferencaNumero = diferenca.Days;

                return diferencaNumero;
            }
        }

        public Chamado(string descricao, string titulo, Equipamento equipamentoSelecionado)
        {
            EquipamentoSelecionado = equipamentoSelecionado;
            Descricao = descricao;
            dataAbertura = DateTime.Now;
            Titulo = titulo;
        }
    }
}
