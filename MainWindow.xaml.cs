using MyWrApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using test.ConnTools;
using test.DAL;
using test.Model;

namespace test
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_ButtonJDJS(object sender, RoutedEventArgs e)
        {
           

           Datagriditme.ItemsSource = GetNweTime();
          

        }



        #region 判断周六日时间段重置    
        /// <summary>
        /// 重新按时间节点重置确认时间
        /// </summary>
        /// <returns></returns>
        private static List<DD_InforMation> GetNweTime()
        {
            List<DD_InforMation> inforMations = new List<DD_InforMation>();
            DD_InforMationDAL dal = new DD_InforMationDAL();
            var list = dal.GetAlldD_Infors();
            foreach (var item in list)
            {
                string strTime = string.Format("{0:d}", item.DD_QRTime) + " 16:30";
                string str1 = string.Format("{0:d}", item.DD_QRTime);
                DateTime time1 = Convert.ToDateTime(str1);
                DateTime time = Convert.ToDateTime(strTime);
                if (IfSaturdayAndSunday.ConvertDateToZHWeek(time1) == "星期天")
                {
                    DD_InforMation dD = AddListIn(item, time1, 1);
                    inforMations.Add(dD);
                }
                else
                 if (IfSaturdayAndSunday.ConvertDateToZHWeek(time1) == "星期六")
                {
                    if (DateTime.Compare(Convert.ToDateTime(item.DD_QRTime.ToString()), time) > 0)
                    {
                        DD_InforMation dD = AddListIn(item, time1, 2);
                        inforMations.Add(dD);
                    }
                    else
                    {
                        DD_InforMation dD = AddListIn(item, time1, 0);
                        inforMations.Add(dD);
                    }
                }               
                else
                if (DateTime.Compare(Convert.ToDateTime(item.DD_QRTime.ToString()), time) > 0)
                {

                    DD_InforMation dD = AddListIn(item, time1, 1);
                    inforMations.Add(dD);
                }
                else
                {
                    DD_InforMation dD = AddListIn(item, time1, 0);
                    inforMations.Add(dD);
                }
            }        
            return inforMations;
        }


        private static DD_InforMation AddListIn(DD_InforMation item, DateTime time, double val)
        {
            DateTime time1 = Convert.ToDateTime(string.Format("{0:d}", item.DD_SDTime));
            DateTime time2 = Convert.ToDateTime(time.AddDays(val));
            TimeSpan span = time1.Subtract(time2);
            return new DD_InforMation
            {
                AutoID = item.AutoID,
                DD_BMNum = item.DD_BMNum,
                DD_HSTime = Convert.ToString(span.Days),
                DD_KFNume = item.DD_KFNume,
                DD_QRTime = item.DD_QRTime,
                DD_ReseTime = time.AddDays(val),
                DD_RQTime = item.DD_RQTime,
                DD_SDTime = item.DD_SDTime,
                DD_ZDTime = item.DD_ZDTime
            };
        }

        #endregion


        private void Click_ButtonLoad(object sender, RoutedEventArgs e)
        {


        }


    }
}
