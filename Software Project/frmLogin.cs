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
    public partial class frmLogin : Form
    {
        public static frmLogin frmLog;
        public frmLogin()
        {
            InitializeComponent();
            TxtUsername = this.txtUsername;
            TxtPassword = this.txtPassword;
            frmLog = this;
            
            
        }
        public static TextBox TxtPassword;
        public static TextBox TxtUsername;
        
        
        public static string name = "";
        Model model = new Model();

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            model.VerifyUserAndPass();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
               txtPassword.PasswordChar = '•';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new frmRegister().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void InvalidUserPassCall()
        {
            MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void CloseForm()
        {
            this.Close();
        }
    }
}
