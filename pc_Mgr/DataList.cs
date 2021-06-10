using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;


namespace Oracle_test_v1
{
    class DataList
    {
        public DataList()
        {

        }
        public DataList(string sqlLogin, string query)
        {
            OracleConnection OraConn = new OracleConnection(sqlLogin);
            OraConn.Open();
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand(query, OraConn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            OraConn.Close();
        }


        public DataList(string sqlLogin, String query, ListView list_v)
        {
            OracleConnection OraConn = new OracleConnection(sqlLogin);
            //sql에 저장된 데이터베이스 정보로 연결
            OraConn.Open();//디비 오픈
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand(query, OraConn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            OraConn.Close();

            list_v.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = dr[0].ToString();
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    lv.SubItems.Add(dr[i].ToString());
                }
                list_v.Items.Add(lv);
            }
        }
        public string DataCheak(string sqlLogin, string query)
        {
            OracleConnection OraConn = new OracleConnection(sqlLogin);
            OraConn.Open();
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand(query, OraConn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            OraConn.Close();

            string values = Convert.ToString(dt.Rows[0][0]);
            return values;
        }
    }
    
}

