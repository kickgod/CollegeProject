using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FamilyConsole.UserDefine
{
    public partial class DateTimeControl : UserControl
    {
        public DateTimeControl()
        {
            InitializeComponent();
        }
        private void DateTimeControl_Load(object sender, EventArgs e)
        {
            for (int i = 100; i <= DateTime.Now.Year; i++)
            {
                cbxYear.Items.Add(i);
            }
            cbxYear.Text = DateTime.Now.Year.ToString();
            cbxMonth.SelectedIndex = 0;
            cbxDay.Items.Clear();
            for (int i = 1; i <= 31; i++)
            {
                cbxDay.Items.Add(i);
            }
            cbxDay.SelectedIndex = 0;
        }
        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMonth.Text != "" && cbxYear.Text != "" & cbxDay.Text != "")
            {
                int jDay = getMaxDay(Convert.ToInt32(cbxYear.Text), Convert.ToInt32(cbxMonth.Text));
                cbxDay.Items.Clear();
                for (int i = 1; i <= jDay; i++)
                {
                    cbxDay.Items.Add(i);
                }
                cbxDay.Text = Convert.ToString(getMaxDay(Convert.ToInt32(cbxYear.Text), Convert.ToInt32(cbxMonth.Text)));
            }    
        }
        private int getMaxDay(int year,int month){
            bool isLeapYear=false;
	
            if((year%4==0 && year%100!=0) | year%400==0){
                isLeapYear = true;
            }
	
            if(isLeapYear){
                int[] Month=new int[13]{0,31,29,31,30,31,30,31,31,30,31,30,31};
                return Month[month];
            }else{
                int[] Month = new int[13]{0,31,29,31,30,31,30,31,31,30,31,30,31};
                return Month[month];
            }
	
        }
        new public string Text
        {
            get { return Convert.ToDateTime(cbxYear.Text + "/" + cbxMonth.Text + "/" + cbxDay.Text).ToString(); }
            set
            {
                DateTime dt =new DateTime();
                dt = Convert.ToDateTime(value);
                this.cbxYear.Text = dt.Year.ToString();
                this.cbxMonth.SelectedIndex = cbxMonth.Items.IndexOf(dt.Month.ToString());
            }
        }
        public bool IsNull()
        {
            if (this.cbxYear.Text == "")
            {
                return true;
            }
            return false;
        }

        private void cbxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMonth.Text != "" && cbxYear.Text != "" & cbxDay.Text != "")
            {
                int jDay = getMaxDay(Convert.ToInt32(cbxYear.Text), Convert.ToInt32(cbxMonth.Text));
                cbxDay.Items.Clear();
                for (int i = 1; i <= jDay; i++)
                {
                    cbxDay.Items.Add(i);
                }
                cbxDay.Text = Convert.ToString(getMaxDay(Convert.ToInt32(cbxYear.Text), Convert.ToInt32(cbxMonth.Text)));              
            }            
        }
    }
}
