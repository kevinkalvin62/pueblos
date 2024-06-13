using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace basesql
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public SqlConnection con = new SqlConnection("Data Source=L2A-M4; Initial Catalog=DATOS; Integrated Security=true");

        public void llenar()
        {
            string consulta = "select * from ALUMNOS";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        public void buscar(String matr)
        {
            string consulta = "select * from ALUMNOS where Matricula like '"+matr+"%'";
            SqlDataAdapter da = new SqlDataAdapter(consulta, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //SqlDataSource1.Insert();
            con.Open();
            string consulta = "insert into alumnos values('"+TextBox1.Text+"','"+ TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text +"')";
            SqlCommand com = new SqlCommand(consulta,con);
            com.ExecuteNonQuery();
            llenar();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //SqlDataSource1.Delete();
            con.Open();
            string consulta = "delete from alumnos where matricula=('"+TextBox5.Text+"')";
            SqlCommand com = new SqlCommand(consulta, con);
            com.ExecuteNonQuery();
            llenar();
            con.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //buscar
            try
            {
                buscar(TextBox6.Text);
            } catch (Exception eee) { }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            TextBox9.Text = TextBox8.Text;
            MultiView1.ActiveViewIndex = 4;

            //bucar
            //sim existe entonces
            SqlDataReader dr = null;
            SqlCommand comando = null;

            comando = new SqlCommand("select Matricula,Paterno,Materno,Nombre from Alumnos where Matricula='" + TextBox9.Text + "'", con);
            con.Open();
            try
            {
                dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    TextBox11.Text = dr["Paterno"].ToString();
                    TextBox12.Text = dr["Materno"].ToString();
                    TextBox10.Text = dr["Nombre"].ToString();
                }
                else
                {
                    TextBox9.Text = "";
                    MultiView1.ActiveViewIndex = 3;
                }
            }
            catch (Exception traca)
            {

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //actualizar si
            con.Open();
            string consulta = "delete from alumnos where matricula=('" + TextBox8.Text + "')";
            SqlCommand com = new SqlCommand(consulta, con);
            com.ExecuteNonQuery();

            string consulta2 = "insert into alumnos values('" + TextBox9.Text + "','" + TextBox11.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "')";
            SqlCommand com2 = new SqlCommand(consulta2, con);
            com2.ExecuteNonQuery();
            //SqlCommand com = new SqlCommand(consulta, con);
            //com.ExecuteNonQuery();
            llenar();
            con.Close();

        }
    }
}