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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadUnits();
        }

        private void loadUnits() {


            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();


            List<Models.Unit> UnitsIDS = new List<Models.Unit>();
            UnitsIDS =Residences_V3Context.Units.Where(x => x.ResId.Equals(Classes.ListWorker.Resident.ResId)).ToList();

            foreach (Models.Unit item in UnitsIDS)
            {
                cmbUnits.Items.Add(item.UnitId);
            }

        }

        private void cmbUnits_SelectedIndexChanged(object sender, EventArgs e)
        {
            string unitID = cmbUnits.SelectedItem.ToString();
            lstComplaints.Items.Clear();

            Models.Residences_V3Context Residences_V3Context = new Models.Residences_V3Context();
            List<Models.UnitComplaint> UnitComplaint = new List<Models.UnitComplaint>();
            UnitComplaint = (Residences_V3Context.UnitComplaints.Where(x => x.UnitId.Equals(unitID)).ToList());


            Models.Complaint Complaint ;

            foreach (Models.UnitComplaint item in UnitComplaint)
            {
                Complaint = Residences_V3Context.Complaints.Where(x => x.ComplaintId.Equals(item.ComplaintId)).First();
                lstComplaints.Items.Add(Complaint.ComplaintDescription +"\n Status : "+ Complaint.Status);

            }

            List<Models.Complaint> Complaint2 = Residences_V3Context.Complaints.Where(x => x.LinkedUnit.Equals(unitID)).ToList();
            foreach (Models.Complaint item in Complaint2)
            {
                Models.UnitComplaint unit = Residences_V3Context.UnitComplaints.Where(x => x.UnitComplaintsId.Equals(item.ComplaintId)).First();

                lstComplaints.Items.Add("Unit " + unit.UnitId + " Complained : " + item.ComplaintDescription + "\n Status : " + item.Status);

            }


        }

        private void btnMakeNewComplaint_Click(object sender, EventArgs e)
        {
            if (cmbUnits.SelectedIndex != -1)
            {
                string unit = cmbUnits.SelectedItem.ToString();

                this.Hide();
                MakeComplaint makeComplaint = new MakeComplaint();
                makeComplaint.Unit = unit;
                makeComplaint.Show();

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateDetails updateDetails = new UpdateDetails();
            updateDetails.Show();
        }
    }
}
