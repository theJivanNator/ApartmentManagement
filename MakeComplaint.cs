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
    public partial class MakeComplaint : Form
    {
        public string Unit;
        

        public MakeComplaint()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Models.Residences_V3Context residences_V3Context = new Models.Residences_V3Context();

            int numComplaints = residences_V3Context.Complaints.Count()+1;
            int unitNumComplaints= residences_V3Context.UnitComplaints.Count() + 1;


            Models.Complaint complaint = new Models.Complaint();
            Models.UnitComplaint unitComplaint = new Models.UnitComplaint();

            complaint.ComplaintDate = dateTimePicker1.Value;
            complaint.ComplaintDescription = textBox1.Text;
            complaint.ComplaintId = numComplaints.ToString();
            complaint.ComplaintTypeId = comboBox1.SelectedIndex.ToString();
            complaint.Status = "Processing";

            unitComplaint.UnitComplaintsId = unitNumComplaints.ToString();
            unitComplaint.UnitId = Unit;
            unitComplaint.ComplaintId = numComplaints.ToString();


            if (numericUpDown1.Value >0)
            {
                complaint.LinkedUnit = numericUpDown1.Value.ToString();
            }
            residences_V3Context.Add(complaint);
            residences_V3Context.SaveChanges();

            residences_V3Context.Add(unitComplaint);
            residences_V3Context.SaveChanges();

            this.Hide();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();

        }

        private void MakeComplaint_Load(object sender, EventArgs e)
        {
            Models.Residences_V3Context residences_V3Context = new Models.Residences_V3Context();

            foreach (Models.ComplaintType item in residences_V3Context.ComplaintTypes)
            {
                comboBox1.Items.Add(item.TypeDescription);
            }

            label1.Text = Classes.ListWorker.Resident.Surname+" "+ Classes.ListWorker.Resident.Name;
            label2.Text = Unit;
           numericUpDown1.Maximum = residences_V3Context.Units.Count();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
