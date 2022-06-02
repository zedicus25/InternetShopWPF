using InternetShopWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace InternetShopWPF.Controllers
{
    public class WriteReadController
    {
        public string Path { get; set; }
        public WriteReadController()
        {
            Path = "dataBase.txt";
        }
        public WriteReadController(string path)
        {
            Path = path;
        }
        public ObservableCollection<Product_Model> ReadFromFile()
        {
            ObservableCollection<Product_Model> res = new ObservableCollection<Product_Model>();
            if (File.Exists(Path))
            {
                List<string> lines = File.ReadAllLines(Path).ToList();
                lines.RemoveAll(s => s.Equals(String.Empty));
                lines.RemoveAll(s => s.Equals(new String('-', 25)));
                while (lines.Count > 0)
                {
                    res.Add(new Product_Model(lines[0], lines[1], lines[4], float.Parse(lines[2]), 
                        float.Parse(lines[3]), float.Parse(lines[6]), int.Parse(lines[5])));
                    lines.RemoveRange(0, 7);
                }
            }
            return res;
        }

        public void WriteInFile(ObservableCollection<Product_Model> products)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in products)
            {
                sb.AppendLine(item.ToSrtingForFile());
            }
            File.WriteAllText(Path, sb.ToString());
        }
    }
}
