namespace Kütüphane_Otomasyonu
{
    partial class AnaSayfafrm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUyeListele = new System.Windows.Forms.Button();
            this.btnUyeEkle = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKitapListele = new System.Windows.Forms.Button();
            this.btnKitapEkle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEmanetListele = new System.Windows.Forms.Button();
            this.btnEmanetİade = new System.Windows.Forms.Button();
            this.btnEmanetVer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUyeListele);
            this.groupBox1.Controls.Add(this.btnUyeEkle);
            this.groupBox1.Location = new System.Drawing.Point(55, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üye İşlemleri";
            // 
            // btnUyeListele
            // 
            this.btnUyeListele.Location = new System.Drawing.Point(30, 60);
            this.btnUyeListele.Name = "btnUyeListele";
            this.btnUyeListele.Size = new System.Drawing.Size(203, 23);
            this.btnUyeListele.TabIndex = 1;
            this.btnUyeListele.Text = "Üye Listeleme İşlemleri";
            this.btnUyeListele.UseVisualStyleBackColor = true;
            this.btnUyeListele.Click += new System.EventHandler(this.btnUyeListele_Click);
            // 
            // btnUyeEkle
            // 
            this.btnUyeEkle.Location = new System.Drawing.Point(30, 19);
            this.btnUyeEkle.Name = "btnUyeEkle";
            this.btnUyeEkle.Size = new System.Drawing.Size(203, 23);
            this.btnUyeEkle.TabIndex = 0;
            this.btnUyeEkle.Text = "Üye Ekleme İşlemleri";
            this.btnUyeEkle.UseVisualStyleBackColor = true;
            this.btnUyeEkle.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKitapListele);
            this.groupBox2.Controls.Add(this.btnKitapEkle);
            this.groupBox2.Location = new System.Drawing.Point(322, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kitap İşlemleri";
            // 
            // btnKitapListele
            // 
            this.btnKitapListele.Location = new System.Drawing.Point(43, 60);
            this.btnKitapListele.Name = "btnKitapListele";
            this.btnKitapListele.Size = new System.Drawing.Size(203, 23);
            this.btnKitapListele.TabIndex = 1;
            this.btnKitapListele.Text = "Kitap Listele";
            this.btnKitapListele.UseVisualStyleBackColor = true;
            this.btnKitapListele.Click += new System.EventHandler(this.btnKitapListele_Click);
            // 
            // btnKitapEkle
            // 
            this.btnKitapEkle.Location = new System.Drawing.Point(43, 19);
            this.btnKitapEkle.Name = "btnKitapEkle";
            this.btnKitapEkle.Size = new System.Drawing.Size(203, 23);
            this.btnKitapEkle.TabIndex = 0;
            this.btnKitapEkle.Text = "Kitap Ekleme İşlemleri";
            this.btnKitapEkle.UseVisualStyleBackColor = true;
            this.btnKitapEkle.Click += new System.EventHandler(this.btnKitapEkle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEmanetListele);
            this.groupBox3.Controls.Add(this.btnEmanetİade);
            this.groupBox3.Controls.Add(this.btnEmanetVer);
            this.groupBox3.Location = new System.Drawing.Point(55, 250);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(269, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Emanet Kitap İşlemleri";
            // 
            // btnEmanetListele
            // 
            this.btnEmanetListele.Location = new System.Drawing.Point(30, 42);
            this.btnEmanetListele.Name = "btnEmanetListele";
            this.btnEmanetListele.Size = new System.Drawing.Size(203, 23);
            this.btnEmanetListele.TabIndex = 2;
            this.btnEmanetListele.Text = "Emanet  Kitap Listeleme İşlemleri";
            this.btnEmanetListele.UseVisualStyleBackColor = true;
            this.btnEmanetListele.Click += new System.EventHandler(this.btnEmanetListele_Click);
            // 
            // btnEmanetİade
            // 
            this.btnEmanetİade.Location = new System.Drawing.Point(30, 71);
            this.btnEmanetİade.Name = "btnEmanetİade";
            this.btnEmanetİade.Size = new System.Drawing.Size(203, 23);
            this.btnEmanetİade.TabIndex = 1;
            this.btnEmanetİade.Text = "Emanet Kitap İade İşlemleri";
            this.btnEmanetİade.UseVisualStyleBackColor = true;
            this.btnEmanetİade.Click += new System.EventHandler(this.btnEmanetİade_Click);
            // 
            // btnEmanetVer
            // 
            this.btnEmanetVer.Location = new System.Drawing.Point(30, 13);
            this.btnEmanetVer.Name = "btnEmanetVer";
            this.btnEmanetVer.Size = new System.Drawing.Size(203, 23);
            this.btnEmanetVer.TabIndex = 0;
            this.btnEmanetVer.Text = "Emanet Kitap Verme İşlemleri";
            this.btnEmanetVer.UseVisualStyleBackColor = true;
            this.btnEmanetVer.Click += new System.EventHandler(this.button5_Click);
            // 
            // AnaSayfafrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(679, 414);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "AnaSayfafrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.Load += new System.EventHandler(this.AnaSayfafrm_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUyeListele;
        private System.Windows.Forms.Button btnUyeEkle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnKitapListele;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEmanetListele;
        private System.Windows.Forms.Button btnEmanetİade;
        private System.Windows.Forms.Button btnEmanetVer;
    }
}

