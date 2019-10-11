using System;
using System.Collections.Generic;
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
            // DD_InforMation dD_InforMation = (DD_InforMation)Datagriditme.SelectedItem;
            DD_InforMationDAL dal = new DD_InforMationDAL();
            var list = dal.GetAlldD_Infors();
            DateTime dateTime = Convert.ToDateTime("16:30");
            List<DD_InforMation> inforMations = new List<DD_InforMation>();
            foreach (var item in list)
            {
                string strTime = string.Format("{0:d}", item.DD_QRTime) + " 16:30";
                DateTime time = Convert.ToDateTime(strTime);
                if (DateTime.Compare(Convert.ToDateTime(item.DD_QRTime.ToString()), time) > 0)
                {
                    DD_InforMation dD = AddListIn(item, time,1);
                    inforMations.Add(dD);
                }
                else
                {
                    DD_InforMation dD = AddListIn(item, time,0);
                    inforMations.Add(dD);
                }
            }
            Datagriditme.ItemsSource = inforMations;
        }

        private static DD_InforMation AddListIn(DD_InforMation item, DateTime time,double val)
        {
            DateTime time1 = Convert.ToDateTime(item.DD_SDTime);
            DateTime time2 = Convert.ToDateTime(time.AddDays(val));
            TimeSpan span = time1.Subtract(time2);
            return new DD_InforMation
            {
                AutoID = item.AutoID,
                DD_BMNum = item.DD_BMNum,
                DD_HSTime =  Convert.ToString(span.Days+1),
                DD_KFNume = item.DD_KFNume,
                DD_QRTime = item.DD_QRTime,
                DD_ReseTime = time.AddDays(val),
                DD_RQTime = item.DD_RQTime,
                DD_SDTime = item.DD_SDTime,
                DD_ZDTime = item.DD_ZDTime
            };
        }

    

        private void Click_ButtonLoad(object sender, RoutedEventArgs e)
        {
            DD_InforMationDAL dal = new DD_InforMationDAL();
            string selectTime = Convert.ToString(daTime.SelectedDate);
             Datagriditme.ItemsSource =dal.GetAlldD_Infors();

        }

   
    }
}
