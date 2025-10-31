using System.Text.RegularExpressions;

namespace CRMApp
{
    public static class Validador
    {
        public static bool ValidarNome(string? nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;
            // letras (inclui acentos) e espaços
            return Regex.IsMatch(nome, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$");
        }

        public static bool ValidarEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool ValidarTelefone(string? telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;
            return Regex.IsMatch(telefone, @"^\d{11}$");
        }

        public static bool ValidarCPF(string? cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;
            return Regex.IsMatch(cpf, @"^\d{11}$");
        }
    }
}
