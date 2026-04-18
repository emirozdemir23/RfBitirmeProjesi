using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace ProjeWpf1 // Eğer projenizin namespace adı farklıysa değiştirmeyi unutmayın.
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // ─── SOL KOLON (DISPLAY PARAMS) BUTON İŞLEMLERİ ───
        private void BtnEkraniTemizle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ekran temizleme komutu gönderildi.");
        }

        private void BtnLcdOnizleme_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("RGB565 önizleme başlatıldı.");
        }

        private void BtnKapat_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sistem kapatılıyor...");
            Application.Current.Shutdown();
        }

        // ─── ORTA KOLON (LINK & HARDWARE) İŞLEMLERİ ───
        private void BtnInterrupt_Click(object sender, RoutedEventArgs e)
        {
            // Sistemi anında durdurma kodları
            MessageBox.Show("DİKKAT: Tüm işlemler durduruldu (INTERRUPT)!", "Acil Durum", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        // ─── SAĞ KOLON (SEKME 1: METİN TERMİNALİ) İŞLEMLERİ ───
        private void BtnDuzenle_Click(object sender, RoutedEventArgs e)
        {
            // Gelen veya giden paketi formatlama
            MessageBox.Show("Veri ayrıştırma (Parse) işlemi çalıştırıldı.");
        }

        private void BtnGonder_Click(object sender, RoutedEventArgs e)
        {
            string mesaj = TxtMesaj.Text;
            if (!string.IsNullOrWhiteSpace(mesaj))
            {
                // Nextion formatında metin gönderim kodu buraya yazılacak
                MessageBox.Show("Metin paketi gönderildi: " + mesaj);
            }
            else
            {
                MessageBox.Show("Gönderilecek mesaj boş olamaz!", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // ─── SAĞ KOLON (SEKME 2: FOTOĞRAF TERMİNALİ) İŞLEMLERİ ───
        private void BtnFotoSec_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Nextion İçin Resim Seç";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    ImgPreview.Source = new BitmapImage(fileUri);
                    TxtImgPlaceholder.Visibility = Visibility.Collapsed; // "Resim seçilmedi" yazısını kaldır
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Resim yüklenirken hata oluştu: " + ex.Message, "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void BtnFotoGonder_Click(object sender, RoutedEventArgs e)
        {
            if (ImgPreview.Source != null)
            {
                // Resmi Nextion formatına çevirip gönderme algoritması buraya gelecek
                MessageBox.Show("Fotoğraf işleniyor ve Nextion ekranına aktarılıyor...", "Aktarım Başladı");
            }
            else
            {
                MessageBox.Show("Lütfen önce gönderilecek bir resim seçin!", "Resim Eksik", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}