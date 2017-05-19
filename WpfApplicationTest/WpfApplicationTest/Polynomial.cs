using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WpfApplicationTest
{
    public class Polynomial : INotifyPropertyChanged
    {
        private string type;
        private string formula;
        private int c;
        private double a;
        private double b;
        private double f;
        private double x;
        private double y;

        public ObservableCollection<int> ValuesC { get; set; }

        public Polynomial(string sType)
        {
            type = sType;
            switch (type)
            {
                case "Линейная":
                    ValuesC = new ObservableCollection<int> { 1, 2, 3, 4, 5 };
                    formula = "f(x,y) = ax + y + c";
                    break;
                case "Квадратичная":
                    ValuesC = new ObservableCollection<int> { 10, 20, 30, 40, 50 };
                    formula = "f(x, y) = ax ^ 2 + by + c";
                    break;
                case "Кубическая":
                    ValuesC = new ObservableCollection<int> { 100, 200, 300, 400, 500 };
                    formula = "f(x,y) = ax^3 + (b^2)y + c";
                    break;
                case "4-ой степени":
                    ValuesC = new ObservableCollection<int> { 1000, 2000, 3000, 4000, 5000 };
                    formula = "f(x,y) = ax^4 + (b^3)y + c";
                    break;
                case "5-ой степени":
                    ValuesC = new ObservableCollection<int> { 10000, 20000, 30000, 40000, 50000 };
                    formula = "f(x,y) = ax^5 + (b^4)y + c";
                    break;
                default:
                    return;
            }
            a = 1;
            b = 1;
            x = 1;
            y = 1;
            c = ValuesC[0];
            f = Calculate();
        }
 
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Formula
        {
            get { return formula; }
            set
            {
                formula = value;
                OnPropertyChanged("Formula");
            }
        }

        public int C
        {
            get { return c; }
            set
            {
                c = value;
                OnPropertyChanged("C");
            }
        }

        public double A
        {
            get { return a; }
            set
            {
                a = value;
                OnPropertyChanged("A");
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                b = value;
                OnPropertyChanged("B");
            }
        }

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        public double F
        {
            get { return f; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            f = Calculate();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
                PropertyChanged(this, new PropertyChangedEventArgs("F"));
            }
        }

        private double Calculate()
        {
            switch (type)
            {
                case "Линейная":
                    f = a * x + y + c;
                    break;
                case "Квадратичная":
                    f = a * x * x + b * y + c;
                    break;
                case "Кубическая":
                    f = a * x * x * x + b * b * y + c;
                    break;
                case "4-ой степени":
                    f = a * x * x * x * x + b * b * b * y + c;
                    break;
                case "5-ой степени":
                    f = a * x * x * x * x * x + b * b * b * b * y + c;
                    break;
            }
            return f;
        }
    }
}
