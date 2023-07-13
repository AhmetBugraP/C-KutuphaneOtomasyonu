using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class EmanetKitapİadefrm : Form
    {
        public EmanetKitapİadefrm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-NEG801R;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();

        private void EmanetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from EmanetKitaplar", baglanti);
            adtr.Fill(daset, "EmanetKitaplar");
            dataGridView1.DataSource = daset.Tables["EmanetKitaplar"];
            baglanti.Close();
        }

        private void EmanetKitapİadefrm_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["EmanetKitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from EmanetKitaplar where tc like '%" + txtTcAra.Text + "%'", baglanti);
            adtr.Fill(daset, "EmanetKitaplar");
            baglanti.Close();
            if (txtTcAra.Text == "")
            {
                daset.Tables["EmanetKitaplar"].Clear();
                EmanetListele();
            }
        }

        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["EmanetKitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from EmanetKitaplar where barkodno like '%" + txtBarkodNoAra.Text + "%'", baglanti);
            adtr.Fill(daset, "EmanetKitaplar");
            baglanti.Close();
            if (txtBarkodNoAra.Text == "")
            {
                daset.Tables["EmanetKitaplar"].Clear();
                EmanetListele();
            }
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string emanetId = dataGridView1.CurrentRow.Cells["emanetid"].Value.ToString();

                baglanti.Open();

                SqlCommand emanetSil = new SqlCommand("DELETE FROM EmanetKitaplar WHERE emanetid=@emanetid", baglanti);
                emanetSil.Parameters.AddWithValue("@emanetid", emanetId);
                emanetSil.ExecuteNonQuery();

                string barkodNo = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
                int kitapSayisi = Convert.ToInt32(dataGridView1.CurrentRow.Cells["kitapsayisi"].Value);

                SqlCommand stokEkle = new SqlCommand("UPDATE Kitap SET stoksayisi=stoksayisi+@kitapsayisi WHERE barkodno=@barkodno", baglanti);
                stokEkle.Parameters.AddWithValue("@kitapsayisi", kitapSayisi);
                stokEkle.Parameters.AddWithValue("@barkodno", barkodNo);
                stokEkle.ExecuteNonQuery();

                baglanti.Close();

                MessageBox.Show("Kitap iade edildi.");

                daset.Tables["EmanetKitaplar"].Clear();
                EmanetListele();
            }
            else
            {
                MessageBox.Show("Lütfen bir emanet seçin.", "Hata");
            }
        }


    }
}
