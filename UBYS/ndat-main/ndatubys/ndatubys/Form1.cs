using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ndatubys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String KimlikNumarası = textBox1.Text;
            String Parola = textBox2.Text;

            DatabaseHelper dbHelper = new DatabaseHelper();
            string userType = dbHelper.ValidateUser(KimlikNumarası, Parola);


            if (userType == "Student")
            {
                MessageBox.Show("Giriş başarılı! Öğrenci ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ogrenciekrani studentMainForm = new ogrenciekrani();
                studentMainForm.Show();
                this.Hide();
            }
            else if (userType == "Teacher")
            {
                MessageBox.Show("Giriş başarılı! Öğretim üyesi ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ogretimeleman teacherMainForm = new ogretimeleman();
                teacherMainForm.Show();
                this.Hide();
            }
            else if (userType == "Idareci")
            {
                MessageBox.Show("Giriş başarılı! Idare ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idareci idareciMainForm = new idareci();
                idareciMainForm.Show();
                this.Hide();
            }
            else if (userType == "SistemYoneticisi")
            {
                MessageBox.Show("Giriş başarılı! Sistem Yönetimi ekranına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SistemYoneticisi syoneticiMainForm = new SistemYoneticisi();
                syoneticiMainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz TC No veya Şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CenterPanel()
        {
            // Panel'in genişliğini ve yüksekliğini al
            int panelWidth = panel1.Width;
            int panelHeight = panel1.Height;

            // Form'un genişliğini ve yüksekliğini al
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Panelin yeni konumunu hesapla
            int newX = (formWidth - panelWidth) / 2;
            int newY = (formHeight - panelHeight) / 2;

            // Panelin konumunu ayarla
            panel1.Location = new Point(newX, newY);
        }
    }
}

