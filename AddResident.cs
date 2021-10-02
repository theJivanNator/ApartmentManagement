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
    public partial class AddResident : Form
    {
        public AddResident()
        {
            InitializeComponent();
        }
        private List<String> complaintslst = new List<string>();

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string ResId = txtRedID.Text;
            string Name = txtName.Text;
            string Surname = txtSurname.Text;
            string EmailAddress = txtEmailAddress.Text;
            string CellNumber = txtCellnumber.Text;
            DateTime YearMovedIn = dateTimePicker1.Value;
            string Password = txtPassword.Text;


            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();

            Models.Resident resident = new Models.Resident();
            resident.ResId = ResId;
            resident.Name = Name;
            resident.Surname = Surname;
            resident.EmailAddress = EmailAddress;
            resident.CellNumber = CellNumber;
            resident.YearMovedIn = YearMovedIn;
            resident.Password = Password;
       
            
            if (!Residences_V3Context.Residents.Where(x => x.EmailAddress.Equals(resident.EmailAddress)).Any())
            {
                Residences_V3Context.Add(resident);
                Residences_V3Context.SaveChanges();
                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Already exsists");
            }

        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            string unit = numericUpDown1.Value.ToString();
            string id = txtResUnit.Text;
            string size = "24";

            Models.Unit unit1 = new Models.Unit();
            unit1.ResId = id;
            unit1.UnitId = unit;
            unit1.SquareMeters = size;

            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();

            if (Residences_V3Context.Units.Where(x=> x.UnitId.Equals(unit)).Any())
            {
                Models.Unit unit2 = Residences_V3Context.Units.Where(x => x.UnitId.Equals(unit)).First();
                Models.Resident resident = Residences_V3Context.Residents.Where(x => x.ResId.Equals(unit2.ResId)).First();
                DialogResult dialogResult = MessageBox.Show("Resident exists for unit", resident.Name +" currently lives in " + unit+" are you sure you want to update the unit", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Residences_V3Context.Update(unit1);
                    Residences_V3Context.SaveChanges();
                    MessageBox.Show("Done");
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Canceled");
                }
                
            }
            else
            {
                Residences_V3Context.Add(unit1);
                Residences_V3Context.SaveChanges();
                MessageBox.Show("Done");
            }
           
            
        }

        private void AddResident_Load(object sender, EventArgs e)
        {
            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();
            listBox1.Items.Clear();
            foreach (Models.Complaint item in Residences_V3Context.Complaints.OrderBy(x=> x.ComplaintDate).Where((x=> x.Status !=("Done"))))
            {
                listBox1.Items.Add(item.ComplaintDescription +" \nStatus : "+ item.Status);
                complaintslst.Add(item.ComplaintId);
            }

            comboBox1.Items.Add("Done");
            comboBox1.Items.Add("Working");
            comboBox1.Items.Add("Processing");


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            string status = comboBox1.SelectedItem.ToString();
            int index = 0;
            if (listBox1.SelectedIndex != -1)
            {
                index= listBox1.SelectedIndex;
            }

            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();
            Models.Complaint updateComplaint = Residences_V3Context.Complaints.Where(x=> x.ComplaintId.Equals(complaintslst.ElementAt(index))).First();

            updateComplaint.Status = status;

            Residences_V3Context.Update(updateComplaint);
            Residences_V3Context.SaveChanges();
            MessageBox.Show("Done");
           
            listBox1.Items.Clear();
            foreach (Models.Complaint item in Residences_V3Context.Complaints.OrderBy(x => x.ComplaintDate).Where((x => x.Status != ("Done"))))
            {
                listBox1.Items.Add(item.ComplaintDescription + " \n Status : " + item.Status);
                complaintslst.Add(item.ComplaintId);
            }
        }

       
    }
}
