using Movie_ticket_system.Controller;
using Movie_ticket_system.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movie_ticket_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        Moviecontroller u = new Moviecontroller();
        private void Form1_Load(object sender, EventArgs e)
        {
            dt = da.Movietailsall(u);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = da.Movietailsall(u);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                u.Name = textBox1.Text;
                u.Seat = "5";
                u.status = "Active";

                u.Time = textBox3.Text;
                u.Catagory = comboBox1.Text;
                u.Biyer = "None";
                u.Price = textBox5.Text;


                int i = da.Addmovie(u);
                if (i > 0)
                {
                    MessageBox.Show("Succesfully Added");
                    dt = da.Movietailsall(u);
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Selec a Movie First");
            }
            else
            {


                u.Name = textBox1.Text;

                u.Seat = "5";
                u.Time = textBox3.Text;
                u.Catagory = comboBox1.Text;
                u.Biyer = textBox2.Text;
                u.Price = textBox5.Text;


                u.sl = label4.Text;


                int w = da.movieupdate(u);
                if (w > 0)
                {
                    MessageBox.Show("updated");
                    dt = da.Movietailsall(u);
                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label4.Text == "--") { MessageBox.Show("select a movie"); }
            else
            {
                u.sl = label4.Text;
                int i = da.Delete(u);
                if (i > 0)
                {
                    MessageBox.Show("Deleted");

                    dt = da.Movietailsall(u);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || comboBox1.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please Select a Movie");
            }
            else
            {
                if (textBox4.Text == "0") { MessageBox.Show("Not Enough Seat"); }
                else
                {
                    u.Name = textBox1.Text;


                    u.Time = textBox3.Text;
                    u.Catagory = comboBox1.Text;
                    u.status = textBox2.Text;
                    u.Biyer = textBox2.Text;
                    u.Price = textBox5.Text;
                    u.Seat = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(1)).ToString();


                    int i = da.Sell(u);
                    if (i > 0)
                    {
                        MessageBox.Show("Succesfully Added");
                        int w = da.movieupdate(u);
                        dt = da.Movietailsall(u);
                        dataGridView1.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
        }
    }
}