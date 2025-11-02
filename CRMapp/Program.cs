using System;
using System.Globalization;

namespace CRMApp
{
    class Program
    {
        static void Main()
        {
            CRM crm = new CRM();
            int opcaoMain;

            do
            {
                Tela.MenuPrincipal();
                _ = int.TryParse(Console.ReadLine(), out opcaoMain);
                Console.Clear();

                switch (opcaoMain)
                {
                    case 1:
                        MenuCliente(crm);
                        break;
                    case 2:
                        MenuOportunidade(crm);
                        break;
                    case 3:
                        MenuAtividade(crm);
                        break;
                    case 4:
                        Console.WriteLine("Encerrando...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcaoMain != 4);
        }
        static void MenuCliente(CRM crm)
        {
            int op;
            do
            {
                Tela.MenuCRUD("CLIENTE");
                _ = int.TryParse(Console.ReadLine(), out op);
                Console.Clear();

                switch (op)
                {
                    case 1:
                        CadastrarCliente(crm);
                        break;
                    case 2:
                        crm.ListarClientes();
                        break;
                    case 3:
                        EditarClienteFlow(crm);
                        break;
                    case 4:
                        Console.Write("CPF do cliente para remover: ");
                        var cpfRem = Console.ReadLine() ?? "";
                        crm.RemoverCliente(cpfRem);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (op != 0);
        }

        static void CadastrarCliente(CRM crm)
        {
            string nome, email, telefone, cpf;

            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine() ?? "";
                if (!Validador.ValidarNome(nome)) Console.WriteLine("Nome inválido! Use apenas letras e espaços.");
            } while (!Validador.ValidarNome(nome));

            do
            {
                Console.Write("E-mail: ");
                email = Console.ReadLine() ?? "";
                if (!Validador.ValidarEmail(email)) Console.WriteLine("E-mail inválido! Use o formato exemplo@dominio.com.");
            } while (!Validador.ValidarEmail(email));

            do
            {
                Console.Write("Telefone (11 dígitos): ");
                telefone = Console.ReadLine() ?? "";
                if (!Validador.ValidarTelefone(telefone)) Console.WriteLine("Telefone inválido! Deve conter 11 números.");
            } while (!Validador.ValidarTelefone(telefone));

            do
            {
                Console.Write("CPF (11 dígitos): ");
                cpf = Console.ReadLine() ?? "";
                if (!Validador.ValidarCPF(cpf)) Console.WriteLine("CPF inválido! Deve conter 11 números.");
            } while (!Validador.ValidarCPF(cpf));

            crm.AdicionarCliente(new Cliente(nome, email, telefone, cpf));
        }

        static void EditarClienteFlow(CRM crm)
        {
            Console.Write("CPF do cliente para editar: ");
            string cpf = Console.ReadLine() ?? "";
            var cliente = crm.BuscarCliente(cpf);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                return;
            }

            Console.WriteLine("Deixe em branco para manter o valor atual.");
            Console.Write($"Nome ({cliente.Nome}): ");
            string? nome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nome) && !Validador.ValidarNome(nome))
            {
                Console.WriteLine("Nome inválido! Edição cancelada.");
                return;
            }

            Console.Write($"E-mail ({cliente.Email}): ");
            string? email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email) && !Validador.ValidarEmail(email))
            {
                Console.WriteLine("E-mail inválido! Edição cancelada.");
                return;
            }

            Console.Write($"Telefone ({cliente.Telefone}): ");
            string? telefone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(telefone) && !Validador.ValidarTelefone(telefone))
            {
                Console.WriteLine("Telefone inválido! Edição cancelada.");
                return;
            }

