namespace API_Folhas.Utils
{

    public class Calculos{
        public static double CalcularSalarioBruto(int horas, double valor) => horas * valor;

        public static double CalcularImpostoRenda(double SalarioBruto)
        {
            if(SalarioBruto <= 1903.98){
                return 0;
            }
            else if(SalarioBruto <= 2826.65){
                return SalarioBruto * 0.075 - 142.80;
            }
            else if(SalarioBruto <= 3751.06){
                return SalarioBruto * 0.15 - 354.8;
            }
            else if(SalarioBruto <= 4664.28){
                return SalarioBruto * 0.225 - 636.13;
            }
            return SalarioBruto * 0.275 - 869.36;
        }

        public static double CalcularImpostoInss(double SalarioBruto)
        {
            if(SalarioBruto <= 1693.72){
                return SalarioBruto * 0.08;
            }
            else if(SalarioBruto <= 2826.65){
                return SalarioBruto * 0.09;
            }
            else if(SalarioBruto <= 5645.80){
                return SalarioBruto * 0.11;
            }
            return 621.03;
        }
        
        public static double CalcularFgts(double SalarioBruto){
            return SalarioBruto * 0.08;
        }

        public static double CalculaSalarioLiquido(double SalarioBruto, double renda, double inss)=>
        SalarioBruto - renda - inss;
    }
}