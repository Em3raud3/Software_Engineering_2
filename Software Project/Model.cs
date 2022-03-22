using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;


namespace Software_Project

{
    internal class Model
    {
        private OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        private OleDbDataAdapter dat;
        OleDbCommand cmd = new OleDbCommand();
        public static dashboard dash = new dashboard();
        public DataTable databasePokemon(string type, string control) //Filter Pokemon by Type/All Or Keyword
        {
            try
            {
                con.Open();
                if ((type == "Water" || type == "Fire" || type == "Grass") && (control == "filter")) {
                    dat = new OleDbDataAdapter("select * from Pokemon where type1='" + type + "' or type2= '" + type + "'", con);
                }
                else if((type == "ALL TYPES") && (control == "filter")){
                    dat = new OleDbDataAdapter("select * from Pokemon", con);
                }
                else
                {
                    dat = new OleDbDataAdapter("select * from Pokemon where Name like '%" + type + "%'", con);
                }
                var ds = new DataSet();
                dat.Fill(ds);
                DataTable table = ds.Tables[0];
                bool hasRows = table.Rows.GetEnumerator().MoveNext();
                if (hasRows)
                {
                    dat.Dispose();
                    con.Close();
                    return table;
                }
                return null;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }

        public void TestC() //This is a testing function
        {
            dashboard.Label1.Text = "Hello";
           
        }

        public void VerifyUserAndPass() //FrmLogin calls this method to read database for User and Pass Verification
        {
            con.Open();
            string login = "SELECT * FROM tbl_users WHERE username= '" + frmLogin.TxtUsername.Text + "' and password= '" + frmLogin.TxtPassword.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                //The Form which will appear after loggin in
                frmLogin.name = frmLogin.TxtUsername.Text;
                dash.Show();
                frmLogin.frmLog.Hide();
            }
            else //User and Pass were not correct
            {
                frmLogin.frmLog.InvalidUserPassCall();  //frmLogin method
                frmLogin.TxtUsername.Text = "";
                frmLogin.TxtPassword.Text = "";
                con.Close();
                frmLogin.TxtUsername.Focus();
            }
        }
        public void Registration()
        {
            if (frmRegister.TxtUsername.Text == "" && frmRegister.TxtPassword.Text == "" && frmRegister.TxtComPassword.Text == "") //Blank Fields
            {
                frmRegister.frmRegis.messageCallsForUserPass(1);
            }
            else if (frmRegister.TxtPassword.Text == frmRegister.TxtComPassword.Text) //Condition checks to see if user is Unqiue before creating
            {
                con.Open();
                string unqiueUserCheck = "SELECT * FROM tbl_users WHERE username= '" + frmRegister.TxtUsername.Text + "'";
                cmd = new OleDbCommand(unqiueUserCheck, con);
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read() == true)
                {
                    //User has already been created
                    frmRegister.frmRegis.messageCallsForUserPass(2);
                    frmRegister.TxtPassword.Text = "";
                    frmRegister.TxtComPassword.Text = "";
                    con.Close();
                    frmRegister.TxtPassword.Focus();
                }
                else  ///Creates User
                {
                    string register = "INSERT INTO tbl_users VALUES ('" + frmRegister.TxtUsername.Text + "','" + frmRegister.TxtPassword.Text + "')";
                    cmd = new OleDbCommand(register, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    frmRegister.TxtUsername.Text = "";
                    frmRegister.TxtPassword.Text = "";
                    frmRegister.TxtComPassword.Text = "";
                    frmRegister.frmRegis.messageCallsForUserPass(3);
                    
                }
            }
            else  //Passwords do not match
            {
                frmRegister.frmRegis.messageCallsForUserPass(4);
                frmRegister.TxtPassword.Text = "";
                frmRegister.TxtComPassword.Text = "";
                frmRegister.TxtPassword.Focus();
            }
        }
        public void databaseCaught() //In Progress
        {
            con.Open();
            string unqiueIDCheck = "SELECT * FROM User_Caught WHERE ID= '" + dashboard.selectedID + "' and username= '" + frmLogin.name + "'";
            cmd = new OleDbCommand(unqiueIDCheck, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                //Pokemon is already in user caught list
                dash.messageShow("Pokemon already in caught list");
                con.Close();
            }
           
            else  ///Places Pokemon in User Caught List
            {
                string insertPokemon = "INSERT INTO User_Caught VALUES ('" + frmLogin.name + "','" + dashboard.selectedID + "')";
                cmd = new OleDbCommand(insertPokemon, con);
                cmd.ExecuteNonQuery();
                con.Close();
                dash.messageShow("Pokemon has been added to list!");
            }




        }
    }
}
