using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayıBulmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int atananSayi=0;
        private void button1_Click(object sender, EventArgs e)
        {
            //double atananSayi;
            textBox7.Enabled = false;
            Random rnd = new Random();
            if (radioButton1.Checked==true)
            {
                if (numericUpDown1.Value == 2)
                {
                    atananSayi = rnd.Next(9, 100);
                    TxtBoxAc();
                }
                else if (numericUpDown1.Value == 3)
                {
                    atananSayi = rnd.Next(99, 1000);
                    TxtBoxAc();
                }
                else if (numericUpDown1.Value == 4)
                {
                    TxtBoxAc();
                    atananSayi = rnd.Next(999, 10000);
                }
                else if (numericUpDown1.Value == 5)
                {
                    TxtBoxAc();
                    atananSayi = rnd.Next(9999, 100000);
                }
                else
                {
                    TxtBoxAc();
                    atananSayi = rnd.Next(99999, 1000000);
                }
                label12.Text = atananSayi.ToString();
            }
            else
            { 
                if (numericUpDown1.Value == 2)
                {
                    atananSayi = SayiUret()%100;
                    TxtBoxAc();
                }
                else if (numericUpDown1.Value == 3)
                {
                    atananSayi = SayiUret() % 1000;
                    TxtBoxAc();
                }
                else if (numericUpDown1.Value == 4)
                {
                    atananSayi = SayiUret() % 10000;
                    TxtBoxAc();
                    
                }
                else if (numericUpDown1.Value == 5)
                {
                    atananSayi = SayiUret() % 100000;
                    TxtBoxAc();
                    
                }
                else
                {
                    atananSayi = SayiUret();
                    TxtBoxAc();
                }
                label12.Text = atananSayi.ToString();
            }
            timer1.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Resetle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Sayı bulmaca oyununa hoş geldiniz\n" +
                "Sayı belirlediğiniz zaman süreniz başlayacaktır\n" +
                "Girdiğiniz sayıdaki rakamlar kontrol edilecektir\n" +
                "Eğer doğru rakam doğru yerdeyse altında mavi yanacak\n" +
                "Eğer rakam, sayıda başka bir yerdeyse ama sayıda varsa\n" +
                "altında kırmızı yanacak, rakam sayıda yoksa sarı yanacak.\n" +
                "En fazla 9 hak isteyebilirsiniz! Başarılar!:D");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (atananSayi==0)
            {
                TxtBoxAc();
            }
            else
            {
                MessageBox.Show("Sayı atanmıştır, basamakta değişiklik yapılamaz");
            }
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label8.Text == "0")
            {
                if (textBox7.Text == "0")
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Canınız Bitmiştir! Tutulan Sayı: "+atananSayi);
                }
                else
                {
                    textBox7.Text = Convert.ToString(int.Parse(textBox7.Text) - 1);
                    label8.Text = "60";
                }
            }
            else label8.Text = Convert.ToString(int.Parse(label8.Text)-1);
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text!="0")
            {
                string randomSayi = Convert.ToString(atananSayi);
                string tahminSayi = null;
                int döngü = Convert.ToInt32(numericUpDown1.Value);
                tahminSayi += textBox1.Text;
                tahminSayi += textBox2.Text;
                tahminSayi += textBox3.Text;
                tahminSayi += textBox4.Text;
                tahminSayi += textBox5.Text;
                tahminSayi += textBox6.Text;
                label19.Text = tahminSayi;
                if (tahminSayi.Equals(randomSayi))
                {
                    MessageBox.Show("TEBRİKLER BİLDİNİZ");
                    Resetle();
                }
                else
                {
                    lbl6.BackColor = Color.Yellow;
                    lbl5.BackColor = Color.Yellow;
                    lbl4.BackColor = Color.Yellow;
                    lbl3.BackColor = Color.Yellow;
                    lbl2.BackColor = Color.Yellow;
                    lbl1.BackColor = Color.Yellow;
                    for (int i = 0; i < döngü; i++)
                    {
                        for (int j = 0; j < döngü; j++)
                        {
                            if (randomSayi[i] == tahminSayi[j])
                            {
                                SayiKontrol(i, j, döngü);
                            }
                        }
                    }
                    textBox7.Text = Convert.ToString(int.Parse(textBox7.Text) - 1);
                    label8.Text = "60";
                }
            }
            else
            {
                MessageBox.Show("Caniniz bitmiştir! Tutulan sayi: " + atananSayi);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.textBox1.Modified = false; // Get next event.

            // Check text input
            if (this.textBox1.Text.Length == this.textBox1.MaxLength)
            {
                Control nextInTabOrder = GetNextControl(this, true);
                textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.Modified = false; // Get next event.

            // Check text input
            if (this.textBox2.Text.Length == this.textBox1.MaxLength)
            {
                Control nextInTabOrder = GetNextControl(this, true);
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            this.textBox3.Modified = false; // Get next event.

            // Check text input
            if (this.textBox3.Text.Length == this.textBox1.MaxLength)
            {
                Control nextInTabOrder = GetNextControl(this, true);
                textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.textBox4.Modified = false; // Get next event.

            // Check text input
            if (this.textBox4.Text.Length == this.textBox4.MaxLength)
            {
                Control nextInTabOrder = GetNextControl(this, true);
                textBox5.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.textBox5.Modified = false; // Get next event.

            // Check text input
            if (this.textBox5.Text.Length == this.textBox5.MaxLength)
            {
                Control nextInTabOrder = GetNextControl(this, true);
                textBox6.Focus();
            }
        }
        public void TxtBoxAc()
        {
            if (numericUpDown1.Value == 2)
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = false;
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                textBox1.Enabled = false;
            }
            else if (numericUpDown1.Value == 3)
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = false;
                textBox2.Enabled = false;
                textBox1.Enabled = false;
            }
            else if (numericUpDown1.Value == 4)
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox2.Enabled = false;
                textBox1.Enabled = false;

            }
            else if (numericUpDown1.Value == 5)
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = false;
            }
            else
            {
                textBox6.Enabled = true;
                textBox5.Enabled = true;
                textBox4.Enabled = true;
                textBox3.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Enabled = true;
            }
        }
        public void SayiKontrol(int i,int j,int döngü)
        {
            
            if (i == j)
            {
                if (döngü == 2)
                {
                    if (i == 0)
                    {
                        lbl5.BackColor = Color.Blue;
                    }
                    else if (i == 1)
                    {
                        lbl6.BackColor = Color.Blue;
                    }
                }
                else if (döngü == 3)
                {
                    if (i == 0)
                    {
                        lbl4.BackColor = Color.Blue;
                    }
                    else if (i == 1)
                    {
                        lbl5.BackColor = Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl6.BackColor = Color.Blue;
                    }
                }
                else if (döngü == 4)
                {
                    if (i == 0)
                    {
                        lbl3.BackColor = Color.Blue;
                    }
                    else if (i == 1)
                    {
                        lbl4.BackColor = Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl5.BackColor = Color.Blue;
                    }
                    else if (i == 3)
                    {
                        lbl6.BackColor = Color.Blue;
                    }
                }
                else if (döngü == 5)
                {
                    if (i == 0)
                    {
                        lbl2.BackColor = Color.Blue;
                    }
                    else if (i == 1)
                    {
                        lbl3.BackColor = Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl4.BackColor = Color.Blue;
                    }
                    else if (i == 3)
                    {
                        lbl5.BackColor = Color.Blue;
                    }
                    else if (i == 4)
                    {
                        lbl6.BackColor = Color.Blue;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        lbl1.BackColor = Color.Blue;
                    }
                    else if (i == 1)
                    {
                        lbl2.BackColor = Color.Blue;
                    }
                    else if (i == 2)
                    {
                        lbl3.BackColor = Color.Blue;
                    }
                    else if (i == 3)
                    {
                        lbl4.BackColor = Color.Blue;
                    }
                    else if (i == 4)
                    {
                        lbl5.BackColor = Color.Blue;
                    }
                    else if (i == 5)
                    {
                        lbl6.BackColor = Color.Blue;
                    }
                }
            }
            else
            {
                if (döngü == 2)
                {
                    if (j == 0)
                    {
                        lbl5.BackColor = Color.Red;
                    }
                    else if (j == 1)
                    {
                        lbl6.BackColor = Color.Red;
                    }
                }
                else if (döngü == 3)
                {
                    if (j == 0)
                    {
                        lbl4.BackColor = Color.Red;
                    }
                    else if (j == 1)
                    {
                        lbl5.BackColor = Color.Red;
                    }
                    else if (j == 2)
                    {
                        lbl6.BackColor = Color.Red;
                    }
                }
                else if (döngü == 4)
                {
                    if (j == 0)
                    {
                        lbl3.BackColor = Color.Red;
                    }
                    else if (j == 1)
                    {
                        lbl4.BackColor = Color.Red;
                    }
                    else if (j == 2)
                    {
                        lbl5.BackColor = Color.Red;
                    }
                    else if (j == 3)
                    {
                        lbl6.BackColor = Color.Red;
                    }
                }
                else if (döngü == 5)
                {
                    if (j == 0)
                    {
                        lbl2.BackColor = Color.Red;
                    }
                    else if (j == 1)
                    {
                        lbl3.BackColor = Color.Red;
                    }
                    else if (j == 2)
                    {
                        lbl4.BackColor = Color.Red;
                    }
                    else if (j == 3)
                    {
                        lbl5.BackColor = Color.Red;
                    }
                    else if (j == 4)
                    {
                        lbl6.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        lbl1.BackColor = Color.Red;
                    }
                    else if (i == 1)
                    {
                        lbl2.BackColor = Color.Red;
                    }
                    else if (i == 2)
                    {
                        lbl3.BackColor = Color.Red;
                    }
                    else if (i == 3)
                    {
                        lbl4.BackColor = Color.Red;
                    }
                    else if (i == 4)
                    {
                        lbl5.BackColor = Color.Red;
                    }
                    else if (i == 5)
                    {
                        lbl6.BackColor = Color.Red;
                    }
                }
            }
        }

        
        public int SayiUret()
        {

            Random rnd = new Random();
            int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0;
            string sayi = "";
            /*int rastgele=rnd.Next(99999, 1000000);
            a = (rastgele / 100000) % 10;
            b = (rastgele / 10000) % 10;
            c = (rastgele / 1000)%10;
            d = (rastgele / 100) % 10;
            e = (rastgele / 10) % 10;
            f = rastgele % 10;*/
            int döngü = 0;
            while (döngü < 10000)//bu kısım 4 sirali rakamin sayının uretıldıgı kısım
            {
                döngü++;

                int rastgele = rnd.Next(99999, 1000000);
                a = (rastgele / 100000) % 10;
                b = (rastgele / 10000) % 10;
                c = (rastgele / 1000) % 10;
                d = (rastgele / 100) % 10;
                e = (rastgele / 10) % 10;
                f = rastgele % 10;


                if (a != b && a != c && a != d && a != e && a != f
                    && b != c && b != d && b != e && b != f &&
                    c != d && c != e && c != f && d != e && d != f
                    && e != f)
                   
                {//burası üretilen sayının rakamlarının

                    sayi += Convert.ToString(a);
                    sayi += Convert.ToString(b);
                    sayi += Convert.ToString(c);
                    sayi += Convert.ToString(d);
                    sayi += Convert.ToString(e);
                    sayi += Convert.ToString(f);
                    break;
                }
                //farklı olması için
            }
            return int.Parse(sayi);
        }
        public void Resetle()
        {
            atananSayi = 0;
            textBox6.Clear();
            textBox5.Clear();
            textBox4.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox1.Clear();
            textBox6.Enabled = false;
            textBox5.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            label8.Text = "60";
            textBox7.Text = "5";
            textBox7.Enabled = true;
            timer1.Enabled = false;
            lbl6.BackColor = Color.Yellow;
            lbl5.BackColor = Color.Yellow;
            lbl4.BackColor = Color.Yellow;
            lbl3.BackColor = Color.Yellow;
            lbl2.BackColor = Color.Yellow;
            lbl1.BackColor = Color.Yellow;
        }
    }
}