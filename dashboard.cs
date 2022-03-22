using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Software_Project

{
    
    public partial class dashboard : Form
    {
        string selectedName = ""; //When user selects Pokemon the name is saved
        //string selectedID = ""; //When user selects Pokemon the ID is saved
        public static Label Label1;
        Model model = new Model();

        public dashboard()
        {
            InitializeComponent();
     
            Label1 = this.label1;
            

        }
        public static string selectedID = "";
        private void dashboard_Load(object sender, EventArgs e) 
        {
            
            var table = model.databasePokemon("ALL TYPES", "filter"); //Loads Pokemon Database for user
            listViewChange(table);
        }
        //-----------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            messageShow(frmLogin.name + " " + selectedID);
            model.databaseCaught();
            




        }
        public void messageShow(string message)
        {
            MessageBox.Show(message);
        }

        public void listView1_SelectedIndexChanged(object sender, EventArgs e) //Shows Selected Pokemon to User
        {
            if (listView1.SelectedItems.Count > 0)
            {
                selectedName = listView1.SelectedItems[0].SubItems[1].Text;
                selectedID = listView1.SelectedItems[0].SubItems[0].Text;
                selectedLabel.Text = selectedName;
                selectedLabelID.Text = selectedID;
            }
        }

        private void favoriteButton_Click(object sender, EventArgs e)
        {

        }

        private void typeFilterBox_SelectedIndexChanged(object sender, EventArgs e) //Filter Pokemon by Type in List
        {
            string type = typeFilterBox.Text;
            listView1.Items.Clear();
            var table = model.databasePokemon(type, "filter");
            listViewChange(table);

        }



        private void searchBox_TextChanged(object sender, EventArgs e) //Search Pokemon Name
        {
            string name = searchBox.Text;
            listView1.Items.Clear();
            var table = model.databasePokemon(name, "search");
            listViewChange(table);
        }


        public void listViewChange(DataTable table) //Used to Update List View changes for Filter
        {
            if (table != null)
            {
                try
                {
                    foreach (DataRow row in table.Rows)
                    {
                        var items = new string[]
                        {
                            row[0].ToString(),
                            row[1].ToString(),
                            row[2].ToString(),
                            row[3].ToString()
                        };
                        var value = new ListViewItem(items);
                        listView1.Items.Add(value);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) //For Testing Purposes
        {
            
            model.TestC(); // Testing
            messageShow(frmLogin.name);  //Testing
 
        }
    }
}

