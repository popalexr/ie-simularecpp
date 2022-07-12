using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace soft
{
    public partial class Form4 : Form
    {
        private Config c = new Config();

        private void HighlightText(string word, Color color)
        {

            if (word == string.Empty)
                return;

            int s_start = richTextBox1.SelectionStart, startIndex = 0, index;

            while ((index = richTextBox1.Text.IndexOf(word, startIndex)) != -1)
            {
                richTextBox1.Select(index, word.Length);
                richTextBox1.SelectionBackColor = color;
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);

                startIndex = index + word.Length;
            }

            richTextBox1.SelectionStart = s_start;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionBackColor = Color.Black;
        }

        public Form4()
        {
            InitializeComponent();
            label1.Text = Config.nume_alg;
            label2.Text = Config.cls_alg;
            richTextBox1.Text = c.getAlgoritm(Config.nume_alg, Config.cls_alg);
            label3.Text += "\n- " + c.descriere(Config.cls_alg, Config.nume_alg);
            label5.Text += Config.nr_variabile.ToString();
            //label 4 - TIP DATE
            label4.Text += "\n- ";
            if (Config.tip_date[0] > 0) label4.Text += "INT  ";
            if (Config.tip_date[1] > 0) label4.Text += "FLOAT  ";
            if (Config.tip_date[2] > 0) label4.Text += "DOUBLE  ";
            if (Config.tip_date[3] > 0) label4.Text += "CHAR  ";
            if (Config.tip_date[4] > 0) label4.Text += "SHORT  ";
            if (Config.tip_date[5] > 0) label4.Text += "BOOL  ";

            label7.Text += Config.structuri[0].ToString();
            label8.Text += Config.structuri[1].ToString();
            label9.Text += Config.structuri[2].ToString();
            label10.Text += Config.structuri[3].ToString();
            label11.Text += Config.structuri[4].ToString();

            HighlightText("if", Color.Gold);
            HighlightText("else", Color.Gold);
            HighlightText("while", Color.LightBlue);
            HighlightText("do", Color.LightBlue);
            HighlightText("for", Color.Pink);
            HighlightText("switch", Color.Yellow);

        }

        private void label7_Click(object sender, EventArgs e)
        {
            //Label  - IF -
            MessageBox.Show("Instructiunea IF este o structura de calcul alternativa, care permite in functie de anumite conditii executarea (sau neexecutarea) unei anumite instructiuni sau secvente de instructiuni.\n\nIF-ul se foloseste (optional) alaturi de ELSE; in cazul in care expresia din IF este falsa, se vor executa instructiunile din ELSE.", "Structura IF");
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //Label  - WHILE -
            MessageBox.Show("WHILE este o structura repetitiva, care permite, in cazul in care expresia este adevarata, repetarea instructiunilor din interiorul structurii.\n\nMinimul de repetitii pentru aceasta structura este 0, asta insemnand ca pot exista cazuri cand instructiunile din WHILE sa nu fie executate deloc, daca expresia este falsa.\nStructura se mai numeste si structura repetitiva cu test initial, cu numar necunoscut de pasi.", "Structura WHILE");
        }

        private void label9_Click(object sender, EventArgs e)
        {
            //Label  - DO... WHILE -
            MessageBox.Show("DO... WHILE este o structura repetitiva, care permite, in cazul in care expresia este adevarata, repetarea instructiunilor din interiorul structurii.\n\nSpre deosebire de WHILE, minimul de repetitii pentru aceasta structura este 1, asta insemnand ca indiferent dacă expresia din WHILE este falsa, se va intra in DO... WHILE cel putin o data.\nStructura se mai numeste si structura repetitiva cu test final, cu numar necunoscut de pasi.", "Structura DO... WHILE");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //Label  - FOR -
            MessageBox.Show("FOR este o structura repetitiva, care permite repetarea instructiunilor din interiorul acestuia, daca expresia este adevarata.\n\nStructura FOR-ului este for(INITIALIZARE_CONTOR, EXPRESIE_VERIFICARE_CONTOR, PAS_CONTOR). Numarul minim de repetitii pentru FOR este 0.\nAceasta structura se mai numeste si structura repetitiva cu numar cunoscut de pasi.", "Structura FOR");
        }

        private void label11_Click(object sender, EventArgs e)
        {
            //Label  - SWITCH -
            MessageBox.Show("SWITCH este o structura de decizie, ce se bazeaza pe cazuri. Structura de baza este:\n\nswitch(variabila pt care avem cazuri) {\ncase caz1:\n//block de instructiuni\nbreak;\ncase caz2:\n//block de instructiuni\nbreak;\ncase default:\n//block de instructiuni\nbreak;\n}\n\nbreak are rolul de a iesi instant din switch, insa se poate folosi si pentru structuri repetitive, pentru a iesi din ele fortat.\ncase default: este echivalentul ELSE (nu else IF).", "Structura SWITCH");
        }
    }
}
