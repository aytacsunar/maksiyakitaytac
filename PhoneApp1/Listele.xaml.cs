using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace MaksiYakit
{
    public partial class Listele : PhoneApplicationPage
    {
        public Listele()
        {
            InitializeComponent();
            try
            {
                YakitlarDataContext db = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
                List<Yakit> L1 = new List<Yakit>();
                var yakitlar = from yakit in db.Yakitlar select yakit;
                foreach (var yakit in yakitlar)
                {
                    L1.Add(yakit);
                }
                //L1.Add(yakitlar);
                //L1 = yakitlar;
                this.listBox.ItemsSource = L1;
            }
            catch (Exception)
            {
                MessageBox.Show("Listelenecek Kayıt Yok!");

            }



        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Yakit data = (sender as ListBox).SelectedItem as Yakit;
            ListBoxItem selectedItem = this.listBox.ItemContainerGenerator.ContainerFromItem(data) as ListBoxItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        //public class MyData
        //{
        //    public string F_Name { get; set; }
        //    public string L_Name { get; set; }
        //    public string Address { get; set; }
        //    public int Salary { get; set; }
        //}
    }
}