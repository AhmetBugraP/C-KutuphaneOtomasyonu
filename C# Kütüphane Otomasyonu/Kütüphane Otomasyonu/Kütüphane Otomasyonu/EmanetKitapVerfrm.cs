using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class EmanetKitapVerfrm : Form
    {
        public EmanetKitapVerfrm()
        {
            InitializeComponent();
        }

        private void grpUyeBilgi_Enter(object sender, EventArgs e)
        {

        }

        private void grpKitapBilgi_Enter(object sender, EventArgs e)
        {

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM sepet", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["sepet"].Clear(); // Veri kümesindeki "sepet" tablosunu da temizle
            this.Close();

        }



        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NEG801R;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        private void EmanetKitapVerfrm_Load(object sender, EventArgs e)
        {
            sepetlistele();
        }



        //Emanet Kitap da olan kişinin kaç kitaba sahip olduğu yer
        private void kitapsayisi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(kitapsayisi) from sepet", baglanti);
            lblKitapSayi.Text = komut.ExecuteScalar()?.ToString();
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        DataSet daset = new DataSet();

        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from sepet", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            baglanti.Close();
        }


        private static int lastEmanetID = 0; // Sınıf düzeyinde bir değişken

        private int GetUniqueEmanetID()
        {
            lastEmanetID++; // Son emanet ID'sini bir artır
            return lastEmanetID;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string barkodNo = txtBarkodNo.Text;
            string kitapAdi = txtKitapAdi.Text;
            string yazari = txtYazari.Text;
            string yayinevi = txtYayinevi.Text;
            string sayfaSayisi = txtSayfaSayisi.Text;
            int kitapSayisi = int.Parse(txtKitapSayisi.Text);

            // Gerekli alanların dolu olup olmadığını ve kitabın veritabanında mevcut olup olmadığını kontrol ediyoruz
            if (string.IsNullOrWhiteSpace(barkodNo) || string.IsNullOrWhiteSpace(kitapAdi) || string.IsNullOrWhiteSpace(yazari) ||
                string.IsNullOrWhiteSpace(yayinevi) || string.IsNullOrWhiteSpace(sayfaSayisi))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            baglanti.Open();
            SqlCommand kontrolKomutu = new SqlCommand("select count(*) from sepet where barkodno = @barkodno", baglanti);
            kontrolKomutu.Parameters.AddWithValue("@barkodno", barkodNo);
            int mevcutKitapSayisi = (int)kontrolKomutu.ExecuteScalar();
            baglanti.Close();

            if (mevcutKitapSayisi > 0)
            {
                baglanti.Open();
                SqlCommand stokGuncelleKomutu = new SqlCommand("update sepet set kitapsayisi = kitapsayisi + @ekKitapSayisi where barkodno = @barkodno", baglanti);
                stokGuncelleKomutu.Parameters.AddWithValue("@ekKitapSayisi", kitapSayisi);
                stokGuncelleKomutu.Parameters.AddWithValue("@barkodno", barkodNo);
                stokGuncelleKomutu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kitap sepete eklendi ve stok satışı güncellendi!", "Ekleme işlemi");

                daset.Tables["sepet"].Clear();
                sepetlistele();

                lblKitapSayi.Text = "";
                kitapsayisi();

                foreach (Control item in grpKitapBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
                }

                return;
            }

            // Yeni kitap sepete ekleniyor
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into sepet(barkodno, kitapadi, yazari, yayinevi, sayfasayisi, kitapsayisi, teslimtarihi, iadetarihi) " +
                "values(@barkodno, @kitapadi, @yazari, @yayinevi, @sayfasayisi, @kitapsayisi, @teslimtarihi, @iadetarihi)", baglanti);
            komut.Parameters.AddWithValue("@barkodno", barkodNo);
            komut.Parameters.AddWithValue("@kitapadi", kitapAdi);
            komut.Parameters.AddWithValue("@yazari", yazari);
            komut.Parameters.AddWithValue("@yayinevi", yayinevi);
            komut.Parameters.AddWithValue("@sayfasayisi", sayfaSayisi);
            komut.Parameters.AddWithValue("@kitapsayisi", kitapSayisi);
            komut.Parameters.AddWithValue("@teslimtarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@iadetarihi", dateTimePicker2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kitap sepete eklendi!", "Ekleme işlemi");

            daset.Tables["sepet"].Clear();
            sepetlistele();

            lblKitapSayi.Text = "";
            kitapsayisi();

            foreach (Control item in grpKitapBilgi.Controls)
            {
                if (item is TextBox)
                {
                    if (item != txtKitapSayisi)
                    {
                        item.Text = "";
                    }
                }
            }
        }








        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from uye where tc like @tc", baglanti);
            komut.Parameters.AddWithValue("@tc", txtTcAra.Text + "%");
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
            }

            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(kitapsayisi) from emanetkitaplar where tc=@tc", baglanti);
            komut2.Parameters.AddWithValue("@tc", txtTcAra.Text);
            lblKayitliKitapSayi.Text = komut2.ExecuteScalar()?.ToString();
            baglanti.Close();

            if (txtTcAra.Text == "")
            {
                foreach (Control item in grpUyeBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";

                    }
                }
                lblKayitliKitapSayi.Text = "";
            }
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            if (txtBarkodNo.Text == "")
            {
                // Barkod boş ise tüm textboxları temizle
                foreach (Control item in grpKitapBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
            else
            {
                // Veritabanı bağlantısını aç
                baglanti.Open();

                // Barkod numarasına göre "kitap" tablosundan kayıtları seçmek için bir SQL komutu oluştur
                SqlCommand komut = new SqlCommand("select * from kitap where barkodno = @barkodno", baglanti);
                komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                SqlDataReader read = komut.ExecuteReader();

                if (read.Read())
                {
                    // Eşleşen bir kayıt bulunduysa kitap bilgilerini göster
                    txtKitapAdi.Text = read["kitapadi"].ToString();
                    txtYazari.Text = read["yazari"].ToString();
                    txtYayinevi.Text = read["yayinevi"].ToString();
                    txtSayfaSayisi.Text = read["sayfasayisi"].ToString();
                }
                else
                {
                    // Eşleşen kayıt bulunamadıysa kitap bilgilerini temizle
                    txtKitapAdi.Text = "";
                    txtYazari.Text = "";
                    txtYayinevi.Text = "";
                    txtSayfaSayisi.Text = "";
                }

                // Veritabanı bağlantısını kapat
                baglanti.Close();
            }
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Kitap kaydı silinsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["barkodno"] != null && dataGridView1.CurrentRow.Cells["barkodno"].Value != null)
                    {
                        string barkodNoValue = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();

                        baglanti.Open();
                        SqlCommand deleteSepetCommand = new SqlCommand("DELETE FROM sepet WHERE barkodno = @barkodno", baglanti);
                        deleteSepetCommand.Parameters.AddWithValue("@barkodno", barkodNoValue);
                        deleteSepetCommand.ExecuteNonQuery();

                        baglanti.Close();

                        MessageBox.Show("Silindi.", "Silme İşlemi");
                        daset.Tables["sepet"].Clear();
                        sepetlistele();

                        lblKitapSayi.Text = "";
                        kitapsayisi();
                    }
                    else
                    {
                        // Hata durumunu ele alın veya kullanıcıya bir mesaj gösterin
                    }
                }
            }
        }






        //teslim edilen kitap sayısı max 3 olabilir 0 olamaz null değer olamaz 3'ten fazla olduğunda veya null veya 0 olduğunda hata mesajı gönderir
        //emanet kitaplardaki bilgileri çeker
        private void btnTeslimEt_Click(object sender, EventArgs e)
        {
            string tc = txtTcAra.Text;

            // Girilen TC numarasına sahip kullanıcıyı kontrol et
            baglanti.Open();
            SqlCommand kontrolKomutu = new SqlCommand("select count(*) from uye where tc = @tc", baglanti);
            kontrolKomutu.Parameters.AddWithValue("@tc", tc);
            int kullaniciSayisi = (int)kontrolKomutu.ExecuteScalar();
            baglanti.Close();

            if (kullaniciSayisi == 0)
            {
                MessageBox.Show("Böyle bir kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(lblKitapSayi.Text))
            {
                if ((string.IsNullOrEmpty(lblKayitliKitapSayi.Text) && int.Parse(lblKitapSayi.Text) <= 3) ||
                    (!string.IsNullOrEmpty(lblKayitliKitapSayi.Text) && int.Parse(lblKayitliKitapSayi.Text) + int.Parse(lblKitapSayi.Text) <= 3))
                {
                    if (!string.IsNullOrEmpty(txtTcAra.Text) && !string.IsNullOrEmpty(txtAdSoyad.Text) &&
                        !string.IsNullOrEmpty(txtYas.Text) && !string.IsNullOrEmpty(txtTelefon.Text))
                    {
                        baglanti.Open();
                        SqlCommand maxEmanetIDKomutu = new SqlCommand("SELECT MAX(emanetid) FROM emanetkitaplar", baglanti);
                        int sonEmanetID = 0;
                        var result = maxEmanetIDKomutu.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                            sonEmanetID = (int)result;
                        baglanti.Close();

                        int emanetID = sonEmanetID + 1;

                        baglanti.Open();
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            SqlCommand komut = new SqlCommand("insert into emanetkitaplar(emanetid, tc, adsoyad, yas, telefon, barkodno, kitapadi, yazari, yayinevi, sayfasayisi, kitapsayisi, teslimtarihi, iadetarihi) " +
                                "values(@emanetid, @tc, @adsoyad, @yas, @telefon, @barkodno, @kitapadi, @yazari, @yayinevi, @sayfasayisi, @kitapsayisi, @teslimtarihi, @iadetarihi)", baglanti);
                            komut.Parameters.AddWithValue("@emanetid", emanetID);
                            komut.Parameters.AddWithValue("@tc", txtTcAra.Text);
                            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                            komut.Parameters.AddWithValue("@yas", txtYas.Text);
                            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                            komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapadi", dataGridView1.Rows[i].Cells["kitapadi"].Value.ToString());
                            komut.Parameters.AddWithValue("@yazari", dataGridView1.Rows[i].Cells["yazari"].Value.ToString());
                            komut.Parameters.AddWithValue("@yayinevi", dataGridView1.Rows[i].Cells["yayinevi"].Value.ToString());
                            komut.Parameters.AddWithValue("@sayfasayisi", dataGridView1.Rows[i].Cells["sayfasayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()));
                            komut.Parameters.AddWithValue("@teslimtarihi", dataGridView1.Rows[i].Cells["teslimtarihi"].Value.ToString());
                            komut.Parameters.AddWithValue("@iadetarihi", dataGridView1.Rows[i].Cells["iadetarihi"].Value.ToString());

                            komut.ExecuteNonQuery();

                            SqlCommand komut2 = new SqlCommand("update uye set okukitapsayisi=okukitapsayisi+'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where tc='" + txtTcAra.Text + "' ", baglanti);
                            komut2.ExecuteNonQuery();

                            SqlCommand komut3 = new SqlCommand("update kitap set stoksayisi=stoksayisi-'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where barkodno='" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "' ", baglanti);
                            komut3.ExecuteNonQuery();
                        }
                        baglanti.Close();

                        baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("delete from sepet", baglanti);
                        komut4.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("Kitap emanet edildi.");
                        daset.Tables["sepet"].Clear();
                        sepetlistele();
                        txtTcAra.Text = "";

                        lblKitapSayi.Text = "";
                        kitapsayisi();

                        foreach (Control item in grpUyeBilgi.Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = "";
                                lblKayitliKitapSayi.Text = "";
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eksik bilgi girişi yapıldı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Teslim edilecek kitap sayısı 3'ten fazla olamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Sepet boş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}




