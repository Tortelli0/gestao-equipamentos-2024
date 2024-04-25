namespace GestaoEquipamentos.ConsoleApp.Compartilhado
{
    public static class GeradorId
    {
        private static int IdEquipamentos = 0;
        private static int IdChamados = 0;

        public static int GerarIdEquipamento()
        {
            return ++IdEquipamentos;
        }

        public static int GerarIdChamado()
        {
            return ++IdChamados;
        }
    }
}