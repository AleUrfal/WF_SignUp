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
            var data1 = user1.Birthday;
            var data2 = DateTime.Now;

            var data3 = DateTime.ParseExact(data1.Year.ToString("YYYY"), "YYYY",null);
            var s1 = data1 - data3; 
            var data4 = DateTime.ParseExact(data2.Year.ToString("YYYY"), "YYYY", null);
            var s2 = data2 - data4;

            if(s1>s2)
            {
                label3.Text = "Twoje urodziny są za: " + Convert.ToInt32((s1 - s2).TotalDays).ToString() + " dni";
            }
            else if(s1 == s2)
            {
                label3.Text = "Twoje urodziny są dziś ";
            }
            else
            {
                bool przestepny = DateTime.IsLeapYear(data2.Year);
                int dni = przestepny == true ? 366 : 365;
                label3.Text = "Twoje urodziny są za: " + Convert.ToInt32((s1 - s2).TotalDays + dni).ToString() + " dni";
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

