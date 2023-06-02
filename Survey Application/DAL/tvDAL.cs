using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using Survey_Application.BLL;
using System.Windows.Forms;

namespace Survey_Application.DAL
{
    class tvDAL
    {
        static string myconnstrng = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Survey.accdb";
        public bool Insert(tvBLL tv)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(myconnstrng);

            try
            {

                OleDbCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "INSERT INTO watch_tv (watch_tv_rate) VALUES ('" + tv.rate + "')";
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Summited");
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
    }
}
