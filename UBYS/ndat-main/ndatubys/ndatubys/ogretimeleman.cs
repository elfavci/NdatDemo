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

namespace ndatubys
{
    public partial class ogretimeleman : Form
    {
        public ogretimeleman()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void yağısalProgramlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ogrenciNo = textBox1.Text;
            int vizeNot = int.Parse(textBox6.Text);
            int finalNot = int.Parse(textBox4.Text);

            // DatabaseHelper sınıfından bir örnek oluştur
            DatabaseHelper dbHelper = new DatabaseHelper();

            // Veritabanında notları güncelle
            dbHelper.UpdateNot(ogrenciNo, vizeNot, finalNot);

            // Kullanıcıya işlem başarılı mesajı göster
            MessageBox.Show("Notlar başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
