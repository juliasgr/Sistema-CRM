using System;
using System.Text.RegularExpressions;

namespace CRMApp
{
    public static class Validador
    {
        public static bool ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return false;

            return Regex.IsMatch(nome, @"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$");
        }

        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return false;

            return Regex.IsMatch(telefone, @"^\d{11}$");
        }

        public static bool ValidarDocumento(string documento)
        {
            if (string.IsNullOrWhiteSpace(documento))
                return false;

            // CPF = 11 dígitos | CNPJ = 14 dígitos
            return Regex.IsMatch(documento, @"^\d{11}$") || Regex.IsMatch(documento, @"^\d{14}$");
        }
    }
}
