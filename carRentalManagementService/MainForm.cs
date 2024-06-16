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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
        private void MainForm_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTb1";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
           

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Car car = new Car();
            car.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer customer = new Customer();
            customer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rent rent = new Rent();
            rent.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Hire hire = new Hire();
            hire.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users user= new Users();
            user.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Packages packages = new Packages();
            packages.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Mycar_Click(object sender, EventArgs e)
        {

        }
    }
}
