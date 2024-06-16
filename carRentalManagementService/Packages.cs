using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace CarRental
{
    public partial class Packages : Form
    {
        public Packages()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = " select * from PackagesTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            PackagesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void fillcombo()
        {
            Con.Open();
            string query = "select  Type from CarTb1";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Type", typeof(string));
            dt.Load(rdr);

            VehicleTypeCb.ValueMember = "Type";
            VehicleTypeCb.DataSource = dt;
            Con.Close();
        }
        
        private void Packages_Load(object sender, EventArgs e)
        {
            fillcombo();
            populate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (PackageNameTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from PackagesTb1 where PackageName='" + PackageNameTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Package Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PackageNameTb.Text == "" || VehicleTypeCb.Text == "" ||  KMLimitTb.Text == "" || HoursLimitTb.Text == "" || ExtraKMTb.Text == "" || WaitingChargeTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into PackagesTb1 values('" + PackageNameTb.Text + "','" + VehicleTypeCb.Text + "','" + DailyCostTb.Text + "','" + WeeklyCostTb.Text + "','" + MonthlyCostTb.Text + "','" + KMLimitTb.Text + "','" + HoursLimitTb.Text + "','" + ExtraKMTb.Text + "','" + WaitingChargeTb.Text + "','" + DriverOvernightTb.Text + "','" + AmountTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Package Successfully Added");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
        private void PackagesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PackageNameTb.Text = PackagesDGV.CurrentRow.Cells[0].Value.ToString();
            VehicleTypeCb.Text = PackagesDGV.CurrentRow.Cells[1].Value.ToString();
            DailyCostTb.Text = PackagesDGV.CurrentRow.Cells[2].Value.ToString();
            WeeklyCostTb.Text = PackagesDGV.CurrentRow.Cells[3].Value.ToString();
            MonthlyCostTb.Text = PackagesDGV.CurrentRow.Cells[4].Value.ToString();
            KMLimitTb.Text = PackagesDGV.CurrentRow.Cells[5].Value.ToString();
            HoursLimitTb.Text = PackagesDGV.CurrentRow.Cells[6].Value.ToString();
            ExtraKMTb.Text = PackagesDGV.CurrentRow.Cells[7].Value.ToString();
            WaitingChargeTb.Text = PackagesDGV.CurrentRow.Cells[8].Value.ToString();
            DriverOvernightTb.Text = PackagesDGV.CurrentRow.Cells[9].Value.ToString();
            AmountTb.Text = PackagesDGV.CurrentRow.Cells[10].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (PackageNameTb.Text == "" || VehicleTypeCb.Text == "" || KMLimitTb.Text == "" || HoursLimitTb.Text == "" || ExtraKMTb.Text == "" || WaitingChargeTb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update PackagesTb1 set PackageName=('" + PackageNameTb.Text + "',VehicleType='" + VehicleTypeCb.SelectedItem.ToString() + "', DailyCost = '" + DailyCostTb.Text + "' ,WeeklyCost='" + WeeklyCostTb.Text + "' ,MonthlyCost= '" + MonthlyCostTb.Text + "' ,KMLimit='" + KMLimitTb.Text + "' ,HoursLimit='" + HoursLimitTb.Text + "' ,ExtraKM='" + ExtraKMTb.Text + "' ,WaitingCharge='" + WaitingChargeTb.Text + "' , DriverOvernight= '" + DriverOvernightTb.Text+ "', Amount = '" + AmountTb.Text+ "' where PackageName=" + PackageNameTb.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Successfully Updated");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CartypeTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

