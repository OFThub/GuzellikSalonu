/*************************************************************************************************************************************************************************************************************
**************************************************************************************************************************************************************************************************************


                                                                            SAKARYA ÜNİVERSİTESİ
                                                                   BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
                                                                      BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
                                                                         NESNEYE DAYALI PROGRAMLAMA

                                                                         Ödev Numarası......:PROJE
                                                                         Öğrenci Adı........:Ömer Faruk TÜRKDOĞDU
                                                                         Öğrenci Numarası...:G231210002
                                                                         Öğrencinin Grubu...:2.A


**************************************************************************************************************************************************************************************************************
*************************************************************************************************************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PROJE_
{
    //Uygulamadaki ilk personel atanmıştır personel olarak giriş yapmak için personel ismine "Ömer Faruk" şifresine "123" girilmelidir.
    public partial class Form1 : Form
    {
        //Müşteri ve Çalışan bilgileri tutulması için List kullanılıyor.
        static List<Musteri> Musteriler = new List<Musteri>();
        static List<Calisan> Calisanlar = new List<Calisan>();

        //İşlem yapılması gereken ve denetim sağlayan değişkenler tanımlanıyor.
        string Hizmetler = string.Empty;
        string Personel1= string.Empty;
        string Saati = string.Empty;
        int sayac1 = 0;
        int sayac2 = 0;
        decimal Fiyatlar = 0;

        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Not defterine kaydedilen müşteri ve çalışan bilgileri alınıyor.
            LoadMusteriler();
            LoadCalisanlar();

            //Örnek çalışan ekleniyor.
            if (Calisanlar.Count == 0)
            {
                Calisan calisan = new Calisan();
                calisan.CalisanAdi = "Ömer Faruk";
                calisan.CalisanSifre = "123";
                calisan.CalisanFiyat = 500;
                Calisanlar.Add(calisan);
                YazdirCalisanlar(Calisanlar);
                LoadCalisanlar() ;
            }
        }

        //Randevu alma işlemi yapılıyor.
        private void RandevuAl_Click(object sender, EventArgs e)
        {
            //Seçilen personel bulunup randevu ile eşleşiyor.
            foreach (var item in Calisanlar)
            {
                if (rPersonel.Text==item.CalisanAdi+"   +"+item.CalisanFiyat)
                {
                    Personel1 = item.CalisanAdi;
                    Fiyatlar = Fiyatlar + item.CalisanFiyat;
                }
            }

            //Seçilen bakım Hizmetlere kaydediliyor bakım ücreti hesaplanıyor ve işaretlenen checkbox lar eski haline geri döndürülüyor.
            if (Manikur.Checked) 
            {
                Hizmetler = "- Manikür -";
                Fiyatlar = Fiyatlar + 120;
                Manikur.Checked = false;
                sayac1++;
            }

            if (Pedikur.Checked)
            {
                Hizmetler = Hizmetler + "- Pedikür -";
                Fiyatlar = Fiyatlar + 180;
                Pedikur.Checked = false;
                sayac1++;
            }

            if (Oje.Checked)
            {              
                Hizmetler = Hizmetler + "- Oje -";
                Fiyatlar = Fiyatlar + 200;
                Oje.Checked = false;
                sayac1++;
            }

            if (Kirpik.Checked)
            {
                Hizmetler = Hizmetler + "- Kirpik -";
                Fiyatlar = Fiyatlar + 300;
                Kirpik.Checked = false;
                sayac1++;
            }

            if (Epilasyon.Checked)
            {
                Hizmetler = Hizmetler + "- Epilasyon -";
                Fiyatlar = Fiyatlar + 1500;
                Epilasyon.Checked = false;
                sayac1++;
            }

            if (Tirnak.Checked)
            {
                Hizmetler = Hizmetler + "- Tırnak -";
                Fiyatlar = Fiyatlar + 1000;
                Tirnak.Checked = false;
                sayac1++;
            }

            //Randevu saati müşteri randevusuna işleniyor ve sadece bir saat seçilmesi denetleniyor.
            if (checkBox1.Checked)
            {
                Saati = checkBox1.Text;
                checkBox1.Checked = false;
                sayac2++;
            }

            if (checkBox2.Checked)
            {
                Saati = checkBox2.Text;
                checkBox2.Checked = false;
                sayac2++;
            }

            if (checkBox3.Checked)
            {
                Saati = checkBox3.Text;
                checkBox3.Checked = false;
                sayac2++;
            }

            if (checkBox4.Checked)
            {
                Saati = checkBox4.Text;
                checkBox4.Checked = false;
                sayac2++;
            }

            if (checkBox5.Checked)
            {
                Saati = checkBox5.Text;
                checkBox5.Checked = false;
                sayac2++;
            }

            if (checkBox6.Checked)
            {
                Saati = checkBox6.Text;
                checkBox6.Checked = false;
                sayac2++;
            }

            if (checkBox7.Checked)
            {
                Saati = checkBox7.Text;
                checkBox7.Checked = false;
                sayac2++;
            }

            if (checkBox8.Checked)
            {
                Saati = checkBox8.Text;
                checkBox8.Checked = false;
                sayac2++;
            }

            //Doldurulması gereken bölümlerin boş olup olmaması denetleniyor.
            if (rAd.Text == string.Empty || rSoyAd.Text == string.Empty || rIletisim.Text == string.Empty)
            {
                sayac1 = 0;
                sayac2 = 0;
                MessageBox.Show("Müşteri bilgilerini eksik girdiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sayac1==0)
            {
                sayac2 = 0;
                MessageBox.Show("Yapmak istediğiniz bakımı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sayac2!=1)
            {
                sayac1 = 0;
                sayac2 = 0;
                MessageBox.Show("Sadece bir saat seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rPersonel.SelectedIndex<0)
            {
                sayac1 = 0;
                sayac2 = 0;
                MessageBox.Show("Lütfen personel seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Alınan bilgiler müşterinin bilgileri ile eşlenip listeye ekleniyor ve not defterine yazdırılıyor.
            Musteri musteri = new Musteri { Ad = rAd.Text, SoyAd = rSoyAd.Text, Iletisim = rIletisim.Text, Hizmet = Hizmetler, Personel = Personel1, Fiyat = Fiyatlar, Saat = Saati };
            Musteriler.Add(musteri);
            YazdirMusteriler(Musteriler);

            MessageBox.Show("Randevuyu alma işleminiz başarılı.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);

            //Doldurulan alanlar eski haline dönüyor.
            rAd.Text = string.Empty;
            rSoyAd.Text = string.Empty;
            rIletisim.Text = string.Empty;
            rPersonel.SelectedIndex = 0;
            sayac1 = 0;
            sayac2 = 0;
        }

        //Personellerin hesaplarına girmesi.
        private void Giris_Click(object sender, EventArgs e)
        {
            //İsim ve Şifre denetimi.
            foreach (var item in Calisanlar)
            {
                if (rCalisanAdi.Text == item.CalisanAdi && rCalisanSifre.Text == item.CalisanSifre)
                {
                    MessageBox.Show("Başarıyla giriş yaptınız.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);

                    //Bilgiler doğru ise Form2 ye yönlendiriliyor.
                    Form2 form2 = new Form2(Musteriler, Calisanlar);
                    form2.Show();
                }
            }
        }

        //Personellerin not defterine yazılma işlemi yapılıyor.
        static void YazdirCalisanlar(List<Calisan> Calisanlar)
        {
            try
            {
                // Not defteri dosyasının konumunu belirlenmesi.
                string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Çalışanlar.txt";

                // Çalışan bilgilerini not defterine yazılması.
                using (StreamWriter sw = new StreamWriter(notepadPath))
                {
                    foreach (var calisan in Calisanlar)
                    {
                        sw.WriteLine($"Ad: {calisan.CalisanAdi} Ücret: {calisan.CalisanFiyat} Şifre: {calisan.CalisanSifre}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Not defterine yazdırma hatası: " + ex.Message);
            }
        }

        //Personellerin not defterinden okunma işlemi yapılıyor.
        private void LoadCalisanlar()
        {
            try
            {
                // Not defteri dosyasının konumunu belirlenmesi.
                string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Çalışanlar.txt";

                if (File.Exists(notepadPath))
                {
                    using (StreamReader sr = new StreamReader(notepadPath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(new[] { "Ad: "," Ücret: ", " Şifre: " }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length == 3)
                            {
                                decimal Ucret;

                                if (decimal.TryParse(parts[1], out Ucret))
                                {
                                    Calisan calisan = new Calisan { CalisanAdi = parts[0], CalisanFiyat = Ucret, CalisanSifre = parts[2] };
                                    rPersonel.Items.Add(calisan.CalisanAdi + "   +" + calisan.CalisanFiyat);
                                    Calisanlar.Add(calisan);
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Dosyadan okuma hatası: " + ex.Message);
            }
        }

        //Müşterilerin not defterine yazılma işlemi yapılıyor.
        static void YazdirMusteriler(List<Musteri> customers)
        {
            try
            {
                // Not defteri dosyasının yolunu belirleme
                string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Müşteriler.txt";

                // Müşteri bilgilerini not defterine yazma
                using (StreamWriter sw = new StreamWriter(notepadPath))
                {
                    foreach (var customer in customers)
                    {
                        sw.WriteLine($"Ad: {customer.Ad} Soyad: {customer.SoyAd} İletişim Bilgisi: {customer.Iletisim} Alacağı Hizmetler: {customer.Hizmet} Personel: {customer.Personel} Saat: {customer.Saat} Ücret: {customer.Fiyat}");
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Not defterine yazdırma hatası: " + ex.Message);
            }
        }

        //Müşterilerin not defterinden okunma işlemi yapılıyor.
        private void LoadMusteriler()
        {
            try
            {
                // Not defteri dosyasının konumunu belirlenmesi.
                string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Müşteriler.txt";

                if (File.Exists(notepadPath))
                {
                    using (StreamReader sr = new StreamReader(notepadPath, true))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] parts = line.Split(new[] { "Ad: ", " Soyad: ", " İletişim Bilgisi: " , " Alacağı Hizmetler: ", " Personel: ", " Ücret: ", " Saat: "}, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 7)
                            {
                                decimal fiyat;
                                if (decimal.TryParse(parts[6], out fiyat))
                                {
                                    Musteri musteri = new Musteri { Ad = parts[0], SoyAd = parts[1], Iletisim = parts[2], Hizmet = parts[3], Personel = parts[4], Saat = parts[5], Fiyat = fiyat  };
                                    Musteriler.Add(musteri);
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Dosyadan okuma hatası: " + ex.Message);
            }
        }
    }

    // Müşteri sınıfı tanımı
    public class Musteri
    {
        public string Ad;
        public string SoyAd;
        public string Iletisim;
        public string Hizmet;
        public string Personel;
        public decimal Fiyat;
        public string Saat;
    }

    // Çalışan sınıfı tanımı
    public class Calisan
    {
        public string CalisanAdi;
        public string CalisanSifre;
        public decimal CalisanFiyat;
    }
}
