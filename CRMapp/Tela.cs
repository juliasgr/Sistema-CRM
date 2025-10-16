using System;

namespace CRMApp
{
    internal class Tela
    {
        public static void ExibirMenuPrincipal()
        {
            CRM crm = new CRM();
            int opcao = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE CRM ===");
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Listar Clientes");
                Console.WriteLine("3 - Registrar Oportunidade");
                Console.WriteLine("4 - Listar Oportunidades");
                Console.WriteLine("5 - Registrar Atividade");
                Console.WriteLine("6 - Listar Atividades");
                Console.WriteLine("0 - Sair");
                Console.Write("Escolha uma opção: ");
                
                int.TryParse(Console.ReadLine(), out opcao);
                Console.Clear();

                switch (opcao)
                {
                    case 1:
                        crm.CadastrarCliente();
                        break;
                    case 2:
                        crm.ListarClientes();
                        break;
                    case 3:
                        crm.RegistrarOportunidade();
                        break;
                    case 4:
                        crm.ListarOportunidades();
                        break;
                    case 5:
                        crm.RegistrarAtividade();
                        break;
                    case 6:
                        crm.ListarAtividades();
                        break;
                    case 0:
                        Console.WriteLine("Encerrando o sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            } while (opcao != 0);
        }
    }
}
