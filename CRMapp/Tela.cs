using System;

namespace CRMApp
{
    public static class Tela
    {
        public static void MenuPrincipal()
        {
            Console.WriteLine("\n=== SISTEMA CRM ===");
            Console.WriteLine("1 - Cliente");
            Console.WriteLine("2 - Oportunidade");
            Console.WriteLine("3 - Atividade");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha: ");
        }

        public static void MenuCRUD(string titulo)
        {
            Console.WriteLine($"\n--- {titulo} ---");
            Console.WriteLine("1 - Adicionar");
            Console.WriteLine("2 - Listar");
            Console.WriteLine("3 - Editar");
            Console.WriteLine("4 - Remover");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: ");
        }
    }
}
