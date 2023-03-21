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

namespace HumanManagerSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Load();
        }


        SqlConnection con = new SqlConnection("Data Source=MINGYU\\SQLEXPRESS;Password=123456;User ID=sa;Initial Catalog=ManagerSystem");

        SqlCommand cmd;
        SqlDataReader read;

        SqlDataAdapter drr;
        string id;
        bool Model = true;
        string sql;

        public void Load() {


            try {

                sql = "select * from student";
                cmd = new SqlCommand(sql, con);
                con.Open();
                read = cmd.ExecuteReader();              
                dataGridView1.Rows.Clear();

                while (read.Read()) {

                    dataGridView1.Rows.Add(read[0], read[1], read[2], read[3]);
                }


            
            
            } catch { 


            
            } finally {


                con.Close();
            }
        
        
        }

        public void getID(string id) {

            sql = "select * from student where id='" + id + "'";

            cmd = new SqlCommand(sql,con);

            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read()) {

                txtName.Text = read[1].ToString();
                txtCourse.Text= read[2].ToString();
                txtFee.Text = read[3].ToString();


            }


            con.Close();


        
        }




        private void button1_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;

            string course = txtCourse.Text;

            string fee = txtFee.Text;


            if (Model == true)
            {

                sql = "insert into student (stname,course,fee) values(@stname,@course,@fee)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@stname", name);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@fee", fee);

                cmd.ExecuteNonQuery();

                MessageBox.Show("record add");

                txtName.Clear();

                txtCourse.Clear();

                txtFee.Clear();


                txtName.Focus();

               
            }
            else {


                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "update student set stname = @stname,course = @course,fee = @fee where id=@id";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@stname", name);
                cmd.Parameters.AddWithValue("@course", course);
                cmd.Parameters.AddWithValue("@fee", fee);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                MessageBox.Show("record Update");

                txtName.Clear();

                txtCourse.Clear();

                txtFee.Clear();


                txtName.Focus();

                button1.Text = "Save";

                Model = true;

               


            }


            con.Close();

            Load();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index && e.RowIndex >= 0) {



                Model = false;

                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                this.getID(id);

                button1.Text = "Edit";



            
            }


            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index && e.RowIndex >= 0)
            {


                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                sql = "delete from student where id= @id";
                con.Open();

                cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@id", id);


                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Deleteeee!");

                con.Close();


                Load();

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {


            txtName.Clear();

            txtCourse.Clear();

            txtFee.Clear();


            txtName.Focus();

            button1.Text = "Save";

            Model = true;  


        }
    }
}
