using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.KazanMyo.Windows.HelloWorld
{
    public partial class FrmOyun : Form
    {
        static int toplam = 0;
        static int sure = 3;
        Random rnd = new Random();

        public FrmOyun()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Size = new Size(50, 50);
            btn.Location = new Point(rnd.Next(this.ClientSize.Width-pnlGosterge.Width-btn.Width), rnd.Next(this.ClientSize.Height-btn.Height));
            btn.Text = rnd.Next(100).ToString();
            btn.BackgroundImage = HelloWorld.Properties.Resources.ari2;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
            btn.Click += Btn_Click;
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            toplam += int.Parse(btn.Text);
            lblSkor.Text = $"Skor{toplam}";
            btn.Dispose();
        }

        private void FrmOyun_Load(object sender, EventArgs e)
        {
            tmrButton.Start();
            tmrSure.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tmrSure_Tick(object sender, EventArgs e)
        {
            sure--;
            lblSure.Text = sure.ToString();
            if(sure <= 0)
            {
                tmrButton.Stop();
                tmrSure.Stop();
                string tarih = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                string fileName = @"kayitlar.txt";
                string skor_log = $"Skor => {toplam} Tarih => {tarih}";
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();
                File.AppendAllText(fileName, Environment.NewLine + skor_log);
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show($"Skor: {toplam} Yeniden oynamak ister misin?", "Oyun bitti", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    lblSkor.Text = $"Skor 0";

                    toplam = 0;
                    sure = 5;
                    foreach (Control c in this.Controls.OfType<Button>().ToList())
                    {
                        this.Controls.Remove(c);
                        c.Dispose();
                    }
                    tmrButton.Start();
                    tmrSure.Start();
                }
            }
        }
    }
}
