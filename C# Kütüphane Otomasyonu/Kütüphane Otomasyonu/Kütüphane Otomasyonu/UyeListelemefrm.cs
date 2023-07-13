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
    public partial class UyeListelemefrm : Form
    {
        public UyeListelemefrm()
        {
            InitializeComponent();
        }

        private void UyeListelemefrm_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NEG801R;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");

        //Data Grid dosyaları göstermesi için.
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }

        // Güncelleme  yapması için.

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from uye where tc like '"+txtTc.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text = read["yas"].ToString();
                comboCinsiyet.Text = read["cinsiyet"].ToString();
                txtTelefon.Text = read["telefon"].ToString();
                txtAdres.Text = read["adres"].ToString();
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtEmail.Text = read["Email"].ToString();
                txtOkunanSayi.Text = read["okukitapsayisi"].ToString();


            }
            baglanti.Close();
        }

        //Geçici kayıt için.

        DataSet daset= new DataSet();   

        //Tc Araması için.
        private void txtAraTc_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["uye"].Clear();

            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from uye where tc like '%" + txtAraTc.Text + "%'", baglanti);
            adtr.Fill(daset,"uye");
            dataGridView1.DataSource = daset.Tables["uye"];
            baglanti.Close();

        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Sil butonu.
        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Kaydınız silinecektir!", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    if (dataGridView1.CurrentRow.Cells["tc"].Value != null)
                    {
                        string tcValue = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();

                        baglanti.Open();
                        SqlCommand komut = new SqlCommand("delete from uye where tc=@tc", baglanti);
                        komut.Parameters.AddWithValue("@tc", tcValue);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Silme işlemi tamamlandı.");
                        daset.Tables["uye"].Clear();

                        //private void uyelistele() işlemi için.
                        uyelistele();

                        foreach (Control item in Controls)
                        {
                            if (item is TextBox)
                            {
                                item.Text = "";
                            }
                        }
                    }
                    else
                    {
                        // Hata durumunu ele alın veya kullanıcıya bir mesaj gösterin
                    }
                }
            }
        }

        private void uyelistele()
        {
            baglanti.Open();    
            SqlDataAdapter adtr = new SqlDataAdapter("select *from uye",baglanti);
            adtr.Fill(daset, "uye");
            dataGridView1.DataSource = daset.Tables["uye"];
            baglanti.Close();

        }

        //Güncelle
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string arananTc = txtTc.Text;

            // TC değerini kullanarak veritabanında üye arama işlemi yapılır
            string aramaSorgusu = "SELECT COUNT(*) FROM uye WHERE tc = @tc";
            SqlCommand aramaKomutu = new SqlCommand(aramaSorgusu, baglanti);
            aramaKomutu.Parameters.AddWithValue("@tc", arananTc);

            baglanti.Open();
            int uyeSayisi = (int)aramaKomutu.ExecuteScalar();
            baglanti.Close();

            if (uyeSayisi == 0)
            {
                MessageBox.Show("Üye bilgisi giriniz!");
                return;
            }

            // Eşleşme olduğunda güncelleme işlemini devam ettirir
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update uye set adsoyad=@adsoyad,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,email=@email,okukitapsayisi=@okukitapsayisi where tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@yas", txtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.Parameters.AddWithValue("@okukitapsayisi", int.Parse(txtOkunanSayi.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncellendi.");

            daset.Tables["uye"].Clear();

            uyelistele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }


    }
}
