namespace CRMApp
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }

        public Cliente(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | E-mail: {Email} | Telefone: {Telefone} | CPF: {CPF}";
        }
    }
}
