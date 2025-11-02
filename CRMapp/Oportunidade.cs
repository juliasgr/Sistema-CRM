namespace CRMApp
{
    public class Oportunidade
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double ValorEstimado { get; set; }
        public string Estagio { get; set; } 
        public Cliente ClienteRelacionado { get; set; }

        public Oportunidade(string descricao, double valor, string estagio, Cliente cliente)
        {
            Id = contador++;
            Descricao = descricao;
            ValorEstimado = valor;
            Estagio = estagio;
            ClienteRelacionado = cliente;
        }

        public override string ToString()
        {
            return $"ID: {Id} | Cliente: {ClienteRelacionado.Nome} | Descrição: {Descricao} | Valor: R${ValorEstimado:F2} | Estágio: {Estagio}";
        }
    }
}
