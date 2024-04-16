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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double val1,val2;
        char sign='C';
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            val1 = double.Parse(textBox1.Text);
            sign = 'x';
            textBox1.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text+"1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "0";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            val1 = double.Parse(textBox1.Text);
            sign = '/';
            textBox1.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            val1 = double.Parse(textBox1.Text);
            sign = '-';
            textBox1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double result;
            if (sign == 'C'){
                return;
            }
            else{
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True");
                con.Open();
                val2 = double.Parse(textBox1.Text);
                if (sign == '+')
                {
                    result = val1 + val2;
                    textBox1.Text = result.ToString();
                    sign = 'C';
                    string val1str, val2str, resultstr;
                    val1str= val1.ToString();
                    val2str= val2.ToString();
                    resultstr = result.ToString();
                    SqlCommand cm;
                    string query="Insert into Addition_table (num1,num2,result) values ("+ val1str + ","+val2str+","+resultstr+")";
                    cm=new SqlCommand(query,con);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    val1 = result;
                }
                else if (sign == '-')
                {
                    result = val1 - val2;
                    textBox1.Text = result.ToString();
                    sign = 'C';
                    string val1str, val2str, resultstr;
                    val1str = val1.ToString();
                    val2str = val2.ToString();
                    resultstr = result.ToString();
                    SqlCommand cm;
                    string query = "Insert into Subtraction_table (num1,num2,result) values (" + val1str + "," + val2str + "," + resultstr + ")";
                    cm = new SqlCommand(query, con);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    val1 = result;
                }
                else if (sign == 'x')
                {
                    result = val1 * val2;
                    textBox1.Text = result.ToString();
                    sign = 'C';
                    string val1str, val2str, resultstr;
                    val1str = val1.ToString();
                    val2str = val2.ToString();
                    resultstr = result.ToString();
                    SqlCommand cm;
                    string query = "Insert into Multiplication_table (num1,num2,result) values (" + val1str + "," + val2str + "," + resultstr + ")";
                    cm = new SqlCommand(query, con);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    val1 = result;
                }
                else if (sign == '/')
                {
                    result = val1 / val2;
                    textBox1.Text = result.ToString();
                    sign = 'C';
                    string val1str, val2str, resultstr;
                    val1str = val1.ToString();
                    val2str = val2.ToString();
                    resultstr = result.ToString();
                    SqlCommand cm;
                    string query = "Insert into Division_table (num1,num2,result) values (" + val1str + "," + val2str + "," + resultstr + ")";
                    cm = new SqlCommand(query, con);
                    cm.ExecuteNonQuery();
                    cm.Dispose();
                    val1 = result;
                }
                con.Close();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            sign = 'C';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            double val= double.Parse(textBox1.Text);
            double sqrt= Math.Sqrt(val);
            textBox1.Text = sqrt.ToString();
            string resultstr=sqrt.ToString();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True");
            con.Open();
            string valstr=val.ToString();
            SqlCommand cm;
            string query = "Insert into Square_Root_table (num,result) values (" + valstr + "," + resultstr + ")";
            cm = new SqlCommand(query, con);
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            string valstr = textBox1.Text;
            double val = double.Parse(textBox1.Text);
            double result=val*val;
            textBox1.Text = result.ToString();
            string resultstr = result.ToString();
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True");
            con.Open();
            SqlCommand cm;
            string query = "Insert into Square_table (num,result) values (" + valstr + "," + resultstr + ")";
            cm = new SqlCommand(query, con);
            cm.ExecuteNonQuery();
            cm.Dispose();
            con.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Addition_table";
            SqlCommand cmd=new SqlCommand(query, con);
            var reader=cmd.ExecuteReader();
            DataTable table= new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
            

        }

        private void button20_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Subtraction_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView2.DataSource = table;
            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Multiplication_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView3.DataSource = table;
            con.Close();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Division_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView4.DataSource = table;
            con.Close();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Square_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView5.DataSource = table;
            con.Close();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "SELECT * FROM Square_Root_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView6.DataSource = table;
            con.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Addition_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Subtraction_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView2.DataSource = table;
            con.Close();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Multiplication_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView3.DataSource = table;
            con.Close();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Division_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView4.DataSource = table;
            con.Close();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Square_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView5.DataSource = table;
            con.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-S7GIJR6\\SQLEXPRESS;Initial Catalog=CalculatorDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "DELETE FROM Square_Root_table";
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView6.DataSource = table;
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            val1 =double.Parse(textBox1.Text);
            sign = '+';
            textBox1.Text = "";
        }
    }
}