            crm.EditarCliente(cpf, string.IsNullOrWhiteSpace(nome) ? null : nome, string.IsNullOrWhiteSpace(email) ? null : email, string.IsNullOrWhiteSpace(telefone) ? null : telefone);
        }

        static void MenuOportunidade(CRM crm)
        {
            int op;
            do
            {
                Tela.MenuCRUD("OPORTUNIDADE");
                _ = int.TryParse(Console.ReadLine(), out op);
                Console.Clear();

                switch (op)
                {
                    case 1:
                        CadastrarOportunidade(crm);
                        break;
                    case 2:
                        crm.ListarOportunidades();
                        break;
                    case 3:
                        EditarOportunidadeFlow(crm);
                        break;
                    case 4:
                        Console.Write("ID da oportunidade para remover: ");
                        _ = int.TryParse(Console.ReadLine(), out int idRem);
                        crm.RemoverOportunidade(idRem);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (op != 0);
        }

        static void CadastrarOportunidade(CRM crm)
        {
            Console.Write("CPF do cliente vinculado: ");
            string cpfCli = Console.ReadLine() ?? "";
            var cliente = crm.BuscarCliente(cpfCli);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                return;
            }

            Console.Write("Descrição: ");
            string desc = Console.ReadLine() ?? "";

            double valor;
            do
            {
                Console.Write("Valor estimado (maior que 0): ");
                var raw = Console.ReadLine() ?? "";
                if (!double.TryParse(raw, NumberStyles.Any, CultureInfo.InvariantCulture, out valor) || valor <= 0)
                    Console.WriteLine("Valor inválido. Informe um número maior que zero.");
                else break;
            } while (true);

            string estagio;
            do
            {
                Console.Write("Estágio (Quente/Morno/Frio): ");
                estagio = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(estagio) ||
                    !(estagio.Equals("Quente", StringComparison.OrdinalIgnoreCase) ||
                      estagio.Equals("Morno", StringComparison.OrdinalIgnoreCase) ||
                      estagio.Equals("Frio", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Estágio inválido. Use Quente, Morno ou Frio.");
                }
                else break;
            } while (true);

            crm.AdicionarOportunidade(new Oportunidade(desc, valor, estagio, cliente));
        }

        static void EditarOportunidadeFlow(CRM crm)
        {
            Console.Write("ID da oportunidade para editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            var o = crm.Oportunidades.FirstOrDefault(x => x.Id == id);
            if (o == null) { Console.WriteLine("Oportunidade não encontrada."); return; }

            Console.WriteLine("Deixe em branco para manter o valor atual.");
            Console.Write($"Descrição ({o.Descricao}): ");
            string? desc = Console.ReadLine();

            Console.Write($"Valor ({o.ValorEstimado}): ");
            string? rawValor = Console.ReadLine();
            double? novoValor = null;
            if (!string.IsNullOrWhiteSpace(rawValor))
            {
                if (!double.TryParse(rawValor, NumberStyles.Any, CultureInfo.InvariantCulture, out double valParsed) || valParsed <= 0)
                {
                    Console.WriteLine("Valor inválido. Edição cancelada para o valor.");
                }
                else novoValor = valParsed;
            }

            Console.Write($"Estágio ({o.Estagio}): ");
            string? est = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(est) &&
                !(est.Equals("Quente", StringComparison.OrdinalIgnoreCase) ||
                  est.Equals("Morno", StringComparison.OrdinalIgnoreCase) ||
                  est.Equals("Frio", StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Estágio inválido. Edição cancelada para estágio.");
                est = null;
            }

            crm.EditarOportunidade(id, string.IsNullOrWhiteSpace(desc) ? null : desc, novoValor, string.IsNullOrWhiteSpace(est) ? null : est);
        }

        static void MenuAtividade(CRM crm)
        {
            int op;
            do
            {
                Tela.MenuCRUD("ATIVIDADE");
                _ = int.TryParse(Console.ReadLine(), out op);
                Console.Clear();

                switch (op)
                {
                    case 1:
                        CadastrarAtividade(crm);
                        break;
                    case 2:
                        crm.ListarAtividades();
                        break;
                    case 3:
                        EditarAtividadeFlow(crm);
                        break;
                    case 4:
                        Console.Write("ID da atividade para remover: ");
                        _ = int.TryParse(Console.ReadLine(), out int idRem);
                        crm.RemoverAtividade(idRem);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (op != 0);
        }

        static void CadastrarAtividade(CRM crm)
        {
            Console.Write("CPF do cliente vinculado: ");
            string cpf = Console.ReadLine() ?? "";
            var cliente = crm.BuscarCliente(cpf);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado!");
                return;
            }

            Console.Write("Tipo (Reunião/Ligação/E-mail/Follow-up): ");
            string tipo = Console.ReadLine() ?? "";

            Console.Write("Descrição: ");
            string desc = Console.ReadLine() ?? "";

            DateTime data;
            Console.Write("Data e hora (yyyy-MM-dd HH:mm) ou deixe em branco para agora: ");
            string raw = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(raw))
            {
                data = DateTime.Now;
            }
            else
            {
                if (!DateTime.TryParseExact(raw, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
                {
                    Console.WriteLine("Formato de data inválido. Usando data/hora atual.");
                    data = DateTime.Now;
                }
            }

            crm.AdicionarAtividade(new Atividade(tipo, desc, data, cliente));
        }

        static void EditarAtividadeFlow(CRM crm)
        {
            Console.Write("ID da atividade para editar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            var a = crm.Atividades.FirstOrDefault(x => x.Id == id);
            if (a == null) { Console.WriteLine("Atividade não encontrada."); return; }

            Console.WriteLine("Deixe em branco para manter o valor atual.");
            Console.Write($"Tipo ({a.Tipo}): ");
            string? tipo = Console.ReadLine();
            Console.Write($"Descrição ({a.Descricao}): ");
            string? desc = Console.ReadLine();
            Console.Write($"Data ({a.Data:yyyy-MM-dd HH:mm}): ");
            string? raw = Console.ReadLine();
            DateTime? novaData = null;
            if (!string.IsNullOrWhiteSpace(raw))
            {
                if (DateTime.TryParseExact(raw, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsed))
                    novaData = parsed;
                else
                    Console.WriteLine("Formato de data inválido. Mantendo data atual.");
            }

            crm.EditarAtividade(id, string.IsNullOrWhiteSpace(tipo) ? null : tipo, string.IsNullOrWhiteSpace(desc) ? null : desc, novaData);
        }
    }
}
