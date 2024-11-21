using BrownianMotion.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BrownianMotion.MVVM.ViewModel
{
    public class InitialPageViewModel : INotifyPropertyChanged
    {
        public ICommand GerarGraficoCommand { get; set; }
        public DadosIniciais DadosIniciais { get; set; }

        private IDrawable graficoDrawable;

        public InitialPageViewModel()
        {
            GerarGraficoCommand = new Command(GerarGrafico);
            DadosIniciais = new DadosIniciais();
        }

        private async void GerarGrafico()
        {
            
            if (DadosIniciais.PrecoInicial == null || DadosIniciais.PrecoInicial == 0 ||
                DadosIniciais.VolatilidadeMedia == null || DadosIniciais.VolatilidadeMedia == 0 ||
                DadosIniciais.RetornoMedio == null || DadosIniciais.RetornoMedio == 0 ||
                DadosIniciais.Tempo == null || DadosIniciais.Tempo == 0)
            {
                DadosIniciais.MsgErro = true;
                return; 
            }

            DadosIniciais.MsgErro = false;

            var precos = GenerateBrownianMotion(DadosIniciais.VolatilidadeMedia / 100, DadosIniciais.RetornoMedio, DadosIniciais.PrecoInicial, DadosIniciais.Tempo);
            GraficoDrawable = new PrecosDrawable(precos);
        }

        private double[] GenerateBrownianMotion(double? sigma, double? mean, double? initialPrice, int? numDays)
        {
            int numeroDias = numDays ?? 1;
            double precoInicial = initialPrice ?? 0;
            double vSigma = sigma ?? 0;

            Random rand = new();
            double[] prices = new double[numeroDias];
            prices[0] = precoInicial;


            for (int i = 1; i < numDays; i++)
            {
                double ul = 1.0 - rand.NextDouble();
                double u2 = 1.0 - rand.NextDouble();
                double z = Math.Sqrt(-2.0 * Math.Log(ul)) * Math.Cos(2.0 * Math.PI * u2);
                
                double retornoDiario = vSigma * z; // retirei o mean da fórmula original, pois estava indo ao infinito
                prices[i] = prices[i - 1] * Math.Exp(retornoDiario);

            }

            return prices;
        }

        public IDrawable GraficoDrawable
        {
            get => graficoDrawable;
            set
            {
                graficoDrawable = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
