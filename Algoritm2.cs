using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace soft
{
    class Algoritm2
    {
        public async void divizorii(int n, Form1 form)
        {
            string afisari = "n:" + n.ToString() + "\n";
            for (int d = 1; d <= n; d++)
            {
                form.richTextBox1.Find("for(int d =1 ; d <= n ; d ++ )");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (n % d == 0)
                {
                    form.richTextBox1.Find("if(n % d == 0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    afisari += "d:" + d.ToString() + " convine\n";
                    afisari += "consola:" + d.ToString() + " \n";
                    form.richTextBox1.Find("cout << d << \" \";");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if(n % d == 0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    afisari += "d:" + d.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_structuri);
                }
                form.richTextBox1.Find("if(n % d == 0)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                await Task.Delay(Config.delay_structuri);
            }
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
        }


        public async void cmmdc(int n, int m, Form1 form)
        {
            string afisari = "n:" + n.ToString() + "\nm:" + m.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            while (n != m)
            {
                form.richTextBox1.Find("while(n != m)");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (n > m)
                {
                    form.richTextBox1.Find("if(n > m)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    n -= m;
                    afisari += "n:" + n.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    form.richTextBox1.Find("n -= m");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("else");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    m -= n;
                    afisari += "m:" + m.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    form.richTextBox1.Find("m -= n");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                form.richTextBox1.Find("if(n > m)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                form.richTextBox1.Find("else");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                await Task.Delay(Config.delay_structuri);
            }
            afisari += "consola:" + n.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.richTextBox1.Find("cout << n;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_structuri);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            form.rezultateTabel();
        }

        public async void nrprim(int n, Form1 form)
        {
            string afisari = "n:" + n.ToString() + "\n";
            bool prim = true;
            afisari += "prim:" + prim.ToString() + "\n";
            form.richTextBox1.Find("bool prim = true;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            if (n < 2)
            {
                form.richTextBox1.Find("if(n < 2)");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                prim = false;
                form.richTextBox1.Find("prim = false;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            else
            {
                form.richTextBox1.Find("if(n < 2)");
                form.richTextBox1.SelectionBackColor = Color.Red;
                await Task.Delay(Config.delay_structuri);
            }
            form.richTextBox1.Find("if(n < 2)");
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            afisari += "prim:" + prim.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            for (int d = 2; d < n && prim; d++)
            {
                form.richTextBox1.Find("for(int d=2 ; d < n && prim ; d++)");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (n % d == 0)
                {
                    form.richTextBox1.Find("if(n % d == 0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    prim = false;
                    form.richTextBox1.Find("prim=false;");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    
                    afisari += "d:" + d.ToString() + " DIVIZOR\n";
                    afisari += "prim:" + prim.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if(n % d == 0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    afisari += "d:" + d.ToString() + "\n";
                    afisari += "prim:" + prim.ToString() + " \n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_structuri);
                }
                form.richTextBox1.Find("if(n % d == 0)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            if (prim)
            {
                form.richTextBox1.Find("if(prim)");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                afisari += "consola:" + n.ToString() + " este prim.\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                form.richTextBox1.Find("cout << n << \" este prim\";");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            else
            {
                form.richTextBox1.Find("if(prim)");
                form.richTextBox1.SelectionBackColor = Color.Red;
                form.richTextBox1.Find("else");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                afisari += "consola:" + n.ToString() + " nu este prim.\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                form.richTextBox1.Find("cout << n << \" nu este prim\";");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            form.richTextBox1.Find("if(prim)");
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            form.richTextBox1.Find("else");
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
        }
    }
}
