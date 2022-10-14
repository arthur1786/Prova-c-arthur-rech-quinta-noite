using System;

namespace API_Folhas.Models
{
    public class FolhaPagamento
    {
        public int FolhaPagamentoId { get; set; }

        public int QuantidadeHoras {get; set;}

        public double ValorHora {get; set;}

        public double SalarioBruto {get; set;}

        public double ImpostoRenda{get; set;}
        
        public double ImpostoInss{get;set;}

        public double ImpostoFgts {get;set;}

        public double SalarioLiquido {get;set;}

        public int FuncionarioId{get;set;}
        public Funcionario Funcionario {get; set;}

        public DateTime CriadoEm {get;set;}
    }
}