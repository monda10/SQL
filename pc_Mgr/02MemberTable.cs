using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace Oracle_test_v1
{
    public partial class MemberTable : Form
    {
        public MemberTable()
        {
            InitializeComponent();
            //회원 테이블
            List_Usertbl.View = View.Details;
            List_Usertbl.Columns.Add("No", 0, HorizontalAlignment.Center);
            List_Usertbl.Columns.Add("회원 ID", 100, HorizontalAlignment.Center);
            List_Usertbl.Columns.Add("이름", 80, HorizontalAlignment.Center);
            List_Usertbl.Columns.Add("연락처", 100, HorizontalAlignment.Center);
            List_Usertbl.Columns.Add("회원등급", 70, HorizontalAlignment.Center);
            List_Usertbl.Columns.Add("이용 시간", 100, HorizontalAlignment.Center);
            List_Usertbl.Columns.Add("가입 일자", 150, HorizontalAlignment.Center);
            List_Usertbl.EndUpdate();
           
            //유료게임 테이블
            List_Gametbl.View = View.Details;
            List_Gametbl.Columns.Add("No", 0, HorizontalAlignment.Center);
            List_Gametbl.Columns.Add("게임명", 150, HorizontalAlignment.Center);
            List_Gametbl.Columns.Add("판매액", 80, HorizontalAlignment.Center);
            List_Gametbl.Columns.Add("재고 시간", 80, HorizontalAlignment.Center);
            List_Gametbl.Columns.Add("마진(시간)", 80, HorizontalAlignment.Center);
            List_Gametbl.EndUpdate();

            //상품재고 테이블
            List_Prodtbl.View = View.Details;
            List_Prodtbl.Columns.Add("No", 0, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("상품명", 120, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("원가", 80, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("판매가", 80, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("입고 수량", 70, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("재고 수량", 70, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("입고 일자", 150, HorizontalAlignment.Center);
            List_Prodtbl.Columns.Add("유효 기한", 100, HorizontalAlignment.Center);
            List_Prodtbl.EndUpdate();


            //결산 테이블
            List_Sales.View = View.Details;
            List_Sales.Columns.Add("상품판매 매출", 90, HorizontalAlignment.Left);
            List_Sales.Columns.Add("좌석판매 매출", 90, HorizontalAlignment.Left);
            List_Sales.Columns.Add("유료판매 매출", 90, HorizontalAlignment.Left);
            List_Sales.EndUpdate();
            List_Expense.View = View.Details;
            List_Expense.Columns.Add("상품구매 지출", 90, HorizontalAlignment.Left);
            List_Expense.Columns.Add("기타 지출", 90, HorizontalAlignment.Left);
            List_Expense.EndUpdate();
            List_Profit.View = View.Details;
            List_Profit.Columns.Add("현재 순수익", 91, HorizontalAlignment.Left);
            List_Profit.EndUpdate();

            //로그 확인
            List_Log.View = View.Details;
            List_Log.Columns.Add("좌석 번호", 80, HorizontalAlignment.Center);
            List_Log.Columns.Add("회원 ID", 100, HorizontalAlignment.Center);
            List_Log.Columns.Add("기본금", 80, HorizontalAlignment.Center);
            List_Log.Columns.Add("추가금", 80, HorizontalAlignment.Center);
            List_Log.Columns.Add("시작 시간", 150, HorizontalAlignment.Center);
            List_Log.Columns.Add("종료 시간", 150, HorizontalAlignment.Center);
            List_Log.EndUpdate();

        }


        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        // sql 접속 정보 Data Source=xxx.xxx.xxx.xxx:port/SID(ex:orcl);User ID=아이디;Password=비밀번호
        string sqlLogin = "Data Source=192.168.0.23:1521/xe;User ID=pcmgr_S;Password=1234";

        // 총 쿼리 변수 
        string s_query1, s_query2;
        string i_query1;
        string d_query1;
        string u_query1;
        string sales_query1, sales_query2, sales_query3;
        // 좌석 테이블 변수 
        string memberIdBox = null, base_price = null;
        int paid_price = 0, seatNum = 0;
        // 회원 테이블 변수 
        string idBox = null, nameBox = null, vipBox = null, telBox = null, timeBox = null;
        // 상품 테이블 변수 
        string prod_nameBox = null, prod_costpriceBox = null, prod_priceBox = null, prod_amount = null,
            prod_ReceivingBox = null, prod_count = null;
        // 타이머 변수 
        int CountH = 0;
        int CountM = 0;
        int CountS = 0;
        int CountMS = 0;
        bool Toggle = false;
        // 게임 테이블 변수 
        string game_NameBox = null, game_PaymentBox = null, game_PriceBox = null,
          game_RefillTimeBox = null, game_ProfitBox;

        // -------------------------------------------------------------------------
        // --------------------------- 회원 테이블 -----------------------------------
        // -------------------------------------------------------------------------
        private void Btn_Mem_List_Click(object sender, EventArgs e)
        {
            s_query1 = "select * from membertbl order by seq_num";
            ListView list_v = List_Usertbl;
            new DataList(sqlLogin, s_query1, list_v);
        }

        private void Tb_Id_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            idBox = t.Text;
        }
        private void Tb_Name_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            nameBox = t.Text;
        }
        private void MemberS_Main_CheckedChanged(object sender, EventArgs e)
        {
            vipBox = "정회원";
        }
        private void MemberS_Sub_CheckedChanged(object sender, EventArgs e)
        {
            vipBox = "비회원";
        }

        private void Tb_Tel_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            telBox = t.Text;
        }
        private void Tb_Tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
               (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void Tb_mem_time_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            timeBox = t.Text;
        }

        // insert
        private void Btn_Mem_Add_Click(object sender, EventArgs e)
        {
            if (idBox == null || nameBox == null || vipBox == null || telBox == null )
            {
                MessageBox.Show("회원 정보 입력을 먼저 완료 해주세요."); 
                return;
            }
            i_query1 = $"insert into membertbl values(NO_SEQ_MEM.NEXTVAL,'{idBox}', '{nameBox}','{telBox}', '{vipBox}','{timeBox}',sysdate)";
            s_query1 = "select * from membertbl order by seq_num";
            ListView list_v = List_Usertbl;
            new DataList(sqlLogin, i_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);

            MessageBox.Show("신규 회원이 추가 등록 되었습니다.");
            Mem_textNull(); // 클릭시 텍스트박스 초기화
        }
   

        string nameselect = null;
        private void List_Usertbl_MouseClick(object sender, MouseEventArgs e)
        {
            nameselect = List_Usertbl.FocusedItem.Text;
            Mem_infoSet();
        }

 

        // delete
        private void Btn_Mem_Delete_Click(object sender, EventArgs e)
        {
            if (nameselect == null)
            {
                MessageBox.Show("삭제할 대상이 선택되지 않았습니다.");
                return;
            }

            d_query1 = $"delete from membertbl where seq_num = '{nameselect}'";
            s_query1 = "select * from membertbl order by seq_num";
            ListView list_v = List_Usertbl;
            new DataList(sqlLogin, d_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);
         
            MessageBox.Show("선택한 회원이 삭제 되었습니다.");
            Mem_textNull();
        }

        // 업데이트
        private void Btn_Mem_Update_Click(object sender, EventArgs e)
        {
            if (idBox == null || nameBox == null || vipBox == null || telBox == null )
            {
                MessageBox.Show("필수 정보가 입력이 안되었습니다."); 
                return;
            }

            u_query1 = $"update membertbl set user_id = '{idBox}', user_name = '{nameBox}', user_vip = '{vipBox}' , user_tel = '{telBox}' where seq_num = '{nameselect}'";
            s_query1 = "select * from membertbl order by seq_num";
            ListView list_v = List_Usertbl;
            new DataList(sqlLogin, u_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);

            MessageBox.Show("선택한 회원정보가 수정 되었습니다.");
            Mem_textNull();
        }

 

        //string nametime = null;
        //private void TEST_BTN2_Click(object sender, EventArgs e)
        //{
        //    u_query = $"update membertbl set times = '{timeBox}' where user_id = '{nametime}'";
        //    ListView list_v = List_Usertbl;
        //    new DataList(sqlLogin, u_query, list_v);
        //    new DataList(sqlLogin, s_query, list_v);
        //}



        // -------------------------------------------------------------------------
        // --------------------------- 상품 재고 테이블 ------------------------------
        // -------------------------------------------------------------------------


        private void Btn_Prod_List_Click(object sender, EventArgs e)
        {
            s_query1 = "select * from producttbl order by seq_num";
            ListView list_v = List_Prodtbl;
            new DataList(sqlLogin, s_query1, list_v);
        }

        
        private void Tb_Prod_Name_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            prod_nameBox = t.Text;
        }

        private void Tb_Prod_CostPrice_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            prod_costpriceBox = t.Text;
        }

        private void Tb_Prod_Price_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            prod_priceBox = t.Text;
        }

        private void Tb_Prod_Amount_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            prod_amount = t.Text;
            prod_count = t.Text;
        }

        private void Prod_ExpirationDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = Prod_ExpirationDate.Value;
            prod_ReceivingBox = dt.ToString("yyyy-MM-dd");
        }

        

        private void Tb_Prod_Receiving_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            prod_ReceivingBox = t.Text;
        }

        private void Btn_Prod_Add_Click(object sender, EventArgs e)
        {
            if (prod_nameBox == null || prod_costpriceBox == null || prod_priceBox == null || prod_ReceivingBox == null)
            {
                MessageBox.Show("정보 입력을 먼저 완료 해주세요.");
                return;
            }

            i_query1 = $"insert into producttbl values(NO_SEQ_PROD.NEXTVAL,'{prod_nameBox}','{prod_costpriceBox}','{prod_priceBox}','{prod_count}','{prod_amount}',sysdate,'{prod_ReceivingBox}')";
            s_query1 = "select * from producttbl order by seq_num";

            ListView list_v1 = List_Prodtbl;

            new DataList(sqlLogin, i_query1, list_v1);
            new DataList(sqlLogin, s_query1, list_v1);

            MessageBox.Show("상품이 추가 등록 되었습니다.");
            ListSalesRef();
            Prod_textNull(); // 클릭시 텍스트박스 초기화

        }

        private void List_Prodtbl_MouseClick(object sender, MouseEventArgs e)
        {
            nameselect = List_Prodtbl.FocusedItem.Text;
            Prod_infoSet();
        }
 
        private void Btn_Prod_Delete_Click(object sender, EventArgs e)
        {
            if (nameselect == null)
            {
                MessageBox.Show("삭제할 대상이 선택되지 않았습니다.");
                return;
            }
            d_query1 = $"delete from producttbl where seq_num = '{nameselect}'";
            s_query1 = "select * from producttbl order by seq_num";

            ListView list_v = List_Prodtbl;
            new DataList(sqlLogin, d_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);

            MessageBox.Show("선택한 회원이 삭제 되었습니다.");
            ListSalesRef();
            Prod_textNull();
        }
    


        private void Btn_Prod_Update_Click(object sender, EventArgs e)
        {
            if (prod_nameBox == null || prod_costpriceBox == null || prod_priceBox == null || prod_amount == null || prod_ReceivingBox == null)
            {
                MessageBox.Show("필수 정보가 입력이 안되었습니다."); 
                return;
            }
            u_query1 = $"update producttbl set product_name = '{prod_nameBox}', cost_price = '{prod_costpriceBox}'" +
                $" , price = '{prod_priceBox}' where seq_num = '{nameselect}'";
            s_query1 = "select * from producttbl order by seq_num";
            
            ListView list_v = List_Prodtbl;
           
            new DataList(sqlLogin, u_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);

            MessageBox.Show("선택한 회원정보가 수정 되었습니다.");
            ListSalesRef();
            Mem_textNull();
        }

        // -------------------------------------------------------------------------
        // --------------------------- 좌석 테이블 ------------------------------
        // -------------------------------------------------------------------------

 
        private void Tb_SeatBasePrice_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            base_price = t.Text;
        }


        private void Tb_SeatBasePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Btn_SeatBasePrice_Click(object sender, EventArgs e)
        {
            if (base_price == null)
            {
                MessageBox.Show("금액 정보가 입력이 되지 않았습니다.");
                return;
            }
            u_query1 = $"update statement set price = '{base_price}' where prod_name = '기본료'";      
            new DataList(sqlLogin, u_query1);
            MessageBox.Show("기본료가 설정 되었습니다.");
        }

        private void Com01_Id_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            memberIdBox = t.Text;
        }

        private void Btn_Seat_No01SE_Click(object sender, EventArgs e)
        {
            if (Gb_SeatCom01.BackColor == Color.Transparent)
            {
                if (MessageBox.Show("입력한 ID 로 시작하시겠습니까?", "Login", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    s_query1 = $"select user_id from membertbl where user_id in ('{memberIdBox}')";
                    s_query2 = $"select price from statement where prod_name in ('기본료')";
                    string id = Id_Check(s_query1);
                    DataList dl = new DataList();
                    base_price = dl.DataCheak(sqlLogin, s_query2);
                    
                    seatNum = 1;
                    if (memberIdBox != id)
                    {
                        MessageBox.Show("입력한 id는 등록된 회원이 아닙니다.\n회원 정보를 다시 입력하세요.");
                        return;
                    }
                    i_query1 = $"insert into seattbl values({seatNum},'{memberIdBox}',{base_price}," +
                        $"{paid_price},systimestamp,null)";

                    new DataList(sqlLogin, i_query1);

                    MessageBox.Show("접속 완료. 사용을 시작합니다.");

                    Label_SeatNo01_ID.Text = "회원 ID :  " + memberIdBox;
                    Label_SeatNo01_Time.Text = "접속 시간 :  " + DateTime.Now.ToString("HH:mm:ss");
                    Gb_SeatCom01.BackColor = Color.SpringGreen;
                    Btn_Seat_No01SE.Text = "종료";
                    Label_SeatNo01_PriceU.Text = base_price+" 원";
                    TimerStart(Timer_Seat01_1, Timer_Seat01_2);
                    Seat_textNull();
                }
                else
                {
                    MessageBox.Show("접속이 취소 되었습니다.");
                    return;
                }
            }
            else if (Gb_SeatCom01.BackColor == Color.SpringGreen)
            {
                if (MessageBox.Show("입력한 ID 로 시작하시겠습니까?", "Login", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    MessageBox.Show("접속 종료. 사용을 마칩니다.");
                    MessageBox.Show("좌석을 청소해주세요.!!");
                    Label_SeatNo01_ID.Text = "회원 ID :  ";
                    Label_SeatNo01_Time.Text = "접속 시간 :  ";
                    Gb_SeatCom01.BackColor = Color.Crimson;
                    Btn_Seat_No01SE.Text = "청소중";
                    TimerReset(Timer_Seat01_1, Timer_Seat01_2);
                }
                else
                {
                    MessageBox.Show("종료가 취소 되었습니다.");
                    return;
                }
            }           
            else
            {
                MessageBox.Show("좌석이 청소 되지 않았습니다.");
                return;
            }
           
        }

        private void Btn_Seat_No01Clr_Click(object sender, EventArgs e)
        {
            Gb_SeatCom01.BackColor = Color.Transparent;
            MessageBox.Show("청소 완료. 다시 이용이 가능합니다.");
            Label_SeatNo01_PriceU.Text = "0 원";
        }

        private void TimerStart(Timer timer1, Timer timer2)
        {
            if (Toggle == false)
            {
                timer1.Start();
                timer2.Start();
                Toggle = true;
            }
            else
            {
                timer1.Stop();
                timer2.Stop();
                Toggle = false;
            }
        }
        private void TimerReset(Timer timer1, Timer timer2)
        {
            timer1.Stop();
            timer2.Stop();
            Toggle = false;
            CountH = 0;
            CountM = 0;
            CountS = 0;
            CountMS = 0;
            Label_SeatNo01_TimeH.Text = CountH.ToString();
            Label_SeatNo01_TimeM.Text = CountM.ToString();
            Label_SeatNo01_TimeS.Text = CountS.ToString();
        }

        private void Timer_Seat01_1_Tick(object sender, EventArgs e)
        {
            ++CountMS;
            if (CountMS == 1)
            {
                CountMS = 0;
                ++CountS;
                if (CountS == 60)
                {
                    CountS = 0;
                    ++CountM;
                    if ( CountM == 60)
                    {
                        CountM = 0;
                        ++CountH;
                    }
                }
            }
        }

        private void Timer_Seat01_2_Tick(object sender, EventArgs e)
        {
            Label_SeatNo01_TimeH.Text = CountH.ToString();
            Label_SeatNo01_TimeM.Text = CountM.ToString();
            Label_SeatNo01_TimeS.Text = CountS.ToString();
        }

        private void Timer_Price(Label seatNo)
        {
            base_price = Label_SeatNo01_TimeH.Text;
            seatNo.Text += base_price;
            Toggle = true;
        }

        private string Id_Check (string s_query)
        {
            OracleConnection OraConn = new OracleConnection(sqlLogin);
            OraConn.Open();
            OracleDataAdapter oda = new OracleDataAdapter();
            oda.SelectCommand = new OracleCommand(s_query, OraConn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            OraConn.Close();

            string id = null;
            for (int row = 0; row < dt.Rows.Count; row++)
            {
                if (DBNull.Value.Equals(dt.Rows[row]["user_id"]))
                {
                    id = "null";
                }
                else
                {
                    id = Convert.ToString(dt.Rows[0][0]);
                }
            }
            return id;
        }

 

        // -------------------------------------------------------------------------
        // --------------------------- 유료 게임 테이블 ------------------------------
        // -------------------------------------------------------------------------


        private void Btn_Game_List_Click(object sender, EventArgs e)
        {
            s_query1 = "select * from gametbl order by seq_num";
            ListView list_v = List_Gametbl;
            new DataList(sqlLogin, s_query1, list_v);
        }

      

        private void Tb_Game_Name_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            game_NameBox = t.Text;
        }

        private void Tb_Game_Payment_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            game_PaymentBox = t.Text;
        }

        private void Tb_Game_Payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

      
        private void Tb_Game_Profit_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            game_ProfitBox = t.Text;
        }

 

        private void Tb_Game_Profit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void Tb_Game_Refill_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            game_RefillTimeBox = t.Text;
        }


        private void Tb_Game_RefillTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       

        private void Btn_Game_Add_Click(object sender, EventArgs e)
        {
            if (game_NameBox == null || game_ProfitBox == null || game_PaymentBox == null || game_RefillTimeBox == null)
            {
                MessageBox.Show("정보 입력을 먼저 완료 해주세요.");
                return;
            }
            int cp = Convert.ToInt32(game_PaymentBox);
            int time = Convert.ToInt32(game_RefillTimeBox);
            int pm = Convert.ToInt32(game_ProfitBox);
            int result = (cp / time) + pm;
            game_PriceBox = result.ToString();
            
            i_query1 = $"insert into gametbl values(NO_SEQ_GAME.NEXTVAL,'{game_NameBox}','{game_PriceBox}'," +
                $"'{game_RefillTimeBox}','{game_ProfitBox}','{game_PaymentBox}')";
            s_query1 = "select * from gametbl order by seq_num";
            
            ListView list_v = List_Gametbl;
            
            new DataList(sqlLogin, i_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);
            

            MessageBox.Show("상품이 추가 등록 되었습니다.");
            Prod_textNull(); // 클릭시 텍스트박스 초기화
        }

       

        private void List_Gametbl_MouseClick(object sender, MouseEventArgs e)
        {
            nameselect = List_Gametbl.FocusedItem.Text;
            Game_infoSet();
        }


        private void Btn_Game_Delete_Click(object sender, EventArgs e)
        {
            if (nameselect == null)
            {
                MessageBox.Show("삭제할 대상이 선택되지 않았습니다.");
                return;
            }

            d_query1 = $"delete from gametbl where seq_num = '{nameselect}'";
            s_query1 = "select * from gametbl order by seq_num";
            ListView list_v = List_Gametbl;
            new DataList(sqlLogin, d_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);

            MessageBox.Show("선택한 회원이 삭제 되었습니다.");
            Game_textNull();
        }

        private void Btn_Game_Update_Click(object sender, EventArgs e)
        {
            if (game_NameBox == null || game_ProfitBox == null || game_RefillTimeBox == null || game_PaymentBox == null)
            {
                MessageBox.Show("필수 정보가 입력이 안되었습니다.");
                return;
            }

            int cp = Convert.ToInt32(game_PaymentBox);
            int time = Convert.ToInt32(game_RefillTimeBox);
            int pm = Convert.ToInt32(game_ProfitBox);
            int result = (cp / time) + pm;
            game_PriceBox = result.ToString();

            u_query1 = $"update gametbl set game_name = '{game_NameBox}', price = '{game_PriceBox}',profit = '{game_ProfitBox}'" +
                $" , times = '{game_RefillTimeBox}', payment = '{game_PaymentBox}' where seq_num = '{nameselect}'";
            s_query1 = "select * from gametbl order by seq_num";

            ListView list_v = List_Gametbl;
            new DataList(sqlLogin, u_query1, list_v);
            new DataList(sqlLogin, s_query1, list_v);

            MessageBox.Show("선택한 회원정보가 수정 되었습니다.");
            Game_textNull();
        }

        // -------------------------------------------------------------------------
        // --------------------------- 매출 정보 테이블 ------------------------------
        // -------------------------------------------------------------------------


        private void Btn_TestRe_Click(object sender, EventArgs e)
        {
            ListSalesRef();
        }

        private void Btn_SalesSearch_Click(object sender, EventArgs e)
        {
            s_query1 = "select * from seattbl order by Startdate";
            ListView list_v = List_Log;
            new DataList(sqlLogin, s_query1, list_v);
        }




        //========================================
        // 회원 테이블 메소드 ====================
        //========================================


        // 리스트뷰 클릭시 클릭한 정보 자동 셋팅
        private void Mem_infoSet()
        {
            Tb_Mem_ID.Text = List_Usertbl.SelectedItems[0].SubItems[1].Text;
            Tb_Mem_Name.Text = List_Usertbl.SelectedItems[0].SubItems[2].Text;
            Tb_Mem_Tel.Text = List_Usertbl.SelectedItems[0].SubItems[3].Text;
            string memvip = List_Usertbl.SelectedItems[0].SubItems[4].Text;
            
            if (memvip == "정회원")
            {
                Rd_MemberS_Main.Checked = true;
                Rd_MemberS_Sub.Checked = false;
            }
            else if (memvip == "비회원")
            {
                Rd_MemberS_Main.Checked = false;
                Rd_MemberS_Sub.Checked = true;
            }
        }
        // DB 정보 변경 이후 입력 정보 초기화

        private void Mem_textNull()
        {
            Tb_Mem_ID.Text = string.Empty; ;
            Tb_Mem_Name.Text = string.Empty; ;
            Tb_Mem_Tel.Text = string.Empty; ;
        }


        //========================================
        // 상품 테이블 메소드 ====================
        //========================================

        // 리스트뷰 클릭시 클릭한 정보 자동 셋팅
        private void Prod_infoSet()
        {
            Tb_Prod_Name.Text = List_Prodtbl.SelectedItems[0].SubItems[1].Text;
            Tb_Prod_CostPrice.Text = List_Prodtbl.SelectedItems[0].SubItems[2].Text;
            Tb_Prod_Price.Text = List_Prodtbl.SelectedItems[0].SubItems[3].Text;
            Tb_Prod_Amount.Text = List_Prodtbl.SelectedItems[0].SubItems[4].Text;

            
            string expiration = List_Prodtbl.SelectedItems[0].SubItems[6].Text;
            this.Prod_ExpirationDate.CustomFormat = "yyyy-MM-dd";
            this.Prod_ExpirationDate.Value = DateTime.ParseExact(expiration, "yyyy-MM-dd", null);
        }
        // DB 정보 변경 이후 입력 정보 초기화

        private void Prod_textNull()
        {
            Tb_Prod_Name.Text = string.Empty; 
            Tb_Prod_CostPrice.Text = string.Empty; 
            Tb_Prod_Price.Text = string.Empty; 
            Tb_Prod_Amount.Text = string.Empty; 
            Tb_Prod_Price.Text = string.Empty; 
        }


        //========================================
        // 게임 테이블 메소드 ====================
        //========================================

        // 리스트뷰 클릭시 클릭한 정보 자동 셋팅
        private void Game_infoSet()
        {
            Tb_Game_Name.Text = List_Gametbl.SelectedItems[0].SubItems[1].Text;
            Tb_Game_game_Payment.Text = List_Gametbl.SelectedItems[0].SubItems[5].Text;
            Tb_Game_RefillTime.Text = List_Gametbl.SelectedItems[0].SubItems[3].Text;
            Tb_Game_Profit.Text = List_Gametbl.SelectedItems[0].SubItems[4].Text;
        }
        // DB 정보 변경 이후 입력 정보 초기화
        //string game_NameBox = null, game_CostPriceBox = null,
        //game_PriceBox = null, game_RefillTimeBox = null, game_PaymentBox;
        private void Game_textNull()
        {
            Tb_Game_Name.Text = string.Empty;
            Tb_Game_game_Payment.Text = string.Empty;
            Tb_Game_RefillTime.Text = string.Empty;
            Tb_Game_Profit.Text = string.Empty;
        }



        //========================================
        // 좌석 테이블 메소드 ====================
        //========================================

        // 리스트뷰 클릭시 클릭한 정보 자동 셋팅
     
        // DB 정보 변경 이후 입력 정보 초기화

        private void Seat_textNull()
        {
            Com01_Id.Text = string.Empty;
            memberIdBox = null;
        }


        //========================================
        // 공통 메소드 ============================
        //========================================

        private void ListSalesRef()
        {
            sales_query1 = "select sum(p.price*p.amount), sum(s.base_price+s.paid_price),sum(g.price*g.times) " +
                "from producttbl p,seattbl s,gametbl g";
            sales_query2 = "select sum(p.cost_price*p.amount), sum(s.base_price+s.paid_price+g.payment) " +
                "from producttbl p,seattbl s, gametbl g";
            sales_query3 = "select sum(p.price*p.amount)+sum(s.base_price+s.paid_price)" +
                "+sum(g.price*g.times)-sum(p.cost_price*p.amount)" +
                "-sum(g.payment) from producttbl p,seattbl s,gametbl g";
            ListView list_v1 = List_Sales;
            ListView list_v2 = List_Expense;
            ListView list_v3 = List_Profit;
            new DataList(sqlLogin, sales_query1, list_v1);
            new DataList(sqlLogin, sales_query2, list_v2);
            new DataList(sqlLogin, sales_query3, list_v3);
        }


        // -------------------------------------------------------------------------
        // --------------------------- 미사용 창고 ------------------------------
        // -------------------------------------------------------------------------
        private void btn_Mem_Select_Click(object sender, EventArgs e)
        {

        }
        private void Btn_Testbutton_Click(object sender, EventArgs e)
        {
            s_query1 = "select sum(cost_price*amount), sum(times*500) from producttbl,membertbl";
            ListView list_v = List_Sales;
            new DataList(sqlLogin, s_query1, list_v);
        }
    }
}

