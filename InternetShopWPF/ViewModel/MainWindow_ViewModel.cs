using GalaSoft.MvvmLight.Command;
using InternetShopWPF.Controllers;
using InternetShopWPF.Models;
using InternetShopWPF.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private RelayCommand _removeCommand;
        private RelayCommand _updateCommand;

        private Product_Model _selectedProduct;
        private WriteReadController _writeReadController;

        public MainWindow_ViewModel()
        {
            _writeReadController = new WriteReadController();
            _products = new ObservableCollection<Product_Model>(_writeReadController.ReadFromFile());
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

        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ?? (_removeCommand = new RelayCommand(() =>
                {
                    if(SelectedProduct != null)
                        _products.Remove(SelectedProduct);  
                }));
            }
            set
            {
                _removeCommand = value;
            }
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                return _updateCommand ?? (_updateCommand = new RelayCommand(() =>
                {
                    if (SelectedProduct != null)
                    {
                        AddingWindow addingWindow = new AddingWindow();
                        addingWindow.DataContext = this;
                        addingWindow.ShowDialog();
                    }
                }));
            }
            set
            {
                _updateCommand = value;
            }
        }

        ~MainWindow_ViewModel()
        {
            _writeReadController.WriteInFile(_products);
        }
    }
}
