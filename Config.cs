using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Drawing;

namespace soft
{
    class Config
    {
        public string main_title, page_title, page_description;
        public static int delay_structuri, delay_instructiuni, nr_variabile;
        private string[] text = File.ReadAllLines("config.txt");
        public static int[] tip_date = new int[6];
        public static string nume_alg, cls_alg;
        public static int[] structuri = new int[5];

        public void loadMainConfigs()
        {
            main_title = text[0].Replace("main_title=", ""); //titlul Form-ului (cel afisat in bara)
            page_title = text[1].Replace("page_title=", ""); //titlul afisat in Form (titlul principal)
            page_description = text[2].Replace("page_description=", ""); //descrierea proiectului
            delay_structuri = Int32.Parse(text[3].Replace("delay_structuri=", "")) * 1000;
            delay_instructiuni = Int32.Parse(text[4].Replace("delay_instructiuni=", "")) * 1000;
        }

        public string descriere(string cls, string nume)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=algoritmi.accdb");
            //string x;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            con.Open();
            adapter.SelectCommand = new OleDbCommand("SELECT `descriere` FROM algoritmi WHERE `capitol` = '" + cls + "' AND `nume` = '" + nume + "'", con);
            adapter.Fill(ds); //introduc in tabel toate numele de algoritmi din tabelul bazei de date
            adapter.Dispose();
            con.Close();
            return ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        public void loadCapitole(Form1 form)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=algoritmi.accdb");
            string[] x = new string[100];
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            con.Open();
            adapter.SelectCommand = new OleDbCommand("SELECT `capitol` FROM algoritmi", con);
            adapter.Fill(ds); //introduc in tabel toate numele de algoritmi din tabelul bazei de date
            adapter.Dispose();
            //x = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            int k = 0;
            for(int i = 0; i<ds.Tables[0].Rows.Count; i++)
            {
                if(!x.Contains(ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                {
                    x[k] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    k++;
                }
            }
            con.Close();
            form.checkedListBox1.Items.Clear();
            for (int i = 0; i<k; i++)
            {
                form.checkedListBox1.Items.Add(x[i]);
            }
        }

        public string[] loadAlgoritmi(string cls) //incarcare algoritmi specifici unei clase
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=algoritmi.accdb");
            int k = 0;
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                DataSet ds = new DataSet();
                con.Open();
                adapter.SelectCommand = new OleDbCommand("SELECT `nume` FROM algoritmi WHERE `capitol` = '" + cls + "'", con);
                adapter.Fill(ds); //introduc in tabel toate numele de algoritmi din tabelul bazei de date
                adapter.Dispose();
                con.Close();
                string[] x = new string[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    x[k] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    k++;
                }
                return x;
            }
            catch (Exception ex)
            {
                string[] x = { "" };
                File.WriteAllText("logs.txt", "Error:\n" + ex.ToString()); // in caz ca apar erori, vor fi afisate in logs.txt
                return x;
            }
            //return x;
        }

