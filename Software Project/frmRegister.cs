using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Project
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            TxtUsername = this.txtUsername; 
            TxtPassword = this.txtPassword;
            TxtComPassword = this.txtComPassword;
            frmRegis = this;
        }
        public static frmRegister frmRegis; 
        public static TextBox TxtPassword;
        public static TextBox TxtUsername;
        public static TextBox TxtComPassword;
        Model model = new Model();

        private void button1_Click(object sender, EventArgs e)
        {
            model.Registration();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }

        public void messageCallsForUserPass(int option)
        {
            if (option == 1)
            {
                MessageBox.Show("Username and Password fields are empty", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else if(option ==2 )
            {
                MessageBox.Show("User not Unquie!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(option == 3)
            {
                MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if(option == 4)
            {
                MessageBox.Show("Passwords does not match, Please Re-enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
