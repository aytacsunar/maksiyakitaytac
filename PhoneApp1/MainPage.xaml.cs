using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MaksiYakit.Resources;
using System.Data.Linq;

namespace MaksiYakit
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            BuildLocalizedApplicationBar();
            
        }
        public decimal tuketilenyakit, yakitbirimfiyati, gidilenyol, harcanantl, sonuc;
        private void btnHesapla_Click(object sender, RoutedEventArgs e)
        {   

            try
            { 
                if (rbYakit.IsChecked == true)//Yakıta göre hesaplama
                {
                    if ((txtGidilenKM.Text.Trim() == "" || txtYakitFiyati.Text.Trim() == "" || txtTuketilenLT.Text.Trim() == ""))
                    {
                        MessageBox.Show("Tüketilen Yakıt Miktarı, Gidilen KM ve Yakıt Fiyatını doğru girdiğinizden emin olunuz! ");
                    }
                    else
                    {
                        tuketilenyakit = Convert.ToDecimal(txtTuketilenLT.Text);
                        yakitbirimfiyati = Convert.ToDecimal(txtYakitFiyati.Text);
                        gidilenyol = Convert.ToDecimal(txtGidilenKM.Text);
                        harcanantl = Convert.ToDecimal(tuketilenyakit*yakitbirimfiyati);
                        sonuc = Convert.ToDecimal((tuketilenyakit * yakitbirimfiyati) / gidilenyol * 100);
                        YakitlarDataContext bst = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
                        if (bst.DatabaseExists() == false)
                        {
                            bst.CreateDatabase();
                            bst.SubmitChanges();
                        }
                        var yakitno = (from c in bst.Yakitlar select c).Count();
                        Yakit yakitekle = new Yakit();
                        yakitekle.GidilenKMMiktari = gidilenyol;
                        //yakitekle.GidilenKMMiktari = gidilenyol;
                        yakitekle.HarcananTLMiktari = harcanantl;
                        yakitekle.KayitAdi = "Deneme";
                        yakitekle.KayitTarihi = DateTime.Now;
                        yakitekle.KM100LTSonuc = (sonuc / yakitbirimfiyati);
                        yakitekle.KM100TLSonuc = sonuc;
                        yakitekle.KM1LTSonuc = (sonuc / 100 / yakitbirimfiyati);
                        yakitekle.KM1TLSonuc = sonuc;
                        yakitekle.TuketilenYakitMiktari = tuketilenyakit;
                        yakitekle.YakitBirimFiyati = yakitbirimfiyati;
                        yakitekle.YakitNo = yakitno + 1;
                        bst.Yakitlar.InsertOnSubmit(yakitekle);
                        bst.SubmitChanges();
                        MessageBox.Show("Kayıt eklendi!");
                        NavigationService.Navigate(new Uri("/SonucGoster.xaml", UriKind.Relative));
                    }
                }
                else if (rbTutar.IsChecked == true)//Harcamaya göre hesaplama
                {
                    if (txtHarcananTL.Text.Trim() == "" || txtGidilenKM.Text.Trim() == "" || txtYakitFiyati.Text.Trim() == "")
                    {
                        MessageBox.Show("Ödenen TL Miktarı, Gidilen KM ve Yakıt Fiyatını doğru girdiğinizden emin olunuz! ");
                    }
                    else
                    {
                        harcanantl = Convert.ToDecimal(txtHarcananTL.Text);
                        yakitbirimfiyati = Convert.ToDecimal(txtYakitFiyati.Text);
                        gidilenyol = Convert.ToDecimal(txtGidilenKM.Text);
                        tuketilenyakit = Convert.ToDecimal(harcanantl/yakitbirimfiyati);
                        sonuc = Convert.ToDecimal(harcanantl / gidilenyol*100);
                        YakitlarDataContext bst = new YakitlarDataContext(YakitlarDataContext.ConnectionString);
                        if (bst.DatabaseExists() == false)
                        {
                            bst.CreateDatabase();
                            bst.SubmitChanges();
                        }
                        var yakitno = (from c in bst.Yakitlar select c).Count();
                        Yakit yakitekle = new Yakit();
                        yakitekle.GidilenKMMiktari = gidilenyol;
                        yakitekle.HarcananTLMiktari = harcanantl;
                        yakitekle.KayitAdi = "Deneme";
                        yakitekle.KayitTarihi = DateTime.Now;
                        yakitekle.KM100LTSonuc = (sonuc / yakitbirimfiyati);
                        yakitekle.KM100TLSonuc = sonuc;
                        yakitekle.KM1LTSonuc = (sonuc / 100 / yakitbirimfiyati);
                        yakitekle.KM1TLSonuc = sonuc;
                        yakitekle.TuketilenYakitMiktari = tuketilenyakit;
                        yakitekle.YakitBirimFiyati = yakitbirimfiyati;
                        yakitekle.YakitNo = yakitno + 1;
                        bst.Yakitlar.InsertOnSubmit(yakitekle);
                        bst.SubmitChanges();
                        MessageBox.Show("Kayıt Eklendi!");
                        NavigationService.Navigate(new Uri("/SonucGoster.xaml", UriKind.Relative));

                    }
                }
                
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());
            }
        }

        private void txtTuketilenLT_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Listele.xaml", UriKind.Relative));
            // Return to the main page.
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            
        }
        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Listele.xaml", UriKind.Relative));
            // Return to the main page.
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }

        }
        private void txtHarcananTL_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void BuildLocalizedApplicationBar(){
        ApplicationBar newi = new ApplicationBar();
        ApplicationBarIconButton btnHakkinda = new ApplicationBarIconButton(new Uri("/Assets/ApplicationIcon.png", UriKind.Relative));
        btnHakkinda.Text = AppResources.AppBarButtonText;
        newi.Buttons.Add(btnHakkinda);
        newi.IsVisible = true;
        newi.IsMenuEnabled = true;
        
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}