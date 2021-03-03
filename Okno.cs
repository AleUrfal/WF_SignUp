using Microsoft.Data.Sqlite;
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
            string dbConnect = @"Data Source =Users.db";
            //Tutaj trzeba dać sprawdzenie logowania itp
            if (TBLogin.TextLength == 0)
            {
                MessageBox.Show("Podaj login !");
            }
            else if (TBPassword.TextLength == 0)
            {
                MessageBox.Show("Podaj hasło !");
            }         
            else
            {
                //Połaczenie z bazą danych
                SqliteConnection sqliteCon = new SqliteConnection(dbConnect);
                try 
                {
                    sqliteCon.Open();
                    string Query = "SELECT * FROM Users WHERE Login='" + TBLogin.Text + " ' AND Password='" + TBPassword.Text + "' ";
                    SqliteCommand sqlsearch = new SqliteCommand(Query, sqliteCon);

                    sqlsearch.ExecuteNonQuery();
                    SqliteDataReader data = sqlsearch.ExecuteReader();

                    int count = 0;
                    while(data.Read())
                    {
                        count++;
                    }
                    if(count == 1)
                    {
                        MessageBox.Show("Zalogowano");
                    }
                    if (count > 1)
                    {
                        MessageBox.Show("Login nie może być taki sam jak hasło spróbuj jeszcze raz");
                    }
                    if (count < 1)
                    {
                        MessageBox.Show("Zły login lub hasło");
                    }
                }

                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                MessageBox.Show("Wykonany");
                db.Add(new User { Login = TBRLogin.Text, Password = TBRPassword.Text, Birthday = DTPBirthday.Value });
                db.SaveChanges();
            }
        }
        
        
      
        

       
    }
}
