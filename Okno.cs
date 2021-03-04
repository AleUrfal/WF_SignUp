using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WF_SignUp
{
    public partial class Okno : Form
    {
        int a = 1;
        public UserContext db;
        public static List<User> Users = new List<User>();  
        public Okno()
        {
            InitializeComponent();         
            this.Text = "Logowanie";
            db = new UserContext();
            db.Database.EnsureCreated(); //Tworzenie pliku bazy danych
            TBPassword.UseSystemPasswordChar = true;
            TBRPassword.UseSystemPasswordChar = true;
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
            else if (a == 1)
            {
                MessageBox.Show("Zarejestruj użytkownika !");
            }
            else
            {
                var testuser = db.Users.Where(u => u.Login.Equals(TBLogin.Text)).First();
                if(testuser.Password.Equals(Hashfield(TBPassword.Text.Trim())))
                {
                    MessageBox.Show("Zalogowano !");
                    Rezultat rezultat = new Rezultat(testuser);
                    rezultat.ShowDialog();
                    TBLogin.Text = "";
                    TBPassword.Text = "";
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
                    db.Add(new User { Login = TBRLogin.Text, Password = Hashfield(TBRPassword.Text.Trim()), Birthday = DTPBirthday.Value });
                    db.SaveChanges();
                    MessageBox.Show("Utworzono użytkownika ");
                    TBRLogin.Text = "";
                    TBRPassword.Text = "";
                    a = 0;
                }
                else
                {
                    MessageBox.Show("Login zajęty !");
                }
               
            }        

        }
        private static string Hashfield(string stringToHash)
        {
            using (var hash = SHA256.Create())
            {
                return string.Join("", hash
                  .ComputeHash(Encoding.UTF8.GetBytes(stringToHash))
                  .Select(item => item.ToString("x2")));
            }
        }

        private void Button_Pass_Click(object sender, EventArgs e)
        {
            if (TBRPassword.UseSystemPasswordChar == false)
            {
                TBRPassword.UseSystemPasswordChar = true;
                Button_Pass.Text = "Odkryj";
            }
            else
            {
                TBRPassword.UseSystemPasswordChar = false;
                Button_Pass.Text = "Zakryj";
            }
        }

        private void Button_Password_Click(object sender, EventArgs e)
        {
            if (TBPassword.UseSystemPasswordChar == false)
            { 
                TBPassword.UseSystemPasswordChar = true;
                Button_Password.Text = "Odkryj";
            }
            else 
            {
                TBPassword.UseSystemPasswordChar = false;
                Button_Password.Text = "Zakryj";
            }
        }
    }
}
