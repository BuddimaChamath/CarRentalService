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
    public partial class Rent: Form
    {
        public Rent()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
        private void fillcombo()
        {
            Con.Open();
            string query = "select  RegNum from CarTb1";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
   
            CarRegCb.ValueMember = "RegNum";
            CarRegCb.DataSource = dt;
            Con.Close();
        }
        private void fillCustomer()
        {
            Con.Open();
            string query = "select  CustId from CustomerTb1";
            SqlCommand cmd = new SqlCommand(query, Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustId", typeof(int));
            dt.Load(rdr);
            CustIdCb.ValueMember = "CustId";
            CustIdCb.DataSource = dt;
            Con.Close();
        }
        private void fetchCustName()
        {
            Con.Open();
            string query = "select * from CustomerTb1 where CustId=" + CustIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();
        }
        private void populate()
        {
            Con.Open();
            string query = " select * from RentTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateonRent()
        {
            Con.Open();
            string query = "update CarTb1 set Available = 'NO' where RegNum='" + CarRegCb.SelectedValue + "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }
         private void UpdateonRentDelete()
        {
            Con.Open();
            string query = "update CarTb1 set Available = 'YES' where RegNum='" + CarRegCb.SelectedValue+ "';";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CustIdCb.Text == "" || IdTb.Text == "" || CarRegCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    


                    Con.Open();
                    string query = "insert into RentTb1(Id, CarReg, CustId, Driver, RentDate, ReturnDate, Amount) values('" + IdTb.Text + "','" + CarRegCb.SelectedValue + "','" + CustIdCb.SelectedValue + "','" + DriverCb.SelectedItem + "','" + RentDate.Value + "','" + ReturnDate.Value + "','" + AmountTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent Successfully Added");
                    Con.Close();
                    UpdateonRent();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CartypeTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Rent_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        private void CustIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            {
                SqlConnection con_1 = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
                con_1.Open();
               
                string q1 = "select * from CustomerTb1 where CustID='" + CustIdCb.SelectedValue + "'";
                SqlCommand cmd = new SqlCommand(q1, con_1);
               
                SqlDataReader rdr = cmd.ExecuteReader();

                    
                    while (rdr.Read())
                    {
                        CustNameTb.Text = rdr.GetString(1);
                    }


                con_1.Close();
            }

        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = RentDGV.CurrentRow.Cells[0].Value.ToString();
            CustIdCb.SelectedValue = RentDGV.CurrentRow.Cells[1].Value.ToString();
            CarRegCb.SelectedValue = RentDGV.CurrentRow.Cells[2].Value.ToString();
           
            RentDate.Value = DateTime.Parse(RentDGV.CurrentRow.Cells[3].Value.ToString());
            ReturnDate.Value = DateTime.Parse(RentDGV.CurrentRow.Cells[4].Value.ToString());
            DriverCb.SelectedItem = RentDGV.CurrentRow.Cells[5].Value.ToString();
            AmountTb.Text = RentDGV.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CustIdCb.Text == "" || IdTb.Text == "" || CarRegCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update RentTb1 set  CarReg='" + CarRegCb.SelectedValue + "', CustId='" + CustIdCb.SelectedValue + "', Driver='" + DriverCb.SelectedItem + "', RentDate='" + RentDate.Value + "', ReturnDate='" + ReturnDate.Value + "', Amount='" + AmountTb.Text + "' where Id='"+ IdTb.Text + "' ";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rent Successfully Updated");
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
            if (IdTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from RentTb1 where Id='" + IdTb.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Rental Deleted Successfully");
                    Con.Close();
                    //populate();
                    UpdateonRentDelete();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void DriverCb_SelectedIndexChanged(object sender, EventArgs e)
        {





        }

        private void CustNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void CarRegCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                SqlConnection con_1 = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
                con_1.Open();

                string q1 = "select * from CarTb1 where RegNum='" + CarRegCb.SelectedValue + "'";
                // string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
                SqlCommand cmd = new SqlCommand(q1, con_1);

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    CartypeTb.Text = rdr.GetString(2);
                }


                con_1.Close();
            }
            {
                SqlConnection con_1 = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
                con_1.Open();

                string q1 = "select * from CarTb1 where RegNum='" + CarRegCb.SelectedValue + "'";
                // string query = "select  RegNum from CarTb1 where Available= '" + "YES" + "'";
                SqlCommand cmd = new SqlCommand(q1, con_1);

                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    CarAmountTb.Text = rdr.GetString(5);
                }


                con_1.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ReturnDate_ValueChanged(object sender, EventArgs e)
        {

            DateTime date1 = RentDate.Value.Date;
            DateTime date2 = ReturnDate.Value.Date;
            int datiff = ((TimeSpan)(date2 - date1)).Days;

            DaysTb.Text = datiff.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AmountTb.Text = ((int.Parse(CarAmountTb.Text) + int.Parse(DriverAmountTb.Text)) * int.Parse(DaysTb.Text)).ToString();
            {


                if
                    (DriverCb.Text == "NO")

                    AmountTb.Text = ((int.Parse(CarAmountTb.Text)) * int.Parse(DaysTb.Text)).ToString();
            }
        }

        private void DaysTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
