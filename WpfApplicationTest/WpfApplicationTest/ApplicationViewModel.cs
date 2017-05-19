using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfApplicationTest
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        private Polynomial selectedFunction;

        public ObservableCollection<Polynomial> Functions { get; set; }

        public ObservableCollection<int> ValuesC
        {
            get
            {
                return selectedFunction.ValuesC;
            }
        }

        public int SelectedC
        {
            get { return selectedFunction.C; }
            set
            {
                selectedFunction.C = value;
            }
        }

        public Polynomial SelectedFunction
        {
            get { return selectedFunction; }
            set
            {
                selectedFunction = value;
                OnPropertyChanged("SelectedFunction");
            }
        }

        public ApplicationViewModel()
        {
            Functions = new ObservableCollection<Polynomial>
            {
                new Polynomial("Линейная"),
                new Polynomial("Квадратичная"),
                new Polynomial("Кубическая"),
                new Polynomial("4-ой степени"),
                new Polynomial("5-ой степени")
            };
            selectedFunction = Functions[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
