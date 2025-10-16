namespace CRMApp
{
    internal class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Cliente(string nome, string email, string telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public override string ToString()
        {
            return $"{Nome} - {Email} - {Telefone}";
        }
    }
}
