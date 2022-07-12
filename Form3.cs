using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace soft
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            string[] x = Config.capitole().Split("\n");
            foreach(string i in x)
            {
                comboBox1.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cap = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (textBox3.Text.Length > 0)
            {
                cap = textBox3.Text;
            }
            string nume = textBox1.Text;
            string descriere = textBox2.Text;
            string algoritm = richTextBox1.Text;
            if (Config.isValidAlgoritm(algoritm))
            {
                Config.adaugaAlgoritm(cap, nume, descriere, algoritm);
                this.Close();
            }
            else
            {
                string[] x = File.ReadAllText("error.txt").Split("\n");
                if(x[1].Contains("expected ';'"))
                {
                        //linie 1 in minus
                    MessageBox.Show("Algoritmul introdus are greseli.\n\nFii atent deasupra liniei care contine\n" + x[2]);
                }
                else if(x[1].Contains("was not declared in this scope"))
                {
                    //linie exacta
                    MessageBox.Show("Algoritmul introdus are greseli.\n\nVariabila declarata de tine nu exista sau tipul de date este scris gresit.\nFii atent la linia care contine\n" + x[2]);
                }
                else if(x[1].Contains("expected primary-expression"))
                {
                    //linie exacta
                    MessageBox.Show("Algoritmul introdus are greseli.\n\nExpresia sau operatia nu este corecta.\nFii atent la linia:\n" + x[2]);
                }
                else MessageBox.Show("Algoritmul introdus are greseli.\n" + File.ReadAllText("error.txt").ToString());
            }
        }
    }
}
