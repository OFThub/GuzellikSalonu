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
    public partial class Form2 : Form
    {
        //Form1 de olan Müşteri bilgilerinin Form2 ye aktarılması için Form2 ye başka bir List açılıyor.
        List<Musteri> musteriList;
        List<Calisan> calisanList;

        //İşlem yapılması gereken ve denetim sağlayan değişkenler tanımlanıyor.
        string Hizmetler = string.Empty;
        string Saati = string.Empty;
        string Personeli = string.Empty;
        decimal Fiyatlar = 0;
        int sayac1=0;
        int sayac2=0;
        
        //Form2 parametre olarak Müşteri ve Personel bilgilerini alıyor.
        public Form2(List<Musteri> musteriList, List<Calisan> calisanList)
        {
            InitializeComponent();

            //Parametreler Form2 nin Müşteri ve Personel listesine atanıyor.
            this.musteriList = musteriList;
            this.calisanList = calisanList;

            //Alınan Müşteriler düzenlenecek Müşterilerin olduğu combobox a ekleniyor.
            foreach (var item in musteriList)
            {
                cMusteri.Items.Add(item.Ad + " " + item.SoyAd + " // " + item.Iletisim + " // " + item.Hizmet + " // " + item.Personel + " // " + item.Saat + " // " + item.Fiyat);
            }

            //Alınan Personeller Müşteriye atanacak Personellerin olduğu combobox a ekleniyor.
            foreach (var item in calisanList)
            {
                cPersonel.Items.Add(item.CalisanAdi+"   +"+item.CalisanFiyat);
            }

            //Eğer Müşteri var ise combobox ın seçili Index i ayarlanıyor.
            if (musteriList.Count!=0)
            {
                cMusteri.SelectedIndex = 0;
            }

            //Eğer Müşteri var ise combobox ın seçili Index i ayarlanıyor.
            if (calisanList.Count!=0)
            {
                cPersonel.SelectedIndex = 0;
            }
        }

        //Yeni Personellerin kayıt işlemi yapılıyor.
        private void Kayit_Click(object sender, EventArgs e)
        {
            if (Decimal.TryParse(tCalisanFiyat.Text, out decimal calisanFiyat))
            {
                //Personeller Çalışan listesine eklenip not defterine yazılıyor.
                Calisan calisan = new Calisan { CalisanAdi = tCalisanAdi.Text, CalisanSifre = tCalisanSifre.Text, CalisanFiyat = calisanFiyat };
                calisanList.Add(calisan);
                YazdirCalisanlar(calisanList);

                MessageBox.Show("Personel kaydınız başarılı.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);

                //Eklenen Personel Müşteriye atanacak Personellerin olduğu combobox a ekleniyor.
                if (Application.OpenForms["Form1"] is Form1 form1)
                {
                    form1.rPersonel.Items.Add(tCalisanAdi.Text + "   +" + tCalisanFiyat.Text);
                }

                this.Hide();
            }
        }

        //Müşteri Randevusunun düzenlenme işlemi yapılıyor.
        private void button1_Click(object sender, EventArgs e)
        {
            //Comboboxta seçilen Müşterinin tespit edilmesi.
            for (int i = 0; i < musteriList.Count; i++)
            {
                if (cMusteri.SelectedIndex == i)
                {
                    //İşlem yapılacak müşterinin denetimi.
                    if (musteriList.Count == 0)
                    {
                        MessageBox.Show("Düzenlenecek bir müşteri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //Düzenlenecek Müşteri listeden seçiliyor
                    Musteri musteri = musteriList[i];

                    //Müşterinin randevusunun düzenlenen yeni bilgileri hesaplanıyor ve işlem bitince Form eski haline dönüyor.
                    if (Manikur.Checked)
                    {
                        Hizmetler = "Manikür";
                        Fiyatlar = Fiyatlar + 120;
                        Manikur.Checked = false;
                        sayac1++;
                    }

                    if (Pedikur.Checked)
                    {
                        Hizmetler = Hizmetler + ", Pedikür";
                        Fiyatlar = Fiyatlar + 180;
                        Pedikur.Checked = false;
                        sayac1++;
                    }

                    if (Oje.Checked)
                    {
                        Hizmetler = Hizmetler + ", Oje";
                        Fiyatlar = Fiyatlar + 200;
                        Oje.Checked = false;
                        sayac1++;
                    }

                    if (Kirpik.Checked)
                    {
                        Hizmetler = Hizmetler + ", Kirpik";
                        Fiyatlar = Fiyatlar + 300;
                        Kirpik.Checked = false;
                        sayac1++;
                    }

                    if (Epilasyon.Checked)
                    {
                        Hizmetler = Hizmetler + ", Epilasyon";
                        Fiyatlar = Fiyatlar + 1500;
                        Epilasyon.Checked = false;
                        sayac1++;
                    }

                    if (Tirnak.Checked)
                    {
                        Hizmetler = Hizmetler + ", Tırnak";
                        Fiyatlar = Fiyatlar + 1000;
                        Tirnak.Checked = false;
                        sayac1++;
                    }

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

                    //Müşterinin randevusundaki düzenlenen personel atanıyor.
                    for (int j = 0; j < calisanList.Count; j++)
                    {
                        if (j == cPersonel.SelectedIndex)
                        {
                            Calisan calisan = calisanList[j];
                            Personeli = calisan.CalisanAdi;
                            Fiyatlar = Fiyatlar + calisan.CalisanFiyat;
                        }
                    }

                    //Doldurulması gereken veya doldurulması gerekenden fazla doldurulan alanların denetimi.
                    if (sayac1 == 0)
                    {
                        sayac2 = 0;
                        MessageBox.Show("Yapmak istediğiniz bakımı seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (sayac2 != 1)
                    {
                        sayac1 = 0;
                        sayac2 = 0;
                        MessageBox.Show("Sadece bir saat seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sayac1 = 0;
                    sayac2 = 0;

                    //Müşteriye yeni randevu atanıyor.
                    musteri.Fiyat = Fiyatlar;
                    musteri.Saat = Saati;
                    musteri.Hizmet = Hizmetler;
                    musteri.Personel = Personeli;

                    MessageBox.Show("Müşteri bilgilerini başarıyla güncellediniz.", "Tebrikler", MessageBoxButtons.OK, MessageBoxIcon.None);

                    this.Close();
                }
            }
        }

        //Müşteri Randevusunun iptal işlemi yapılıyor.
        private void button2_Click(object sender, EventArgs e)
        {
            //Silinecek müşteri yoksa uyarı veriyor.
            if (musteriList.Count < 0)
            {
                MessageBox.Show("Silinecek bir müşteri yok.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                //Müşteri kaydını hem combobox tan hemde Müşteri listesinden siliyor.
                musteriList.RemoveAt(cMusteri.SelectedIndex);
                cMusteri.Items.RemoveAt(cMusteri.SelectedIndex);

                //İşlem yapılacak müşteri kalmaz ise Form2 kapanıyor.
                if (musteriList.Count==0)
                {
                    MessageBox.Show("İşlem yapılacak bir müşteri kalmadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

        //Personellerin not defterine yazdırılması.
        static void YazdirCalisanlar(List<Calisan> Calisanlar)
        {
            try
            {
                //Not defteri dosyasının konumu ayarlanıyor.
                string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Çalışanlar.txt";

                //Personel bilgilerini not defterine yazma
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

        //Müşterilerin not defterine yazdırılması.
        static void YazdirMusteriler(List<Musteri> customers)
        {
            try
            {
                //Not defteri dosyasının konumunun ayarlanması
                string notepadPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Müşteriler.txt";

                File.WriteAllText(notepadPath, string.Empty);

                //Müşteri bilgilerini not defterine yazma
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

        //Form her kapandığında Müşteri bilgilerinin not defterine yazılma işlemi yapılıyor.
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            YazdirMusteriler(musteriList);
        }
    }
}
