using System.Collections.Generic;

namespace CRMApp
{
    public class Vendedor
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public List<Cliente> Clientes { get; set; }
        public List<Atividade> Atividades { get; set; }
        public List<Oportunidade> Oportunidades { get; set; }

        public Vendedor(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Clientes = new List<Cliente>();
            Atividades = new List<Atividade>();
            Oportunidades = new List<Oportunidade>();
        }

        public override string ToString()
        {
            return $"{Nome} ({Email}) - {Clientes.Count} clientes, {Oportunidades.Count} oportunidades";
        }
    }
}
