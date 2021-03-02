using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_SignUp
{
    public partial class Okno : Form
    {
        public UserContext db;
        public static List<User> Users = new List<User>();
        public Okno()
        {
            InitializeComponent();
            this.Text = "Logowanie";
            db = new UserContext();
            db.Database.EnsureCreated(); //Tworzenie pliku bazy danych
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Tutaj trzeba dać sprawdzenie logowania itp
            EmptyLogin();
            EmptyPass();
            MessageBox.Show("Zalogowano pomyślnie " + TBLogin.Text + " " + TBPassword.Text);
        }

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            //Rejestracja
            db.Add(new User { Login = TBRLogin.Text, Password = TBRPassword.Text, Birthday = DTPBirthday.Value }) ;

        }
        private void EmptyLogin()
        {
            if (TBLogin.TextLength == 0)
            {
                MessageBox.Show("Podaj login !");
            }
           // else if(TBRLogin.Text == User. )
           //  {
           //      db.
           // }
        }
        private void EmptyPass()
        {
            
            if(TBPassword.TextLength == 0)
            {
                MessageBox.Show("Podaj hasło !");
            }
            else
            {
            }
        }

       
    }
}
