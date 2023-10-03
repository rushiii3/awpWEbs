using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=master;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            Label1.Text = con.State.ToString();
        }
        catch (Exception err)
        {
            Label1.Text = err.Message;
        }
        finally
        {
            con.Close();
            Label1.Text = con.State.ToString();
        };
       
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student_master", con);
            ListBox2.Items.Clear();
            SqlDataReader reader;
            con.Open();
            Label1.Text = con.State.ToString();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListItem newItem = new ListItem();
                newItem.Text = reader["control_id"].ToString();
                newItem.Value = reader["control_id"].ToString();
                ListBox2.Items.Add(newItem);
            }
            reader.Close();
        }
        catch (Exception err)
        {
            Label1.Text = err.Message;
        }
        finally {
            con.Close();
        }
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Student_master WHERE  control_id = '" + ListBox1.SelectedItem.Value + "' ", con);
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();
            reader.Read();
            TextBox1.Text = reader["name"].ToString();
            TextBox2.Text = reader["email_id"].ToString();
            TextBox3.Text = reader["contactno"].ToString();
            TextBox9.Text = reader["address"].ToString();
            reader.Close();
        }
        catch (Exception err)
        {
            Label1.Text = err.Message;
        }
        finally
        {
            con.Close();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int added = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Student_master (control_id,name,email_id,contactno,address) VALUES ('" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "')", con);
            con.Open();
            added = cmd.ExecuteNonQuery();
            Response.Redirect("#");
            Label1.Text = added.ToString() + " no of records inserted";
        }
        catch (Exception err)
        {
            Label1.Text = err.Message;
        }
        finally {
            con.Close();
        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        {
            int added = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE Student_master SET name = '" + TextBox1.Text + "', email_id = '" + TextBox2.Text + "', contactno = '" + TextBox3.Text + "', address = '" + TextBox9.Text + "' WHERE control_id = '" + ListBox1.SelectedItem.Value + "' ", con);
                con.Open();
                added = cmd.ExecuteNonQuery();
                Response.Redirect("#");
                Label1.Text = added.ToString() + " no of records updated";
            }
            catch (Exception err)
            {
                Label1.Text = err.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        {
            int added = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Student_master WHERE control_id = '" + ListBox1.SelectedItem.Value + "' ", con);
                con.Open();
                added = cmd.ExecuteNonQuery();
                Response.Redirect("#");
                Label1.Text = added.ToString() + " no of records deleted";
                
            }
            catch (Exception err)
            {
                Label1.Text = err.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
