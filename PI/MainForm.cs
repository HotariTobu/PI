using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace PI
{
    public partial class MainForm : Form
    {
        FileStream file;

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        private Task task;
        private bool running;

        private BigInteger index;
        private BigInteger limit;
        private BigInteger digit;
        private BigInteger digit2;
        private BigInteger a;
        private BigInteger b;
        private BigInteger t;
        private BigInteger p;

        private static BigInteger two = new BigInteger(2);

        public MainForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            Ticker.Enabled = true;

            index = BigInteger.Zero;
            limit = BigInteger.Zero;

            if (task != null)
            {
                task.Dispose();
            }

            task = new Task(() =>
            {
                try
                {
                    file = File.Open("PI.txt", FileMode.Create, FileAccess.Write, FileShare.Read);

                    limit = BigInteger.Parse(ExponentBox.Text);
                    digit = new BigInteger(10).Pow(two.Pow(limit + 1));
                    digit2 = digit * digit;

                    a = digit;
                    b = digit2 / (two * digit2).Sqrt();
                    t = digit / new BigInteger(4);
                    p = digit;

                    BigInteger an = BigInteger.Zero;
                    BigInteger bn = BigInteger.Zero;
                    BigInteger tn = BigInteger.Zero;
                    BigInteger pn = BigInteger.Zero;

                    string pi = string.Empty;

                    BigInteger n = BigInteger.Zero;

                    for (index = BigInteger.Zero; index < limit && running; index++)
                    {
                        an = (a + b) / two;
                        bn = (a * b).Sqrt();
                        tn = t- BigInteger.Pow(a - an, 2) * p / (digit2);
                        pn = p * two;

                        a = an;
                        b = bn;
                        t = tn;
                        p = pn;

                        pi = (BigInteger.Pow(a + b, 2) / (t * 4)).ToString();
                        n = two.Pow(index + 1);
                        if (pi.Length > 1 && n < int.MaxValue)
                        {
                            pi = pi.Substring(0, (int)n);
                        }
                        pi = pi.Insert(1, ".");
                        byte[] vs = Encoding.UTF8.GetBytes($"{pi}\n");
                        file.Write(vs, 0, vs.Length);
                        file.Flush();
                    }

                    if (running)
                    {
                        Invoke(new Action(() =>
                        {
                            StartButton.Enabled = true;
                            StopButton.Enabled = false;
                            Ticker.Enabled = false;

                            sw.Stop();
                            running = false;

                            file.Close();

                            TimeSpan ts = sw.Elapsed;
                            MessageBox.Show(this, $"計算にかかった時間は{(ts.Hours == 0 ? string.Empty : $"{ ts.Hours}時間")}{(ts.Minutes == 0 ? string.Empty : $"{ts.Minutes}分")}{(ts.Seconds == 0 ? string.Empty : $"{ts.Seconds}秒")}{ts.Milliseconds}ミリ秒です。\n最終的な円周率の近似値は{pi}です。", "計算が完了しました！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            TimeLabel.Text = "00:00:00.0000000";
                            ProgressStatusBar.Value = 0;
                        }));
                    }
                }
                catch (Exception ee)
                {
                    Invoke(new Action(()=>
                    {
                        ShowException(ee);
                    }));
                }
            });

            sw.Restart();
            running = true;
            task.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            Ticker.Enabled = false;

            sw.Stop();
            running = false;
            task.Wait();
            task.Dispose();

            file.Close();

            TimeLabel.Text = "00:00:00.0000000";
            ProgressStatusBar.Value = 0;
        }

        private static BigInteger onehundred = new BigInteger(100);

        private void Ticker_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeLabel.Text = sw.Elapsed.ToString();
                ProgressStatusBar.Value = (int)(index * onehundred / limit);
            }
            catch (Exception ee)
            {
                ShowException(ee);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ee)
            {
                ShowException(ee);
            }
            /*File.OpenRead("PI_Result.txt");
            File.OpenRead("PI_Variable.txt");*/
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (task != null)
            {
                task.Dispose();
            }

            if (file != null)
            {
                file.Close();
            }
        }

        private void ShowException(Exception e)
        {
            MessageBox.Show($"{e.Source}\n{e.Source}\n{e.StackTrace}", e.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExponentBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!"0123456789\b".Contains(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }

    static class Expand
    {
        public static BigInteger Sqrt(this BigInteger value)
        {
            BigInteger result = BigInteger.One;
            BigInteger temp = BigInteger.Zero;
            while (result != temp)
            {
                temp = result;
                result = (result + value / result) >> 1;
            }
            return result;
        }

        public static BigInteger Pow(this BigInteger value, BigInteger exponent)
        {
            BigInteger result = BigInteger.One;
            for (BigInteger i=BigInteger.Zero; i<exponent; i++)
            {
                result *= value;
            }
            return result;
        }
    }
}
