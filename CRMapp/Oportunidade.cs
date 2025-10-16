namespace CRMApp
{
    internal class Oportunidade
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public Cliente ClienteRelacionado { get; set; }

        public Oportunidade(string descricao, decimal valor, Cliente cliente)
        {
            Descricao = descricao;
            Valor = valor;
            ClienteRelacionado = cliente;
        }

        public override string ToString()
        {
            return $"{Descricao} - R${Valor} - Cliente: {ClienteRelacionado.Nome}";
        }
    }
}
