using System;

namespace CRMApp
{
    public class Atividade
    {
        private static int contador = 1;
        public int Id { get; set; }
        public string Tipo { get; set; } 
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Cliente ClienteRelacionado { get; set; }

        public Atividade(string tipo, string descricao, DateTime data, Cliente cliente)
        {
            Id = contador++;
            Tipo = tipo;
            Descricao = descricao;
            Data = data;
            ClienteRelacionado = cliente;
        }

        public override string ToString()
        {
            return $"ID: {Id} | {Data:g} | {Tipo} | Cliente: {ClienteRelacionado.Nome} | {Descricao}";
        }
    }
}
