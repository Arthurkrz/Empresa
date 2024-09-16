using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa
{
    class Funcionario
    {
        public string Nome { get; set; }
        public double Despesa { get; set; }
        public Funcionario(string nome)
        {
            this.Nome = nome;
        }
        public Funcionario(string nome, double despesa)
        {
            this.Despesa = despesa;
        }
        public static bool Validar(string nome, int horaTrabalhada, double valorHora)
        {
            if (!string.IsNullOrWhiteSpace(nome) && horaTrabalhada > 0 && valorHora > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual double Calculo(int hora, double precoHora, bool terceirizado)
        {
            return hora * precoHora;
        }
    }
}
