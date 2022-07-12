using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace soft
{
    class Algoritm3
    {
        public async void sumaSir0(int[] n, Form1 form)
        {
            int S = 0;
            string afisari = "S:" + S.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("S = 0");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            afisari += "x:" + n[0].ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("cin >> x");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == 0)
                {
                    form.richTextBox1.Find("while(x!=0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                    break;
                }
                else
                {
                    form.richTextBox1.Find("while(x!=0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                S += n[i];
                afisari += "S:" + S.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                form.richTextBox1.Find("S += x;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                form.richTextBox1.Find("cin>>x");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "x:" + n[i+1].ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            form.richTextBox1.Find("cout << S;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            afisari += "consola:" + S.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
        }

        public async void nrCifPareSir0(int[] n, Form1 form)
        {
            int k = 0;
            string afisari = "k:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("k = 0");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            afisari += "x:" + n[0].ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("cin >> x");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == 0)
                {
                    form.richTextBox1.Find("while(x!=0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                    break;
                }
                else
                {
                    form.richTextBox1.Find("while(x!=0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                if (n[i] % 2 == 0)
                {
                    form.richTextBox1.Find("if(x%2==0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    k++;
                    afisari += "k:" + k.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    form.richTextBox1.Find("k++;");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if(x%2==0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_structuri);
                }
                form.richTextBox1.Find("if(x%2==0)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                form.richTextBox1.Find("cin>>x");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "x:" + n[i + 1].ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            form.richTextBox1.Find("cout << k;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            afisari += "consola:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
        }
    }
}
