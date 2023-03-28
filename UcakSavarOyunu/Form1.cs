using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UcakSavarOyunu.Properties;

namespace UcakSavarOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PictureBox ucakSavar=new PictureBox();
        PictureBox ucak=new PictureBox();   
        PictureBox mermi=new PictureBox();  
        ArrayList mermiList= new ArrayList();
        ArrayList dusmanUcak=   new ArrayList();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ucakSavar.Image = Resources.vurucak;
            this.Controls.Add(ucakSavar);
            ucakSavar.Location=new Point(300,330);
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dusmanUcak.Add(ucakUret());
            foreach (PictureBox item in dusmanUcak)
            {
                UcakHareket(item);
            }
        }

        private void UcakHareket(PictureBox item)
        {
            ucak.Image = Resources.vurulcak;
            int x = ucak.Location.X;    
            int y = ucak.Location.Y;
            y += 5;
            ucak.Location = new Point(x, y);
            this.Controls.Add(ucak);
        }

        private object ucakUret()
        {
            PictureBox ucak = new PictureBox();
            ucak.Image = Resources.vurulcak;
            Random rnd=new Random();
            int ucakBaslat = rnd.Next(1000);
            ucak.Location = new Point(ucakBaslat,0); 
            timer3.Enabled = true;
            return ucak;    
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            UcakSavarHareket(e);
            if (e.KeyCode == Keys.Escape)
            {
                mermiList.Add(MermiUret());
                timer2.Enabled= true;  
            }
        }

        private object MermiUret()
        {
           PictureBox mermi= new PictureBox();
            mermi.Image = Resources.mermi;
            mermi.SizeMode= PictureBoxSizeMode.StretchImage;
            mermi.Location = new Point(ucakSavar.Location.X,ucakSavar.Location.Y);
            this.Controls.Add(mermi);
            return mermi;
         
        }

        private void UcakSavarHareket(KeyEventArgs e)
        {
            int ucakSavarx=ucakSavar.Location.X;
            int ucakSavary= ucakSavar.Location.Y;

            if (e.KeyCode==Keys.Right)
                ucakSavarx += 5;
            else if(e.KeyCode==Keys.Left)
                ucakSavarx -= 5;
            ucakSavar.Location = new Point(ucakSavarx, ucakSavary);
            this.Controls.Add(ucakSavar);
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox herhangi in mermiList)
            {
                MermiHareket(herhangi);
            }
        }

        private void MermiHareket(PictureBox mermi)
        {
            mermi.Image = Resources.mermi;
            int x=mermi.Location.X;
            int y=mermi.Location.Y;
            y -= 5;
            mermi.Location = new Point(x, y);
            this.Controls.Add(mermi);
        }

        private int sayi = 0;
        PictureBox kaldirilanUcaklar=new PictureBox();
        PictureBox kaldirilanMermiler=      new PictureBox();

        private void timer3_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox item1 in mermiList)
            {
                foreach (PictureBox item2 in dusmanUcak)
                {
                    if (item1.Bounds.IntersectsWith(item2.Bounds))
                    {
                        this.Controls.Remove(item1);
                        this.Controls.Remove(item2);
                        kaldirilanMermiler = item1;
                        kaldirilanUcaklar = item2;
                        points.Text=sayi.ToString();    
                    }
                }
                
            }
            mermiList.Remove(kaldirilanMermiler);
            dusmanUcak.Remove(kaldirilanUcaklar);


        }
    }
}
