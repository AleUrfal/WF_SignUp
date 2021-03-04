using System;
using System.Windows.Forms;


namespace WF_SignUp
{
    public partial class Rezultat : Form
    {
        User user1;        
        Timer t = new Timer();
        public Rezultat(User user)
        {
            user1 = user;
            InitializeComponent();
            label2.Text = user1.Login;
            
        }

        private void Rezultat_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string time = "";
            string dd = DateTime.Now.DayOfWeek.ToString();

            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";

            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";

            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }

            label4.Text = time;
            label7.Text = dd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

