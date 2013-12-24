using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Data.Linq;

namespace MaksiYakit
{
    public partial class SonucGoster : PhoneApplicationPage
    {
        public SonucGoster()
        {
            InitializeComponent();
            YakitlarDataContext db = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
            var yakitno = (from c in db.Yakitlar select c).Count();
            Yakit yakitlar = (from c in db.Yakitlar where c.YakitNo == yakitno select c).FirstOrDefault();
            lblTuketilenYakit.Text = yakitlar.TuketilenYakitMiktari.ToString();
            lblOdenenUcret.Text = yakitlar.HarcananTLMiktari.ToString();
            lblGidilenKM.Text = yakitlar.GidilenKMMiktari.ToString();
            lblYakitBirimFiyati.Text = yakitlar.YakitBirimFiyati.ToString();
            lbl1KmUcret.Text = yakitlar.KM1TLSonuc.ToString();
            lbl1KmYakit.Text = yakitlar.KM1LTSonuc.ToString();
            lbl100KmUcret.Text = yakitlar.KM100TLSonuc.ToString();
            lbl100KmYakit.Text = yakitlar.KM100LTSonuc.ToString();
            lblKayitTarihi.Text = "Kayıt Tarihi:" + yakitlar.KayitTarihi.ToString();
            txtKayitAdi.Text = yakitlar.KayitAdi;
            lblKayitNo.Text = "Kayıt No: ";
            lblKayitNotxt.Text= yakitlar.YakitNo.ToString();


        }
        YakitlarDataContext db = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
        private void btnKaydet_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult cevap = MessageBox.Show("Tüm verileri silmek istiyor musunuz?", "Tüm verileri temizle",MessageBoxButton.OKCancel);
            if (cevap == MessageBoxResult.OK)
            {
                try
                {
                    YakitlarDataContext db3 = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
                    var tumyakitlari = (from yakit in db3.Yakitlar select yakit);
                    db3.Yakitlar.DeleteAllOnSubmit(tumyakitlari);
                    db3.SubmitChanges();
                    MessageBox.Show("Başarıyla silindi");
                }
                catch (Exception)
                {
                    MessageBox.Show("Silme işlemindi bir hata oluştu");
                }

            }
            else
            { 
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult cevap = MessageBox.Show("Ekranda görünen kaydı silmek istiyor musunuz?", "Kaydı Sil", MessageBoxButton.OKCancel);
            if (cevap == MessageBoxResult.OK)
            {
                try
                {
                    Yakit silinecekyakit = (from silinecek in db.Yakitlar where silinecek.YakitNo == Convert.ToInt32(lblKayitNotxt.Text) select silinecek).FirstOrDefault();
                    db.Yakitlar.DeleteOnSubmit(silinecekyakit);
                    db.SubmitChanges();
                    MessageBox.Show("Kayıt başarıyla silindi!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Silme işlemindi bir hata oluştu");
                }

            }
            else
            {
            }

        }
    }
}