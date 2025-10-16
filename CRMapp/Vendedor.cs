namespace CRMApp
{
    internal class Vendedor
    {
        public string Nome { get; set; }
        public string Email { get; set; }

        public Vendedor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public override string ToString()
        {
            return $"{Nome} - {Email}";
        }
    }
}
