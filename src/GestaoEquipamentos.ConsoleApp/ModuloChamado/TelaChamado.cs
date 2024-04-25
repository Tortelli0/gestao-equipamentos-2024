using GestaoEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado
    {
        RepositorioChamado repositorioChamado = new RepositorioChamado();

        public TelaEquipamento telaEquipamento = null;

        public char ApresentarMenu()
        {
            Console.Clear();

            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");

            Console.WriteLine("1 - Cadastrar Chamado");
            Console.WriteLine("2 - Editar Chamado");
            Console.WriteLine("3 - Excluir Chamado");
            Console.WriteLine("4 - Visualizar Chamados");
            Console.WriteLine("S - Voltar\n");

            Console.Write("Escolha uma das opções: ");
            char opcao = char.Parse(Console.ReadLine());

            return opcao;
        }

        public void CadastrarChamado()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");

            Console.WriteLine("Cadastrando chamado...");

            Chamado novoChamado = ObterChamado();

            repositorioChamado.CadastrarChamado(novoChamado);

            Program.ExibirMensagem("O chamado foi cadastrado com sucesso", ConsoleColor.Green);
        }

        public void EditarChamado()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");

            Console.WriteLine("Editando chamado...");

            VisualizarChamados(false);

            Console.WriteLine("Digite o ID do chamado que deseja editar: ");
            int idChamadoEscolhido = int.Parse(Console.ReadLine());

            if (!repositorioChamado.ExisteChamado(idChamadoEscolhido))
            {
                Program.ExibirMensagem("O chamado mencionado não existe", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Chamado novoChamado = ObterChamado();

            bool conseguiuEditar = repositorioChamado.EditarChamado(idChamadoEscolhido, novoChamado);

            if (!conseguiuEditar)
            {
                Program.ExibirMensagem("Houve um erro durante a edição de chamado", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O chamado foi editado com sucesso", ConsoleColor.Green);
        }

        public void ExcluirChamado()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");

            Console.WriteLine("Excluindo chamado...");

            VisualizarChamados(false);

            Console.Write("Digite o ID do chamado que deseja excluir: ");
            int idChamadoEscolhido = int.Parse(Console.ReadLine());

            if (!repositorioChamado.ExisteChamado(idChamadoEscolhido))
            {
                Program.ExibirMensagem("O chamado mencionado não existe", ConsoleColor.DarkYellow);
                return;
            }

            bool conseguiuExcluir = repositorioChamado.ExcluirChamado(idChamadoEscolhido);

            if (!conseguiuExcluir)
            {
                Program.ExibirMensagem("Houve um erro durante a exclusão do chamado", ConsoleColor.Red);
                return;
            }

            Program.ExibirMensagem("O chamado foi excluído com sucesso", ConsoleColor.Green);
        }

        private Chamado ObterChamado()
        {
            telaEquipamento.VisualizarEquipamentos(false);

            Console.Write("Digite o ID do equipamento defeituoso: ");
            int idEquipamento = int.Parse(Console.ReadLine());

            Equipamento equipamentoSelecionado = telaEquipamento.repositorio.SelecionarEquipamentoPorId(idEquipamento);

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

            return novoChamado;
        }

        public void VisualizarChamados(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("----------------------\n");

                Console.WriteLine("Visualizando chamado...");
            }

            Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                    "Id", "Título", "Equipamento", "Dias em Aberto");

            Chamado[] chamadosCadastrados = repositorioChamado.SelecionarChamados();

            for (int i = 0; i < chamadosCadastrados.Length; i++)
            {
                Chamado e = chamadosCadastrados[i];

                if (e == null)
                    continue;

                Console.WriteLine("{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                    e.Id, e.Titulo, e.EquipamentoSelecionado.Nome, e.QuantidadeDiasEmAberto);
            }
        }
    }
}
