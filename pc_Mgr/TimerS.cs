using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle_test_v1
{
    class TimerS
    {
        public TimerS()
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
        public TimerS()
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

            
        
    }
}
