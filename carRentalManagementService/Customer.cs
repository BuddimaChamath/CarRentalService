﻿using System;
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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=BCSCOMPUTER\SQLEXPRESS;Initial Catalog=D:\USERS\MYPC\DOCUMENTS\CARRENTALDB.MDF;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = " select * from CustomerTb1";
            SqlDataAdapter da = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text =="")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into CustomerTb1 values(" + IdTb.Text + ",'" + NameTb.Text + "','" + AddressTb.Text + "','"+PhoneTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Added");
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
                    string query = "delete from CustomerTb1 where CustId='" + IdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Deleted Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }

        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdTb.Text = CustomerDGV.CurrentRow.Cells[0].Value.ToString();
            NameTb.Text = CustomerDGV.CurrentRow.Cells[1].Value.ToString();
            AddressTb.Text = CustomerDGV.CurrentRow.Cells[2].Value.ToString();
            PhoneTb.Text = CustomerDGV.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || AddressTb.Text == "" || PhoneTb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update CustomerTb1 set CustName='" + NameTb.Text + "',CustAdd='" + AddressTb.Text + "', Phone = '" +PhoneTb.Text + "' where CustId =" + IdTb.Text + ";";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Successfully Updated");
                    Con.Close();
                    populate();

                }
                catch (Exception Myex)
                {
                    MessageBox.Show(Myex.Message);
                }
            }
        }
    }
    }
