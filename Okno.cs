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
        string dbConnect = @"Data Source=Users.db";
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
            if (TBLogin.Text.Trim().Length == 0)
            {
                MessageBox.Show("Podaj login !");
            }
            else if (TBPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("Podaj hasło !");
            }
            else
            {
                var testuser = db.Users.Where(u => u.Login.Equals(TBLogin.Text)).First();
                if(testuser.Password.Equals(TBPassword.Text))
                {
                    MessageBox.Show("Zalogowano !");
                    Rezultat rezultat = new Rezultat(testuser);
                    rezultat.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowy login lub hasło");
                }
              
            }
        }
    

        private void ButtonSignIn_Click(object sender, EventArgs e)
        {
            //Rejestracja
            if (TBRLogin.TextLength == 0)
            {
                MessageBox.Show("Podaj login");
            }
            else if (TBRPassword.TextLength == 0)
            {
                MessageBox.Show("Podaj hasło");
            }
            else if (TBRPassword.Text == TBRLogin.Text)
            {
                MessageBox.Show("Login nie może być taki sam jak hasło");
            }
            else
            {
                var testuser = db.Users.Where(u => u.Login.Equals(TBRLogin.Text)).ToList();
                if(testuser.Count == 0)
                {
                    db.Add(new User { Login = TBRLogin.Text, Password = TBRPassword.Text, Birthday = DTPBirthday.Value });
                    db.SaveChanges();
                    MessageBox.Show("Utworzono użytkownika ");
                }
                else
                {
                    MessageBox.Show("Login zajęty !");
                }
                
               
                
            }
        }
        
        
      
        

       
    }
}
