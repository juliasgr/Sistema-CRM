using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMApp
{
    public class CRM
    {
        public List<Cliente> Clientes { get; set; } = new();
        public List<Oportunidade> Oportunidades { get; set; } = new();
        public List<Atividade> Atividades { get; set; } = new();

        // ======= CLIENTES =======
        public void AdicionarCliente(Cliente c)
        {
            if (Clientes.Any(x => x.CPF == c.CPF))
            {
                Console.WriteLine("❌ Já existe um cliente com esse CPF!");
                return;
            }
            Clientes.Add(c);
            Console.WriteLine("✅ Cliente adicionado com sucesso!");
        }

        public void ListarClientes()
        {
            if (!Clientes.Any())
            {
                Console.WriteLine("Nenhum cliente cadastrado.");
                return;
            }
            Console.WriteLine("\n--- Clientes ---");
            foreach (var c in Clientes) Console.WriteLine(c);
        }

        public Cliente? BuscarCliente(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf)) return null;
            return Clientes.FirstOrDefault(x => x.CPF == cpf);
        }

        public void EditarCliente(string cpf, string? novoNome, string? novoEmail, string? novoTelefone)
        {
            var c = BuscarCliente(cpf);
            if (c == null)
            {
                Console.WriteLine("❌ Cliente não encontrado!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(novoNome))
                c.Nome = novoNome;
            if (!string.IsNullOrWhiteSpace(novoEmail))
                c.Email = novoEmail;
            if (!string.IsNullOrWhiteSpace(novoTelefone))
                c.Telefone = novoTelefone;

            Console.WriteLine("✅ Cliente atualizado!");
        }

        public void RemoverCliente(string cpf)
        {
            var c = BuscarCliente(cpf);
            if (c == null)
            {
                Console.WriteLine("❌ Cliente não encontrado!");
                return;
            }

            // remover também oportunidades e atividades ligadas
            Oportunidades.RemoveAll(o => o.ClienteRelacionado.CPF == cpf);
            Atividades.RemoveAll(a => a.ClienteRelacionado.CPF == cpf);
            Clientes.Remove(c);
            Console.WriteLine("🗑️ Cliente e registros vinculados removidos.");
        }

        // ======= OPORTUNIDADES =======
        public void AdicionarOportunidade(Oportunidade o)
        {
            if (o.ValorEstimado <= 0)
            {
                Console.WriteLine("❌ Valor da oportunidade precisa ser maior que zero!");
                return;
            }
            Oportunidades.Add(o);
            Console.WriteLine("✅ Oportunidade adicionada!");
        }

        public void ListarOportunidades()
        {
            if (!Oportunidades.Any())
            {
                Console.WriteLine("Nenhuma oportunidade registrada.");
                return;
            }
            Console.WriteLine("\n--- Oportunidades ---");
            foreach (var o in Oportunidades) Console.WriteLine(o);
        }

        public void FiltrarOportunidadesPorEstagio(string estagio)
        {
            if (string.IsNullOrWhiteSpace(estagio))
            {
                Console.WriteLine("Estágio inválido.");
                return;
            }
            var filtradas = Oportunidades
                .Where(x => x.Estagio.Equals(estagio, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!filtradas.Any())
            {
                Console.WriteLine($"Nenhuma oportunidade com estágio '{estagio}'.");
                return;
            }

            Console.WriteLine($"\n--- Oportunidades {estagio.ToUpper()} ---");
            foreach (var o in filtradas) Console.WriteLine(o);
        }

        public void EditarOportunidade(int id, string? novaDesc, double? novoValor, string? novoEstagio)
        {
            var o = Oportunidades.FirstOrDefault(x => x.Id == id);
            if (o == null)
            {
                Console.WriteLine("❌ Oportunidade não encontrada!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(novaDesc)) o.Descricao = novaDesc;
            if (novoValor.HasValue)
            {
                if (novoValor.Value <= 0)
                {
                    Console.WriteLine("❌ O valor precisa ser maior que zero. Edição cancelada para o valor.");
                }
                else o.ValorEstimado = novoValor.Value;
            }
            if (!string.IsNullOrWhiteSpace(novoEstagio)) o.Estagio = novoEstagio;

            Console.WriteLine("✅ Oportunidade atualizada!");
        }

        public void RemoverOportunidade(int id)
        {
            var o = Oportunidades.FirstOrDefault(x => x.Id == id);
            if (o == null)
            {
                Console.WriteLine("❌ Oportunidade não encontrada!");
                return;
            }
            Oportunidades.Remove(o);
            Console.WriteLine("🗑️ Oportunidade removida!");
        }

        // ======= ATIVIDADES =======
        public void AdicionarAtividade(Atividade a)
        {
            Atividades.Add(a);
            Console.WriteLine("✅ Atividade registrada!");
        }

        public void ListarAtividades()
        {
            if (!Atividades.Any())
            {
                Console.WriteLine("Nenhuma atividade registrada.");
                return;
            }
            Console.WriteLine("\n--- Atividades ---");
            foreach (var a in Atividades) Console.WriteLine(a);
        }

        public void EditarAtividade(int id, string? novoTipo, string? novaDescricao, DateTime? novaData)
        {
            var a = Atividades.FirstOrDefault(x => x.Id == id);
            if (a == null)
            {
                Console.WriteLine("❌ Atividade não encontrada!");
                return;
            }

            if (!string.IsNullOrWhiteSpace(novoTipo)) a.Tipo = novoTipo;
            if (!string.IsNullOrWhiteSpace(novaDescricao)) a.Descricao = novaDescricao;
            if (novaData.HasValue) a.Data = novaData.Value;

            Console.WriteLine("✅ Atividade atualizada!");
        }

        public void RemoverAtividade(int id)
        {
            var a = Atividades.FirstOrDefault(x => x.Id == id);
            if (a == null)
            {
                Console.WriteLine("❌ Atividade não encontrada!");
                return;
            }
            Atividades.Remove(a);
            Console.WriteLine("🗑️ Atividade removida!");
        }
    }
}
