using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF19.Models;

namespace WPF19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        private int radius;
        public int Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }
        private double circumference;
        public double Circumference
        {
            get => circumference;
            set
            {
                circumference = value;
                OnPropertyChanged();
            }
        }
        public ICommand AddCommand { get; }
        private void OnAddCommandExecute(object p)
        {
            Circumference = Ariph.Calc(Radius);
        }
        private bool CanAddCommandExecuted(object p)
        {
            if(Radius!= 0) return true; 
            else return false;
        }
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }
    }

}
