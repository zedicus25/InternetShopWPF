using GalaSoft.MvvmLight.Command;
using InternetShopWPF.Models;
using InternetShopWPF.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace InternetShopWPF.ViewModel
{
    public class MainWindow_ViewModel : INotifyPropertyChanged
    {
        public Product_Model SelectedProduct
        {
            get { return _selectedProduct; }
            set { _selectedProduct = value; OnPropertyChanged("SelectedProduct"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Product_Model> Products
        {
            get { return _products; }
            set { _products = value; OnPropertyChanged("Products"); }   
        }

        private ObservableCollection<Product_Model> _products;
        private RelayCommand _addCommand;
        private Product_Model _selectedProduct;

        public MainWindow_ViewModel()
        {
            _selectedProduct = new Product_Model();
            _products = new ObservableCollection<Product_Model>();
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(() =>
                {
                    Product_Model note = new Product_Model();
                    SelectedProduct = note;
                    AddingWindow addingWindow = new AddingWindow();
                    addingWindow.DataContext = this;
                    addingWindow.ShowDialog();
                    _products.Add(note);

                }));
            }
            set
            {
                _addCommand = value;
            }
        }

    }
}
