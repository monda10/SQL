using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Windows.Forms;

namespace Oracle_test_v1
{
    class ListRefresh : Form
    {
        public ListRefresh(DataTable dt)
        {
            ListViewItem lv = new ListViewItem();
            foreach (DataRow dr in dt.Rows)
            {
                lv.Text = dr[0].ToString();

                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    lv.SubItems.Add(dr[i].ToString());
                }
            }
        }
    }
}
