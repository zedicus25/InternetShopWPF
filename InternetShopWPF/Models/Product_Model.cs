using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace InternetShopWPF.Models
{
    public class Product_Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private float _priceWithoutDiscount;
        private float _priceWithDiscount;
        private string _productImage;
        private int _countResponse;
        private float _averageRating;
        private string _decription;

        public Product_Model() : this(String.Empty, String.Empty, "\\Recourse\\defaultProduct.png", 0,0,0,0)
        {
        }
        public Product_Model(string name, string description, string image, float priceWithDiscount, 
            float priceWithoutDiscount, float averageRating, int countResponse)
        {
            _name = name;
            _decription = description;
            _productImage = image;
            _priceWithoutDiscount = priceWithoutDiscount;
            _priceWithDiscount = priceWithDiscount;
            _averageRating = averageRating;
            _decription = description;
            _countResponse = countResponse; 
        }

        public string Description
        {
            get { return _decription; }
            set { _decription = value;  OnPropertyChanged("Description"); }
        }


        public float AvarageRating
        {
            get { return _averageRating; }
            set { _averageRating = value; OnPropertyChanged("AvarageRating"); }
        }


        public int CountResponse
        {
            get { return _countResponse; }
            set { _countResponse = value; OnPropertyChanged("CountResponse"); }
        }


        public string ProductImage
        {
            get { return _productImage; }
            set { _productImage = value; OnPropertyChanged("ProductImage"); }
        }


        public float PriceWithoutDiscount
        {
            get { return _priceWithoutDiscount; }
            set { _priceWithoutDiscount = value; OnPropertyChanged("PriceWithoutDiscount"); }
        }


        public float PriceWithDiscount
        {
            get { return _priceWithDiscount; }
            set { _priceWithDiscount = value; OnPropertyChanged("PriceWithDiscount"); }
        }


        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string ToSrtingForFile() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_name);
            sb.AppendLine(_decription);
            sb.AppendLine(_priceWithDiscount.ToString());
            sb.AppendLine(_priceWithoutDiscount.ToString());
            sb.AppendLine(_productImage);
            sb.AppendLine(_countResponse.ToString());
            sb.AppendLine(_averageRating.ToString());
            sb.Append(new String('-', 25));
            return sb.ToString();
        }
    }
}