        public string getAlgoritm(string nume, string cls)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=algoritmi.accdb");
            //string x;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            con.Open();
            adapter.SelectCommand = new OleDbCommand("SELECT `algoritm` FROM algoritmi WHERE `capitol` = '" + cls + "' AND `nume` = '" + nume + "'", con);
            adapter.Fill(ds); //introduc in tabel toate numele de algoritmi din tabelul bazei de date
            adapter.Dispose();
            con.Close();
            return ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }

        public string getDefVar(string txt) //returneaza variabilele definite, de pilda pentru int uc, k=0, etc; se va afisa uc,k=0,etc;
        {
            string var = ""; bool ok = false;
            if (txt.Contains("int")) { ok = true; txt = txt.Split("int ")[1]; }
            else if (txt.Contains("double")) { ok = true; txt = txt.Split("double ")[1]; }
            else if (txt.Contains("float")) { ok = true; txt = txt.Split("float ")[1]; }
            else if (txt.Contains("char")) { ok = true; txt = txt.Split("char ")[1]; }
            else if (txt.Contains("short")) { ok = true; txt = txt.Split("short ")[1]; }
            else if (txt.Contains("bool")) { ok = true; txt = txt.Split("bool ")[1]; }
            if (txt.Contains("()")) ok = false; //=> e functie, nu variabila
            if(ok) var = txt.Replace(" ", "").Split(";")[0];
            return var;
        }

        public void compile()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C g++ -g -O0 main.cpp -o main.exe";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }

        public async void runApp()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C gdb -quiet --command=test.gdb main.exe > out.txt";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
        private int getFirst() //prima linie de cod - aflare
        {
            string[] txt = File.ReadAllText("out.txt").Split("\n");
            for(int i = 0; i<txt.Length; i++)
            {
                if (txt[i].Contains("	")) return i;
            }
            return -1;
        }

        public bool isStructura(string txt)
        {
            if (txt.Contains("while") || txt.Contains("if") || txt.Contains("else") || txt.Contains("switch") || txt.Contains("for") || txt.Contains("do")) return true;
            return false;
        }

        public string expresieStructura(string txt) //returneaza expresia dintr-o structura ( de pilda while(i!=0) => i!=0 )
        {
            string rezultat = "";
            txt = txt.Replace("	", "").Replace(" ", "").Split("{")[0];//elimin posibilele caractere din expresie
            if (txt.Contains("if(")) rezultat = txt.Split("if")[1]; //exista posibilitatea sa am ifstream => nu ar trebui sa dea split la acel text
            return rezultat;
        }

        public string varName(string txt)
        {
            txt.Replace(" ", "");
            string var = "";
            if(txt.Contains("	")) txt = txt.Replace("	", "");
            //if (txt.Contains(">>")) var = txt.Split(">>")[1];
            if (txt.Contains("+=")) var = txt.Split("+=")[0];
            else if (txt.Contains("*=")) var = txt.Split("*=")[0];
            else if (txt.Contains("/=")) var = txt.Split("/=")[0];
            else if (txt.Contains("-=")) var = txt.Split("-=")[0];
            else if (txt.Contains("++")) var = txt.Split("++")[0];
            else if (txt.Contains("--")) var = txt.Split("--")[0];
            //else var = txt.Split("=")[0].Split(" ")[txt.Split("=")[0].Split(" ").Length - 1];
            else if (txt.Contains("=") && !txt.Contains("==") && !txt.Contains("!=")) var = txt.Split("=")[0];
            return var.Replace(" ", "");
        }

