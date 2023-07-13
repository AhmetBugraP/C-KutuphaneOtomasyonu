using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class AnaSayfafrm : Form
    {
        public AnaSayfafrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeEklefrm uyeekle = new UyeEklefrm();
            uyeekle.ShowDialog();
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            KitapListelefrm kitaplistele = new KitapListelefrm();
            kitaplistele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            EmanetKitapVerfrm emanetkitap = new EmanetKitapVerfrm();
            emanetkitap.ShowDialog();
        }

        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            UyeListelemefrm uyeliste = new UyeListelemefrm();   
            uyeliste.ShowDialog();
        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapEklefrm kitapEklefrm= new KitapEklefrm();
            kitapEklefrm.ShowDialog();
        }

        private void btnEmanetListele_Click(object sender, EventArgs e)
        {
            EmanetKitapListelefrm listele = new EmanetKitapListelefrm();
            listele.ShowDialog();
        }

        private void btnEmanetİade_Click(object sender, EventArgs e)
        {
            EmanetKitapİadefrm iade =   new EmanetKitapİadefrm();
            iade.ShowDialog();
        }

        private void AnaSayfafrm_Load(object sender, EventArgs e)
        {

        }

        private void AnaSayfafrm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
