using System;
using System.Linq;
using System.Collections.Generic;

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

            // ✅ NOVA OPÇÃO ADICIONADA APENAS PARA OPORTUNIDADES
            if (titulo.ToLower().Contains("oportunidade"))
            {
                Console.WriteLine("5 - Filtrar por Estágio (Quente/Morno/Frio)");
            }

            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha: ");
        }

        // ✅ NOVO MÉTODO PARA FILTRAR OPORTUNIDADES POR ESTÁGIO
        public static void FiltrarOportunidades(List<Oportunidade> listaOportunidades)
        {
            if (listaOportunidades == null || listaOportunidades.Count == 0)
            {
                Console.WriteLine("\nNão há oportunidades cadastradas para filtrar.");
                Console.WriteLine("\nPressione qualquer tecla para voltar...");
                Console.ReadKey();
                return;
            }

            Console.Write("\nDigite o estágio para filtrar (Quente/Morno/Frio): ");
            string? filtro = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                Console.WriteLine("\nEntrada inválida. Retornando ao menu...");
                Console.ReadKey();
                return;
            }

            filtro = filtro.Trim().ToLower();

            var filtradas = listaOportunidades
                .Where(o => o.Estagio != null && o.Estagio.ToLower() == filtro)
                .ToList();

            Console.WriteLine($"\n=== Oportunidades com estágio '{filtro.ToUpper()}' ===");

            if (filtradas.Count == 0)
            {
                Console.WriteLine("Nenhuma oportunidade encontrada nesse estágio.");
            }
            else
            {
                foreach (var op in filtradas)
                {
                    Console.WriteLine(op.ToString());
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
    }
}
