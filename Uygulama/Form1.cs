using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uygulama
{
    public partial class Form1 : Form
    {
        /* Form üzerindeki bütün butonları bu listede toplayacağız.*/
        List<Button> FormdakiButonlar = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormdakiButonlar.Clear();
            /* Tüm butonları listeye ekliyoruz */
            foreach (Control eleman in this.Controls)
            {
                if (eleman is Button)
                {
                    FormdakiButonlar.Add(eleman as Button);
                }
            }

            for (int i = 0; i < FormdakiButonlar.Count; i++)
            {
                FormdakiButonlar[i].Click += new EventHandler(Klik);
            }
        }

        void KlikCikar(string klik)
        {
            string text = "";
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] != Convert.ToChar(klik))
                {
                    text += Convert.ToString(textBox1.Text[i]);    
                }
            }
            textBox1.Text = text;

        }

        void Klik(object sender, EventArgs e) 
        {
            Button TiklananButon = sender as Button;

            if (textBox1.Text.IndexOf(Convert.ToChar(TiklananButon.Text), 0) >= 0)
            {
                KlikCikar(TiklananButon.Text);
                TiklananButon.UseVisualStyleBackColor = true;
            }
            else
            {
                textBox1.Text += TiklananButon.Text;
                TiklananButon.BackColor = Color.Red;
                textBox1.Focus();
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }

        
        

        
       
    }
}
