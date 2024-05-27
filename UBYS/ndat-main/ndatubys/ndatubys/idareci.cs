using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ndatubys
{
    public partial class idareci : Form
    {
        public idareci()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }
        private void idareci_Load(object sender, EventArgs e)
        {
            CenterTable();
            // Form boyutu değiştiğinde tableLayoutPanel'in tekrar merkezlenmesi için Resize olayına ekleme yapın.
            this.Resize += new EventHandler(idareci_Resize);
        }

        private void CenterTable()
        {
            // Panel'in genişliğini ve yüksekliğini al
            int tableWidth = tableLayoutPanel1.Width;
            int tableHeight = tableLayoutPanel1.Height;

            // Form'un genişliğini ve yüksekliğini al
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Panelin yeni konumunu hesapla
            int newX = (formWidth - tableWidth) / 2;
            int newY = (formHeight - tableHeight) / 2;

            // Panelin konumunu ayarla
            tableLayoutPanel1.Location = new Point(newX, newY);
        }

        private void idareci_Resize(object sender, EventArgs e)
        {
            // Form yeniden boyutlandırıldığında tableLayoutPanel'i tekrar merkezle
            CenterTable();
        }
    }
}
