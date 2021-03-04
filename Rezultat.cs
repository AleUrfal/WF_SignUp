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
            BirthdayTimer();

        }

        private void Rezultat_Load(object sender, EventArgs e)
        {
            t.Interval = 1000;
            t.Tick += new EventHandler(this.timer1_Tick);
            t.Start();
        }
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            string time = "Dzisiaj jest: ";
            string dd = DateTime.Now.DayOfWeek.ToString();
            string hh = DateTime.Now.ToString("HH:mm:ss");
            label7.Text = time + " " + dd + " "+ hh;
        }
        private void BirthdayTimer()
        {         
            int data1 = DateTime.ParseExact(user1.Birthday.ToString("MM-DD"), "MM-DD", null).DayOfYear;
            int data2 = DateTime.ParseExact(DateTime.Now.ToString("MM-DD"), "MM-DD", null).DayOfYear;
            int przestepny = DateTime.IsLeapYear(DateTime.Now.Year) == true ? 366:365;
            
            if(data1>data2)
            {
                label3.Text = "Twoje urodziny są za: " + (data1 - data2) + " dni";
            }
            else if(data1 == data2)
            {
                label3.Text = "Twoje urodziny są dziś ";
            }
            else
            {
                label3.Text = "Twoje urodziny są za: " + (data1 + przestepny - data2) + " dni";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

