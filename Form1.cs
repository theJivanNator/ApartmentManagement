using ApartmentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmentManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = "";
            string password = "";

            username = txtUserName.Text;
            password = txtPassword.Text;

            Models.Residences_V3Context RContext = new Models.Residences_V3Context();


            if (RContext.Residents.Where(x => username.Equals(x.EmailAddress) && password.Equals(x.Password)).Any())
            {
                Resident resi = RContext.Residents.Where(x => username.Equals(x.EmailAddress) && password.Equals(x.Password)).First();
                Classes.ListWorker.Resident = resi;
                MessageBox.Show("Done!");
                Dashboard dash = new Dashboard();
                this.Hide();
                dash.ShowDialog();

            }
            else
            {
                MessageBox.Show("Cant find user or does not exist");
            }

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adminCode = Microsoft.VisualBasic.Interaction.InputBox("Enter Admin Code", "Admin", "Code");
            string password = Microsoft.VisualBasic.Interaction.InputBox("Enter Password", "Admin", "Password");

            Models.Residences_V3Context residences_V3Context = new Residences_V3Context();

            if (residences_V3Context.Admins.Where(x=> x.AdminCode.Equals(adminCode)&&x.Password.Equals(password)).Any())
            {
                AddResident addResident = new AddResident();
                addResident.Show();
            }
            else
            {
                MessageBox.Show("User dont exsist");
            }


            
        }
    }
}
