using System;
using System.Collections.Generic;

namespace CRMApp
{
    internal class CRM
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Oportunidade> oportunidades = new List<Oportunidade>();
        private List<Atividade> atividades = new List<Atividade>();

        public void CadastrarCliente()
        {
            Console.WriteLine("=== Cadastro de Cliente ===");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            clientes.Add(new Cliente(nome, email, telefone));
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void ListarClientes()
        {
            Console.WriteLine("=== Lista de Clientes ===");
            foreach (var c in clientes)
                Console.WriteLine(c);
        }

        public void RegistrarOportunidade()
        {
            Console.WriteLine("=== Registrar Oportunidade ===");
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Valor estimado: ");
            decimal valor = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Cliente relacionado: ");
            string nomeCliente = Console.ReadLine();

            var cliente = clientes.Find(c => c.Nome == nomeCliente);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                return;
            }

            oportunidades.Add(new Oportunidade(descricao, valor, cliente));
            Console.WriteLine("Oportunidade registrada com sucesso!");
        }

        public void ListarOportunidades()
        {
            Console.WriteLine("=== Lista de Oportunidades ===");
            foreach (var o in oportunidades)
                Console.WriteLine(o);
        }

        public void RegistrarAtividade()
        {
            Console.WriteLine("=== Registrar Atividade ===");
            Console.Write("Tipo (Ligação/Reunião/E-mail): ");
            string tipo = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();
            Console.Write("Cliente: ");
            string nomeCliente = Console.ReadLine();

            var cliente = clientes.Find(c => c.Nome == nomeCliente);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                return;
            }

            atividades.Add(new Atividade(tipo, descricao, cliente));
            Console.WriteLine("Atividade registrada com sucesso!");
        }

        public void ListarAtividades()
        {
            Console.WriteLine("=== Lista de Atividades ===");
            foreach (var a in atividades)
                Console.WriteLine(a);
        }
    }
}
