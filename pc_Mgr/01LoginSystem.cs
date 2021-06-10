using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle_test_v1
{
    public partial class LoginSystem : Form
    {
        public LoginSystem()
        {
            InitializeComponent();
        }



        string idBox = null, pwBox = null;

        private void tb_id_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            idBox = t.Text;
        }

        private void tb_pw_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            idBox = t.Text;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {

        }
        public string user_Id()
        {
            string id = idBox;
            return id;
        }
        public string user_Pw()
        {
            string pw = pwBox;
            return pw;
        }

    }
}
