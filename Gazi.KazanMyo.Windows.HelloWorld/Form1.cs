using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.KazanMyo.Windows.HelloWorld
{
    public partial class Form1 : Form
    {
        public static int toplam = 0;

        public Form1()
        {
            InitializeComponent();
        }


    private void Form1_Load(object sender, EventArgs e)
        {
            //Load eventinde iş mantığınızı kurgulayabilirsiniz.Form açıldığında yapılacak olan işler.
            System.Random random = new System.Random();

            button1.Text = random.Next(1,15).ToString();
            button2.Text = random.Next(1,15).ToString();
            button3.Text = random.Next(1,15).ToString();

            tmrButton.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int kendideger = Convert.ToInt32(button1.Text);
            toplam += kendideger;
            label2.Text = toplam.ToString();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            int kendideger = Convert.ToInt32(button2.Text);
            toplam += kendideger;
            label2.Text = toplam.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int kendideger = Convert.ToInt32(button3.Text);
            toplam += kendideger;
            label2.Text = toplam.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(toplam.ToString());
        }

        private void tmrButton_Tick(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
