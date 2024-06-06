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
        private DatabaseHelper dbHelper;
        public ogretimeleman()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadGrades();
        }
        private void LoadGrades()
        {
            DataTable grades = dbHelper.GetUpdatedGrades();
            dataGridView1.DataSource = grades;
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
            // Güncellenen notları yükle ve göster
            LoadGrades();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ogretimeleman_Load(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
