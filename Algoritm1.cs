using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Drawing;

namespace soft
{
    class Algoritm1
    {
        public async void cifreNr(int n, Form1 form)
        {
            string afisari = "n:" + n.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);

            while (n != 0)
            {
                form.richTextBox1.Find("while(n != 0)");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                int uc = n % 10;
                form.richTextBox1.Find("int uc = n % 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "uc:" + uc.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                afisari += "consola:" + uc.ToString() + " \n";
                form.richTextBox1.Find("cout << uc << \" \";");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n /= 10;
                form.richTextBox1.Find("n /= 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "n:" + n.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            //File.WriteAllText("afisari.txt", afisari);
        }

        public async void cifMax(int n, Form1 form)
        {
            int maxim = 0;
            form.richTextBox1.Find("maxim = 0");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            string afisari = "n:" + n.ToString() + "\nmaxim:" + maxim.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            while (n != 0)
            {
                form.richTextBox1.Find("while(n != 0)");
                form.richTextBox1.SelectionBackColor = Color.Green;
                await Task.Delay(Config.delay_structuri);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                int uc = n % 10;
                form.richTextBox1.Find("int uc = n % 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "uc:" + uc.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (uc > maxim)
                {
                    form.richTextBox1.Find("if (uc > maxim)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_structuri);
                    form.richTextBox1.Find("maxim = uc;");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    maxim = uc;
                    afisari += "maxim:" + maxim.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if (uc > maxim)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_structuri);
                }
                form.richTextBox1.Find("if (uc > maxim)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n /= 10;
                form.richTextBox1.Find("n /= 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "n:" + n.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            }
            afisari += "consola:" + maxim.ToString() + "\n";
            form.richTextBox1.Find("cout << maxim;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
        }

        public async void cifPare(int n, Form1 form)
        {
            int k = 0;
            string afisari = "n:" + n.ToString() + "\nk:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            do
            {
                int uc = n % 10;
                form.richTextBox1.Find("int uc = n % 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "uc:" + uc.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (uc % 2 == 0)
                {
                    form.richTextBox1.Find("if (uc%2==0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_instructiuni);
                    k++;
                    form.richTextBox1.Find("k++;");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    afisari += "k:" + k.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if (uc%2==0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_instructiuni);
                }
                form.richTextBox1.Find("if (uc%2==0)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n /= 10;
                form.richTextBox1.Find("n /= 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "n:" + n.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            } while (n != 0);
            afisari += "consola:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("cout << k;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;

        }

        public async void cifImpare(int n, Form1 form)
        {
            int k = 0;
            string afisari = "n:" + n.ToString() + "\nk:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            do
            {
                int uc = n % 10;
                form.richTextBox1.Find("int uc = n % 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "uc:" + uc.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (uc % 2 == 1)
                {
                    form.richTextBox1.Find("if (uc%2==1)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_instructiuni);
                    k++;
                    form.richTextBox1.Find("k++;");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    afisari += "k:" + k.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if (uc%2==1)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_instructiuni);
                }
                form.richTextBox1.Find("if (uc%2==1)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n /= 10;
                form.richTextBox1.Find("n /= 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "n:" + n.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            } while (n != 0);
            afisari += "consola:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("cout << k;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;

        }

        public async void cifNule(int n, Form1 form)
        {
            int k = 0;
            string afisari = "n:" + n.ToString() + "\nk:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            do
            {
                int uc = n % 10;
                form.richTextBox1.Find("int uc = n % 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "uc:" + uc.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                if (uc == 0)
                {
                    form.richTextBox1.Find("if (uc == 0)");
                    form.richTextBox1.SelectionBackColor = Color.Green;
                    await Task.Delay(Config.delay_instructiuni);
                    k++;
                    form.richTextBox1.Find("k++;");
                    form.richTextBox1.SelectionBackColor = Color.Yellow;
                    afisari += "k:" + k.ToString() + "\n";
                    File.WriteAllText("afisari.txt", afisari);
                    form.rezultateTabel();
                    await Task.Delay(Config.delay_instructiuni);
                    form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                }
                else
                {
                    form.richTextBox1.Find("if (uc == 0)");
                    form.richTextBox1.SelectionBackColor = Color.Red;
                    await Task.Delay(Config.delay_instructiuni);
                }
                form.richTextBox1.Find("if (uc == 0)");
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n /= 10;
                form.richTextBox1.Find("n /= 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "n:" + n.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            } while (n != 0);
            afisari += "consola:" + k.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("cout << k;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;

        }

        public async void oglindit(int n, Form1 form)
        {
            int n2 = 0;
            string afisari = "n:" + n.ToString() + "\nn2:" + n2.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            await Task.Delay(Config.delay_instructiuni);
            do
            {
                int uc = n % 10;
                form.richTextBox1.Find("int uc = n % 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "uc:" + uc.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n2 = n2 * 10 + uc;
                afisari += "n2:" + n2.ToString() + "\n";
                form.richTextBox1.Find("n2 = n2 * 10 + uc;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
                n /= 10;
                form.richTextBox1.Find("n /= 10;");
                form.richTextBox1.SelectionBackColor = Color.Yellow;
                afisari += "n:" + n.ToString() + "\n";
                File.WriteAllText("afisari.txt", afisari);
                form.rezultateTabel();
                await Task.Delay(Config.delay_instructiuni);
                form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
            } while (n != 0);
            afisari += "consola:" + n2.ToString() + "\n";
            File.WriteAllText("afisari.txt", afisari);
            form.rezultateTabel();
            form.richTextBox1.Find("cout << n2;");
            form.richTextBox1.SelectionBackColor = Color.Yellow;
            await Task.Delay(Config.delay_instructiuni);
            form.richTextBox1.SelectionBackColor = form.richTextBox1.BackColor;
        }

    }
}
