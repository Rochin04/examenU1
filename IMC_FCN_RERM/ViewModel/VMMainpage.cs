using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IMC_FCN_RERM.ViewModel
{
    public class VMMainpage : BaseViewModel
    {
        public VMMainpage(INavigation navigation)
        {
            Navigation = navigation;
        }
        public bool _isIMC;
        public bool _isFCN;
        public bool _calcularIMC;
        public bool _calcularFCN;
        public int _peso;
        public int _altura;
        public int _latidos;
        public string _resultado;
        public int _resultadoIMC;
        //public bool
        public bool IsIMC
        {
            get { return _isIMC; }
            set { SetValue(ref _isIMC, value); }
        }
        public bool IsFCN
        {
            get { return _isFCN; }
            set { SetValue(ref _isFCN, value); }
        }
        public bool CalcularIMC
        {
            get { return _calcularIMC; }
            set { SetValue(ref _calcularIMC, value); }
        }
        public bool CalcularFCN
        {
            get { return _calcularFCN; }
            set { SetValue(ref _calcularFCN, value); }
        }
        public int Peso 
        {
            get { return _peso; }
            set { SetValue(ref _peso, value); }
        }
        public int Altura
        {
            get { return _altura; }
            set { SetValue(ref _altura, value); }
        }
        public int Latidos
        {
            get { return _latidos; }
            set { SetValue(ref _latidos, value); }
        }
        public string Respuesta
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value); }
        }
        public int RespuestaIMC
        {
            get { return _resultadoIMC; }
            set { SetValue(ref _resultadoIMC, value); }
        }
        public async Task Empezar()
        {
            if(IsIMC == true)
            {
                CalcularIMC = true;
                CalcularFCN = false;
            }
            else if(IsFCN == true)
            {
                CalcularFCN = true;
                CalcularIMC = false;
            }
        }
        public async Task CalcularIMCYFCN()
        {
            if(CalcularFCN == true)
            {
                Latidos = Latidos * 4;
                if(Latidos < 60)
                {
                    Respuesta = $"{Latidos} latidos por minuto, FCN Bajo";
                }
                else if(Latidos > 60 && Latidos < 100)
                {
                    Respuesta = $"{Latidos} latidos por minuto, FCN Normal";
                }
                else if (Latidos > 100)
                {
                    Respuesta = $"{Latidos} latidos por minuto, FCN Alta";
                }
            }
            else if(CalcularIMC == true)
            {
                double alturaEnMetros = Altura / 100.0;
                RespuestaIMC = (int)(Peso / (alturaEnMetros * alturaEnMetros));
                if(RespuestaIMC < 18.5)
                {
                    Respuesta = $"Su IMC es de {RespuestaIMC} peso insuficiente";
                }
                else if (RespuestaIMC > 18.5 && RespuestaIMC < 24.9)
                {
                    Respuesta = $"Su IMC es de {RespuestaIMC} peso normal o saludable";
                }
                else if (RespuestaIMC > 25.0 && RespuestaIMC < 29.9)
                {
                    Respuesta = $"Su IMC es de {RespuestaIMC} peso sobrepeso";
                }
                else if (RespuestaIMC > 30)
                {
                    Respuesta = $"Su IMC es de {RespuestaIMC} peso obesidad";
                }
            }
        }
        public ICommand EmpezarCommand => new Command(async () => await Empezar());
        public ICommand CalcularCommand => new Command(async () => await CalcularIMCYFCN());
    }
}
