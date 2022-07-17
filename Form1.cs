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
using System.Threading;

namespace soft
{
    public partial class Form1 : Form
    {
        private Config c = new Config();

        private bool ruleaza = false; //se poate rula algoritmul? A fost compilat?

        private string cls;

        public Form1()
        {
            InitializeComponent();
            c.loadMainConfigs();
            c.loadCapitole(this);
            this.Text = c.main_title; //modificare titlu Main (editez din config)
            label1.Text = c.page_title; //titlul aplicatiei
            label2.Text = c.page_description; //descrierea aplicatiei
        }

        public bool repeat(string[] txt, string var, string val)
        {
            //se repeta ultimul var cu penultimul? (valoarea)
            int ok = 0; bool notOK = false;
            for (int i = txt.Length - 1; i >= 0; i--)
            {
                if (txt[i].Split(":")[0] == var)
                {
                    if (txt[i].Split(":")[1] == val) ok++;
                    else if (ok < 2) notOK = true;
                }
            }
            return notOK;
        }

        public async void rezultateTabel()
        {
            string[] txt = File.ReadAllLines("vars.txt");
            //separare variabile
            richTextBox2.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            for (int i = 0; i < txt.Length; i++)
            {
                if (txt[i].Contains("consola:")) { richTextBox2.Text += txt[i].Split(":")[1]; }
                else if (!dataGridView1.Columns.Contains(txt[i].Split(":")[0]))
                {
                    dataGridView1.Columns.Add(txt[i].Split(":")[0], txt[i].Split(":")[0]);
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[txt[i].Split(":")[0]].Value = txt[i].Split(":")[1];
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[txt[i].Split(":")[0]];
                }
                else
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[txt[i].Split(":")[0]].Value = txt[i].Split(":")[1];
                    dataGridView1.CurrentCell = dataGridView1.Rows[index].Cells[txt[i].Split(":")[0]];
                }
            }
            //File.WriteAllText("afisari.txt", "");
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                listBox2.Items.Clear();
                cls = checkedListBox1.Items[e.Index].ToString();
                if (e.Index != i) checkedListBox1.SetItemChecked(i, false);
            }
            string[] x = c.loadAlgoritmi(checkedListBox1.Items[e.Index].ToString());
            foreach (string nume in x)
            {
                listBox2.Items.Add(nume);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = listBox2.GetItemText(listBox2.SelectedItem).ToString();
            string algoritm = c.getAlgoritm(val, cls);
            Config.nume_alg = val;
            Config.cls_alg = cls;
            richTextBox1.Text = algoritm;
            Config.structuri[0] = algoritm.Split("if").Length - 1;
            Config.structuri[1] = algoritm.Split("while").Length - 1;
            Config.structuri[2] = algoritm.Split("do").Length - 1;
            Config.structuri[3] = algoritm.Split("for").Length - 1;
            Config.structuri[4] = algoritm.Split("switch").Length - 1;
            Config.structuri[1] -= Config.structuri[2]; //Pot avea 3 aparitii de WHILE, dar una din ele sa fie in DO... WHILE
            string[] txt = algoritm.Split("\n");
            string[] vars = new string[200];
            int nr_vars = 0;
            for (int i = 0; i <= 5; i++)
            {
                Config.tip_date[i] = 0;
            }
            foreach (string v in txt)
            {
                if (c.getDefVar(v) != "")
                {
                    string[] x = c.getDefVar(v).Split(",");
                    foreach (var q in x)
                    {
                        if (!Array.Exists(vars, valoare => valoare == q.Split("=")[0]))
                        {
                            vars[nr_vars] = q.Split("=")[0];
                            nr_vars++;
                        }
                    }
                    if (v.Contains("int")) Config.tip_date[0]++;
                    else if (v.Contains("float")) Config.tip_date[1]++;
                    else if (v.Contains("double")) Config.tip_date[2]++;
                    else if (v.Contains("char")) Config.tip_date[3]++;
                    else if (v.Contains("short")) Config.tip_date[4]++;
                    else if (v.Contains("bool")) Config.tip_date[5]++;
                }
            }
            Config.nr_variabile = nr_vars;
            ruleaza = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0) return;
            string txt = "#include <fstream>\nstd::ifstream fin(\"in.txt\");\nstd::ofstream fout(\"rez.txt\");\nstd::ofstream afis(\"afisari.txt\");\n" + richTextBox1.Text + "\n";
            txt = txt.Replace("cin", "fin");
            txt = txt.Replace("cout", "fout");
            //File.WriteAllText("main.cpp", txt);
            File.WriteAllText("in.txt", textBox1.Text);
            string[] test = txt.Split("\n");
            //parcurgere program si prelucrare variabile
            //            string[] vars = new string[200];
            //            int nr_vars = 0;
            for (int i = 0; i < test.Length; i++)
            {
                if (c.getDefVar(test[i]) != "") //s-a declarat o variabila
                {
                    string[] x = c.getDefVar(test[i]).Split(",");
                    foreach (string v in x) //parcurg pentru a adauga variabile noi definite
                    {
                        //                        if (Array.Exists(vars, valoare => valoare == v.Split("=")[0]))
                        //                        {
                        //                            vars[nr_vars] = v.Split("=")[0];
                        //                            nr_vars++;
                        //                        }
                        if (v.Contains("=")) test[i] += "afis<<\"" + v.Split("=")[0] + ":\"<<" + v.Split("=")[0] + "<<endl;";
                    }
                }
                else if (c.varName(test[i]) != "")//am gasit o variabila ce-si modifica valoarea
                {
                    test[i] += "afis<<\"" + c.varName(test[i]) + ":\"<<" + c.varName(test[i]) + "<<endl;";
                }
                else if (test[i].Contains("fout") && !test[i].Contains("ofstream")) //afisarea datelor la consola => voi scrie si eu in afis<<"consola:"<<...;
                {
                    string[] x = test[i].Replace(";", "").Split("<<");
                    test[i] += " afis<<\"consola:\"<<";
                    for (int j = 1; j < x.Length - 1; j++)
                        if (x[j].Contains("\"\"")) test[i] += "\" \"" + "<<";
                        else test[i] += x[j] + "<<";
                    if (x[x.Length - 1].Contains("endl") || x[x.Length - 1].Contains("\n")) test[i] += x[x.Length - 1] + ";";
                    else test[i] += x[x.Length - 1] + "<<endl;";
                }
                else if (test[i].Contains("fin") && !test[i].Contains("ifstream")) //citirea datelor => voi scrie in afis<<"var:"<<...;
                {
                    string[] x = test[i].Replace(" ", "").Replace(";", "").Split(">>");
                    for (int j = 1; j < x.Length; j++)
                    {
                        test[i] += "afis<<\"" + x[j] + ":\"<<" + x[j] + "<<endl; ";
                    }
                }
                else if(c.isStructura(test[i]) && c.expresieStructura(test[i]) != "") //determin daca expresia este adevarata sau falsa
                {
                    test[i] += "afis<<\"expresie(" + c.expresieStructura(test[i]) + "):\"<<(bool)" + c.expresieStructura(test[i]) + "<<endl;";
                }
            }

            File.WriteAllLines("main.cpp", test);

            c.compile();
            c.runApp();
            label7.Text = c.timpExecutie();
            //c.run(this);
            ruleaza = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            c.loadCapitole(this);
            c.loadAlgoritmi(cls);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                //MessageBox.Show(c.descriere(cls, listBox2.GetItemText(listBox2.SelectedItem).ToString()));
                Form4 form = new Form4();
                form.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ruleaza) { ruleaza = false; c.run(this); ruleaza = true; }
            //else MessageBox.Show("Eroare, nu poti rula, fără să execuți prima dată.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height;
            Bitmap bitmap = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            dataGridView1.Height = height;
            var folderBrowserDialog1 = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog1.ShowDialog();
            string folderName = "";
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }

            bitmap.Save(folderName + "/output.jpg");
        }
    }
}
