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
    public partial class Rezultat : Form
    {
        User user1;
        public Rezultat(User user)
        {
            user1 = user;
            InitializeComponent();
        }


    }
}
