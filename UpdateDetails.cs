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
    public partial class UpdateDetails : Form
    {
        public UpdateDetails()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string EmailAddress = txtEmailAddress.Text;
            string CellNumber = txtCellnumber.Text;
           
            string Password = txtPassword.Text;


            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();

            Models.Resident resident = new Models.Resident();
            resident.ResId = Classes.ListWorker.Resident.ResId;
            resident.Name = Name;
            resident.Surname = Surname;
            resident.EmailAddress = EmailAddress;
            resident.CellNumber = CellNumber;
            resident.YearMovedIn = Classes.ListWorker.Resident.YearMovedIn;
            resident.Password = Password;

            if (resident.EmailAddress.Equals(Classes.ListWorker.Resident.EmailAddress))
            {
                Residences_V3Context.Update(resident);
                Residences_V3Context.SaveChanges();
                MessageBox.Show("Done");
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
            else
            {
                if (!Residences_V3Context.Residents.Where(x => x.EmailAddress.Equals(resident.EmailAddress)).Any())
                {
                    Residences_V3Context.Update(resident);
                    Residences_V3Context.SaveChanges();
                    MessageBox.Show("Done");
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Already exsists");
                }
            }
           
        }
    }
}
