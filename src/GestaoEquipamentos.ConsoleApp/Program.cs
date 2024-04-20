using GestaoEquipamentos.ConsoleApp;
using System.ComponentModel.Design;

namespace GestãoEquipamentos
{
    internal class Program
    {
        static Equipamento[] equipamentos = new Equipamento[100];
        static int contadorEquipamentosCadastrados = 0;

        static void Main(string[] args)
        {
            Equipamento equipTest = new Equipamento("PC", "AXE-210", "Pichau", 2000.00m, DateTime.Now);

            equipTest.Id = GeradorId.GerarIdEquipamento();

            equipamentos[contadorEquipamentosCadastrados++] = equipTest;

            bool opcaoSairEscolhida = false;

            while (!opcaoSairEscolhida)
            {
                Console.WriteLine("\nGestão de Equipamentos");
                Console.WriteLine("----------------------\n");

                Console.WriteLine("1. Gerencia de equipamentos");
                Console.WriteLine("2. Controle de chamados");
                Console.WriteLine("3. Sair\n");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: GerenciarEquipamentos(); break;

                    case 2: GerenciarChamados(); break;

                    default: Console.Write("\nVocê Saiu!"); opcaoSairEscolhida = true; break;
                }
            }
        }

        static void GerenciarEquipamentos()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");

            Console.WriteLine("1 - Cadastrar Equipamento");
            Console.WriteLine("2 - Editar Equipamento");
            Console.WriteLine("3 - Excluir Equipamento");
            Console.WriteLine("4 - Visualizar Equipamentos");
            Console.WriteLine("5 - Voltar");
            char operacaoEscolhida = char.Parse(Console.ReadLine());

            switch (operacaoEscolhida)
            {
                case '1': CadastrarEquipamento(); break;

                case '2': EditarEquipamento(); break;

                case '3': ExcluirEquipamento(); break;

                case '4': VisualizarEquipamentos(true); break;

                default: break;
            }
        }

        public static void CadastrarEquipamento()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número de série do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = decimal.Parse(Console.ReadLine());

            Console.Write("Digite a data de fabricação do qeuipamento (formato: dia/mês/ano): ");
            DateTime dataFabricacao = DateTime.Parse(Console.ReadLine());

            Equipamento equipamento = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);
            equipamento.Id = GeradorId.GerarIdEquipamento();

            equipamentos[contadorEquipamentosCadastrados++] = equipamento;

            ExibirMensagem("O equipamento foi cadastrado com sucesso!\n", ConsoleColor.Green);
        }

        static void VisualizarEquipamentos(bool exibirTitulo)
        {

            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("----------------------\n");

                Console.WriteLine("Visualizando Equipamentos...\n");
            }

            Console.WriteLine("{0, -5} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                              "Id", "Nome", "Fabricante", "Preço", "Data de Fabricação");

            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;


                Console.WriteLine(
                        "{0, -10} | {1, -15} | {2, -15} | {3, -10} | {4, -10}",
                        e.Id, e.Nome, e.Fabricante, e.PrecoAquisicao, e.DataFabricacao.ToShortDateString()
                        );

            }
        }

        public static void GerenciarChamados()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Cadastrando Equipamentos...\n");

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a prioridade do chamado (alta, media, baixa): ");
            string prioridade = Console.ReadLine();

            Chamado chamado = new Chamado(descricao, prioridade, DateTime.Now);

            ExibirMensagem("Chamado cadastrado com sucesso!\n", ConsoleColor.Green);
        }

        public static void ExcluirEquipamento()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Excluindo Equipamentos...\n");

            VisualizarEquipamentos(false);

            Console.Write("\nDigite o ID do equipamento que deseja excluir: ");
            int equipamentoEscolhido = int.Parse(Console.ReadLine());

            if (!EquipamentoExiste(equipamentoEscolhido))
            {
                ExibirMensagem("O equipamento foi excluído com suceso!\n", ConsoleColor.Green);
                return;
            }

            for (int i = 0; i < equipamentos.Length; i++)
            {
                if (equipamentos[i] == null)
                    continue;

                else if (equipamentos[i].Id == equipamentoEscolhido)
                {
                    equipamentos[i] = null;
                    break;
                }
            }

            ExibirMensagem("O equipamento foi excluído com sucesso!\n", ConsoleColor.Green);
        }

        public static bool EquipamentoExiste(int idEquipamento)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                else if (e.Id == idEquipamento)
                    return true;
            }

            return false;
        }

        public static Equipamento EncontrarEquipamentoPorId(int idEscolhido)
        {
            for (int i = 0; i < equipamentos.Length; i++)
            {
                Equipamento e = equipamentos[i];

                if (e == null)
                    continue;

                if (e.Id == idEscolhido)
                    return e;
            }

            return null;
        }

        public static void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine();
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        public static void EditarEquipamento()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("----------------------\n");
            Console.WriteLine("Editando Equipamentos...\n");

            VisualizarEquipamentos(false);

            Console.Write("\nDigite o ID do equipamento que deseja editar: ");
            int idEquipamentoEscolhido = int.Parse(Console.ReadLine());

            if (!EquipamentoExiste(idEquipamentoEscolhido))
            {
                ExibirMensagem("O equipamento mencionado não existe!\n", ConsoleColor.DarkYellow);
                return;
            }

            Console.WriteLine();

            Console.Write("Digite o nome do equipamento: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o número de série do equipamento: ");
            string numeroSerie = Console.ReadLine();

            Console.Write("Digite o nome do fabricante do equipamento: ");
            string fabricante = Console.ReadLine();

            Console.Write("Digite o preço de aquisição do equipamento: R$ ");
            decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Digite a data de fabricação do equipamento (formato: dd-MM-aaaa): ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento novoEquipamento = new Equipamento(nome, numeroSerie, fabricante, precoAquisicao, dataFabricacao);

            novoEquipamento.Id = idEquipamentoEscolhido;

            for (int i = 0; i < equipamentos.Length; i++)
            {

                if (equipamentos[i] == null)
                    continue;

                else if (equipamentos[i].Id == idEquipamentoEscolhido)
                {
                    equipamentos[i] = novoEquipamento;
                    break;


                }

            }

            ExibirMensagem("O equipamento foi editado com sucesso!\n", ConsoleColor.Green);
        }
    }
}
