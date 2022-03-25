using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;


namespace shellby
{
    public partial class adminpanel : Form
    {
        private Point lastPoint;
        public adminpanel()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=dbLogin.accdb"); // databasenin yolunu bul ve bağlan
        public DataTable tablo = new DataTable(); // databaseyi kontol et 
        public OleDbDataAdapter adtr = new OleDbDataAdapter(); // bağlan
        public OleDbCommand kmt = new OleDbCommand();
        string DosyaYolu, DosyaAdi = "";
        int id;


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listele();
            timer1.Start(); // timer1 adlı fonksiyonu başlat 

        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X; // formu yönlendirme fonksiyonları 
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void bunifuIconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage1"); // butona basıldığında tabpage1 e yönlendir
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage2");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("tabPage3");
        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }


        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }








        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnStokModelAra_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() == "") errorProvider1.SetError(textBox1, "Boş geçilmez");
                else errorProvider1.SetError(textBox1, "");
                if (textBox2.Text.Trim() == "") errorProvider1.SetError(textBox2, "Boş geçilmez");
                else errorProvider1.SetError(textBox2, "");

                if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
                {
                    bag.Open();
                    kmt.Connection = bag;
                    kmt.CommandText = "INSERT INTO LoginAdmin(kullanici,sifre) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "',') ";
                    kmt.ExecuteNonQuery();
                    kmt.Dispose();
                    bag.Close();
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i] is TextBox) this.Controls[i].Text = "";
                    }
                    listele();
                }

            }
            catch
            {
                MessageBox.Show("Kayıtlı Seri No !");
                bag.Close();
            }
        }

        public void listele() // listele fonksyionu datagriende yazdırır ve güncellemeye yarar 
        {
            tablo.Clear(); // tabloyu temizle 
            bag.Open(); // database bağlantısını sağla 
            OleDbDataAdapter adtr = new OleDbDataAdapter("select kullanici, sifre From Login", bag); // database içinden verileri seç 
            adtr.Fill(tablo); // verileri tabloya ekle 
            bunifuDataGridView1.DataSource = tablo; // tablo 1 
            adtr.Dispose(); // ekle 
            bag.Close(); // kapat 
            try // dene 
            {
                bunifuDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // herşeyi seç ve ekle 
                //bunifuDataGridView1'deki tüm satırı seç              
                bunifuDataGridView1.Columns[0].HeaderText = "Öğrenci Kullanıcı Adı";
                //sütunlardaki textleri değiştirme
                bunifuDataGridView1.Columns[1].HeaderText = "Öğrenci Şifresi";
                bunifuDataGridView1.Columns[0].Width = 120;
                //genişlik
                bunifuDataGridView1.Columns[1].Width = 120;
            }
            catch
            {
                ;
            }
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
