using GestaoEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoEquipamentos.ConsoleApp.ModuloChamado
{
    public class RepositorioChamado
    {
        private Chamado[] chamados = new Chamado[100];

        public void CadastrarChamado(Chamado novoChamado)
        {
            novoChamado.Id = GeradorId.GerarIdChamado();

            RegistrarItem(novoChamado);
        }

        public bool EditarChamado(int id, Chamado novoChamado)
        {
            novoChamado.Id = id;

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null)
                    continue;

                else if (chamados[i].Id == id)
                {
                    chamados[i] = novoChamado;

                    return true;
                }
            }

            return false;
        }

        public bool ExcluirChamado(int id)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null)
                    continue;

                else if (chamados[i].Id == id)
                {
                    chamados[i] = null;
                    return true;
                }
            }

            return false;
        }

        public Chamado[] SelecionarChamados()
        {
            return chamados;
        }

        public bool ExisteChamado(int id)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado e = chamados[i];

                if (e == null)
                    continue;

                else if (e.Id == id)
                    return true;
            }

            return false;
        }

        private void RegistrarItem(Chamado equipamento)
        {
            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] != null)
                    continue;

                else
                {
                    chamados[i] = equipamento;
                    break;
                }
            }
        }

    }
}
