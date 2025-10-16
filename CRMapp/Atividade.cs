namespace CRMApp
{
    internal class Atividade
    {
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public Cliente ClienteRelacionado { get; set; }

        public Atividade(string tipo, string descricao, Cliente cliente)
        {
            Tipo = tipo;
            Descricao = descricao;
            ClienteRelacionado = cliente;
        }

        public override string ToString()
        {
            return $"{Tipo} - {Descricao} - Cliente: {ClienteRelacionado.Nome}";
        }
    }
}
