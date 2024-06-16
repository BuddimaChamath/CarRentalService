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
    public partial class Hire : Form
    {
        public Hire()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
        private void fillcombo()
        {
            Con.Open();
            string query = "select  CustId from CustomerTb1";
            //string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(string));
            dt.Load(rdr);

            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            Con.Close();
        }
        private void fillcombo1()
        {
            Con.Open();
            string query = "select  RegNum from CarTb1";
            //string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);

            VehicleIdCb.ValueMember = "RegNum";
            VehicleIdCb.DataSource = dt;
            Con.Close();
        }
        private void fillcombo2()
        {
            Con.Open();
            string query = "select PackageName from PackagesTb1";
            //string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PackageName", typeof(string));
            dt.Load(rdr);

            PackageCb.ValueMember = "PackageName";
            PackageCb.DataSource = dt;
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = " select * from HireTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            HireDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Hire_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillcombo1();
            fillcombo2();
            populate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (HireIdTb.Text == "" || CustIdCb.Text == "" || VehicleIdCb.Text == "" || TourTypeCb.Text == "" || PackageCb.Text == "" || StartKmTb.Text == "" || EndKmTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into HireTb1 values(" + HireIdTb.Text + ",'" + CustIdCb.SelectedValue + "','" + VehicleIdCb.SelectedValue + "','"+TourTypeCb.SelectedItem + "','" + PackageCb.SelectedValue + "','" + StartTimeDtp.Value + "','" + EndTimeDtp.Value + "','" + StartKmTb.Text + "','" + EndKmTb.Text + "','" + HireChargeTb.Text + "','" + WaitingChargeTb.Text + "','" + ExtraKmChargeTb.Text + "','" + TotalAmountTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hire Successfully Added");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void HireDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HireIdTb.Text = HireDGV.CurrentRow.Cells[0].Value.ToString();
            CustIdCb.Text = HireDGV.CurrentRow.Cells[1].Value.ToString();
            VehicleIdCb.Text = HireDGV.CurrentRow.Cells[2].Value.ToString();
            TourTypeCb.Text = HireDGV.CurrentRow.Cells[3].Value.ToString();
            PackageCb.Text = HireDGV.CurrentRow.Cells[4].Value.ToString();
            StartTimeDtp.Text = HireDGV.CurrentRow.Cells[5].Value.ToString();
            EndTimeDtp.Text = HireDGV.CurrentRow.Cells[6].Value.ToString();
            StartKmTb.Text = HireDGV.CurrentRow.Cells[7].Value.ToString();
            EndKmTb.Text = HireDGV.CurrentRow.Cells[8].Value.ToString();
            HireChargeTb.Text = HireDGV.CurrentRow.Cells[9].Value.ToString();
            WaitingChargeTb.Text = HireDGV.CurrentRow.Cells[10].Value.ToString();
            ExtraKmChargeTb.Text = HireDGV.CurrentRow.Cells[11].Value.ToString();
            TotalAmountTb.Text = HireDGV.CurrentRow.Cells[12].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
              if (HireIdTb.Text == "" || CustIdCb.Text == "" || VehicleIdCb.Text == "" || TourTypeCb.Text == "" || PackageCb.Text == "" || StartKmTb.Text == "" || EndKmTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update HireTb1 set HireId" + HireIdTb.Text + ",'" + CustIdCb.SelectedValue + "','" + VehicleIdCb.SelectedValue + "','" + TourTypeCb.SelectedItem + "','" + PackageCb.SelectedValue + "','" + StartTimeDtp.Value + "','" + EndTimeDtp.Value + "','" + StartKmTb.Text + "','" + EndKmTb.Text + "','" + HireChargeTb.Text + "','" + WaitingChargeTb.Text + "','" + ExtraKmChargeTb.Text + "','" + TotalAmountTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hire Successfully Updated");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (HireIdTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from HireTb1 where HireId='" + HireIdTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Hire Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CustIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection con_1 = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
                con_1.Open();

                string q1 = "select * from CustomerTb1 where CustID='" + CustIdCb.SelectedValue + "'";
                // string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
                SqlCommand cmd = new SqlCommand(q1, con_1);

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    CustNameTb.Text = rdr.GetString(1);
                }


                con_1.Close();
            }
        }

        private void VehicleIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection con_1 = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
                con_1.Open();

                string q1 = "select * from CarTb1 where RegNum='" + VehicleIdCb.SelectedValue + "'";
                // string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
                SqlCommand cmd = new SqlCommand(q1, con_1);

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    VehicleTypeTb.Text = rdr.GetString(2);
                }


                con_1.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TotalAmountTb.Text = ((int.Parse(HireChargeTb.Text) + int.Parse(WaitingChargeTb.Text) + int.Parse(ExtraKmChargeTb.Text)) * int.Parse(DaysTb.Text)).ToString();
            {

            }
        }

        private void EndTimeDtp_ValueChanged(object sender, EventArgs e)
        {

            DateTime date1 = StartTimeDtp.Value.Date;
            DateTime date2 = EndTimeDtp.Value.Date;
            int datiff = ((TimeSpan)(date2 - date1)).Days;

            DaysTb.Text = datiff.ToString();
        }
    }
}
