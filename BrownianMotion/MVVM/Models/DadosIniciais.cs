using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotion.MVVM.Models
{
    public class DadosIniciais : INotifyPropertyChanged
    {
        private double? _precoInicial;
        public double? PrecoInicial 
        {
            get { return _precoInicial;}
            set { _precoInicial = value; OnPropertyChanged(nameof(PrecoInicial)); }
        }
        private double? _volatilidadeMedia;
        public double? VolatilidadeMedia
        {
            get { return _volatilidadeMedia; }
            set { _volatilidadeMedia = value; OnPropertyChanged(nameof(VolatilidadeMedia)); }
        }

        private double? _retornoMedio;
        public double? RetornoMedio
        {
            get { return _retornoMedio; }
            set { _retornoMedio = value; OnPropertyChanged(nameof(RetornoMedio)); }
        }
        private int? _tempo;
        public int? Tempo
        {
            get { return _tempo; }
            set { _tempo = value; OnPropertyChanged(nameof(Tempo)); }
        }

        private bool _msgErro;
        public bool MsgErro
        {
            get { return _msgErro; }
            set { _msgErro = value; OnPropertyChanged(nameof(MsgErro)); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string prop)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
