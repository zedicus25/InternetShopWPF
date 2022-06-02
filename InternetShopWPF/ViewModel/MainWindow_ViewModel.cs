using InternetShopWPF.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InternetShopWPF.ViewModel
{
    public class MainWindow_ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product_Model> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged("Products"); }
        }

        private ObservableCollection<Product_Model> _products;

        public MainWindow_ViewModel()
        {
            _products = new ObservableCollection<Product_Model>();
            _products.Add(new Product_Model("Name", "Description", "..\\Recourse\\image.jpg", 12, 15, 3.5f, 15));
            _products.Add(new Product_Model("Name", "Description", "image", 10, 18, 4.5f, 5));
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
