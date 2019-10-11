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

        }

        private void Click_ButtonLoad(object sender, RoutedEventArgs e)
        {
            DD_InforMationDAL dal = new DD_InforMationDAL();
            string selectTime = Convert.ToString(daTime.SelectedDate);
             Datagriditme.ItemsSource =dal.GetAlldD_Infors();

        }
    }
}
