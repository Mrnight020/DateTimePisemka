using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatetimnePisemka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int buttonclick = 0;
        List<string> list = new List<string>();
        List<DateTime> list2 = new List<DateTime>();

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked || radioButton2.Checked)
            {
                
                Random rnd = new Random();
                DateTime datumnarozeni = dateTimePicker1.Value;
                string rodnecislo = datumnarozeni.ToString();


                string[] Datum = rodnecislo.Split(' ');

                list2.Add(DateTime.Parse(Datum[0]));
                string[] rodnecislo2 = Datum[0].Split('.');



                if (radioButton1.Checked)//žena
                {

                    int x = int.Parse(rodnecislo2[1]);
                    x += 50;
                    rodnecislo2[1] = x.ToString();
                }
                // MessageBox.Show("" + rodnecislo2[1]);

                string rok = rodnecislo2[2];
                MessageBox.Show("" + rok);
                string rok2 = rok.Substring(rok.Length - 2);
                MessageBox.Show("" + rok2);
                int random = rnd.Next(100, 999);
                // MessageBox.Show("" + random);
                list.Add(rodnecislo2[0] + rodnecislo2[1] + rok2);
                rodnecislo = rodnecislo2[0] + rodnecislo2[1] + rok2 + random;
                //MessageBox.Show("" + rodnecislo);

                long deleni = long.Parse(rodnecislo + 0);
                int poslednicislice = 0;
                for (int i = 0; i < 10; i++)
                {
                    if (deleni % 11 == 0)
                    {
                        poslednicislice = i;
                        break;
                    }
                    deleni++;
                }
                MessageBox.Show("" + deleni);

                maskedTextBox1.Text = rodnecislo;
                maskedTextBox2.Text = rodnecislo + poslednicislice;
                buttonclick++;
                if (buttonclick >= 2) celkem.Enabled = true;
            }
            
        }

        private void celkem_Click(object sender, EventArgs e)
        {
            DateTime dnes = DateTime.Now;
            int pocetzen = 0;
            int pocetmuzu = 0;
            string nejstarsi = " ";
            string nejmladsi = " ";
            double max = 0;
            double min = 100000000;

            for(int i = 0;i < list2.Count;i++)
            {
                TimeSpan rozdil = dnes - list2[i];
                if(rozdil.TotalDays < min)
                {
                    min = rozdil.TotalDays;
                    nejmladsi = list2[i].ToString();
                }
                if (rozdil.TotalDays > max)
                {
                    max = rozdil.TotalDays;
                    nejstarsi = list2[i].ToString();
                }

            }
            MessageBox.Show("Nejmladi se narodil :" + nejmladsi + " Nejstarsi se narodil :" + nejstarsi);

            foreach(string neco in list)
            {
                string cislo = neco.Substring(2);
                int velikost = int.Parse(cislo);
                if (velikost > 2000) pocetzen++;
                else pocetmuzu++;


            }
            MessageBox.Show("pocet zen :" + pocetzen + "    pocet muzu:"+pocetmuzu);
        }
    }
}