/*        private string variabile(string[] txt, int poz)
        {
            string vars = "";
            for(int i = poz+1; !txt[i].Contains("	"); i++)
            {
                if(txt[i].Contains(varName(txt[poz]))) vars += txt[i].Replace(" = ", ":") + "\n";
            }

            return vars;
        }

        private int getNextPoz(string[] txt, int poz)
        {
            int i=0;
            for (i = poz + 1; !txt[i].Contains("	"); i++)
            {
                
            }
            return i;
        }
*/
        /*public async void run(Form1 form)
        {
            string var = "";
            string[] afis = File.ReadAllText("rez.txt").Split(" ");
            int afis_i = 0; //indice afis (pentru cout)
            string[] txt = File.ReadAllText("out.txt").Split("\n");
            int k = getFirst(); //incepe numaratoarea de la x
            if (k == -1) return;
            for(int i = k; !txt[i].Contains("_Jv_RegisterClasses"); i++)
            {
                //if (txt[i].Contains("_Jv_RegisterClasses")) break; //_Jv_RegisterClasses - break aici
                if (txt[i].Contains("	") && Regex.IsMatch(txt[i].Split("	")[0], @"^\d+$") == true)
                {
                    if (isStructura(txt[i]))
                    {
                        form.richTextBox1.Find(txt[i].Split("	")[1].Replace("  ", ""));
                        form.richTextBox1.SelectionBackColor = Color.LightBlue;
                        if(txt[i].Contains("for"))
                        {
                            var += variabile(txt, getNextPoz(txt, i));
                            File.WriteAllText("afisari.txt", var);
                            form.rezultateTabel();
                        }
                        await Task.Delay(delay_structuri);
                    }
                    else
                    {
                        if (txt[i].Contains("return")) break;
                        txt[i] = txt[i].Replace("fin", "cin").Replace("fout", "cout");
                        form.richTextBox1.Find(txt[i].Split("	")[1].Replace("  ", ""));
                        form.richTextBox1.SelectionBackColor = Color.Yellow;
                        await Task.Delay(delay_instructiuni);
                        if (txt[i].Contains("=") || txt[i].Contains("++") || txt[i].Contains("--") || txt[i].Contains("cin"))
                        {
                            var += variabile(txt, i);
                            File.WriteAllText("afisari.txt", var);
                            form.rezultateTabel();
                        }
                        else if (txt[i].Contains("cout"))
                        {
                            var += "consola:" + afis[afis_i] + " \n";
                            afis_i++;
                            File.WriteAllText("afisari.txt", var);
                            form.rezultateTabel();
                        }
                    }
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
            }
        }*/

        public static void HighlightLine(Form1 form, int index, Color color)
        {
            form.richTextBox1.SelectAll();
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            var lines = form.richTextBox1.Lines;
            if (index < 0 || index >= lines.Length) return;
            var start = form.richTextBox1.GetFirstCharIndexFromLine(index);
            var length = lines[index].Length;
            form.richTextBox1.Select(start, length);
            form.richTextBox1.SelectionBackColor = color;
        }

        public async void run(Form1 form)
        {
            string[] program = File.ReadAllText("out.txt").Split("\n");
            int k = getFirst();
            string[] variabile = File.ReadAllText("afisari.txt").Split("\n");
            int afisari = 0; //nr variabilelor intalnite in program
            string vars = ""; //lista cu variabilele pentru a fi afisate in tabel
            //programul main.cpp va avea cu 4 linii mai multe decat programul din richTextBox1
            string for_1stLine = "";
            Color culoare = Color.Yellow;
            for (int i = k; !program[i].Contains("_Jv_RegisterClasses"); i++)
            {
                int linie = Int32.Parse(program[i].Split("	")[0]) - 5;
                if(isStructura(program[i].Split("	")[program[i].Split("	").Length-1])) //linia contine o structura
                {
                    culoare = Color.LightBlue;
                    if(program[i].Contains("for")) //linia contine for => am declaratie de variabila si modificari de valoare
                    {
                        if (for_1stLine == "" || program[i + 1].Contains(for_1stLine))
                        {
                            if (for_1stLine == "") for_1stLine = program[i + 1];
                            vars += variabile[afisari] + "\n";
                            afisari++;
                            culoare = Color.LightGreen;
                        }
                        else
                        {
                            for_1stLine = "";
                            culoare = Color.Red;
                        }
                    }
                    else if(program[i].Contains("if")) //linia contine if => am expresie Adevarat sau FALS
                    {
                        if (variabile[afisari].Contains("expresie(" + expresieStructura(program[i]) + ")")) // expresia este adevarata => color = green
                        {
                            afisari++;
                            culoare = Color.LightGreen;
                        }
                        else culoare = Color.Red;
                    }
                 
                }
                else
                {
                    if (program[i].Contains("return")) break;
                    int afisari1 = program[i].Split("afis<<").Length - 1;
                    for (int ix = 0; ix < afisari1; ix++)
                    {
                        if(!variabile[afisari].Contains("expresie")) vars += variabile[afisari] + "\n";
                        afisari++;
                    }
                    culoare = Color.Yellow;
                }
                HighlightLine(form, linie, culoare);
                File.WriteAllText("vars.txt", vars);
                form.rezultateTabel();
                if(isStructura(program[i].Split("	")[program[i].Split("	").Length-1])) await Task.Delay(delay_structuri);
                else await Task.Delay(delay_instructiuni);
                HighlightLine(form, linie, form.richTextBox1.BackColor);
            }
        }

        public static void adaugaAlgoritm(string cap, string nume, string descriere, string alg)
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=algoritmi.accdb");
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO algoritmi (capitol, nume, descriere, algoritm) VALUES ('" + cap + "', '" + nume + "', '" + descriere + "', '" + alg + "')";
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static bool isValidAlgoritm(string algoritm)
        {
            File.WriteAllText("main.cpp", algoritm);
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C g++ -c main.cpp 2> error.txt";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            if (File.ReadAllText("error.txt").Length > 0) return false;
            return true;
        }

        public static string capitole()
        {
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=algoritmi.accdb");
            string[] x = new string[100];
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            con.Open();
            adapter.SelectCommand = new OleDbCommand("SELECT `capitol` FROM algoritmi", con);
            adapter.Fill(ds); //introduc in tabel toate numele de algoritmi din tabelul bazei de date
            adapter.Dispose();
            //x = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            int k = 0;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (!x.Contains(ds.Tables[0].Rows[i].ItemArray[0].ToString()))
                {
                    x[k] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    k++;
                }
            }
            con.Close();
            string txt = "";
            for(int i = 0; i<k; i++)
            {
                txt += x[i] + "\n";
            }
            return txt;
        }
        
        public string timpExecutie()
        {
            string txt = "Timp de executie: ";
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C timecmd main > t.txt";
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
            txt += File.ReadAllText("t.txt");
            return txt;
        }

    }
}