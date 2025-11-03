namespace CRMApp
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Documento { get; set; } // CPF ou CNPJ

        public Cliente(string nome, string email, string telefone, string documento)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Documento = documento;
        }

        public override string ToString()
        {
            return $"Nome: {Nome} | E-mail: {Email} | Telefone: {Telefone} | Documento: {Documento}";
        }
    }
}
