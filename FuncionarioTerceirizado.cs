using System;
using System.Collections.Generic;
using System.Text;

namespace Empresa
{
    class FuncionarioTerceirizado : Funcionario
    {
        public FuncionarioTerceirizado(string nome) : base(nome) {}
        public FuncionarioTerceirizado(string nome, double despesa) : base(nome, despesa) {}
        public override double Calculo(int horatrabalhada, double valorHora, bool terceirizado)
        {
            return horatrabalhada * (valorHora + valorHora * 1.1);
        }
    }
}
