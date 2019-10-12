using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.ConnTools
{
    public class IfSaturdayAndSunday
    {
        /// <summary>
        /// 根据日期返回 星期(返回结果为中文)
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>星期</returns>
        public string ConvertDateToZHWeek(DateTime date)
        {
            string week = string.Empty;
            DayOfWeek weekstr = new DateTime(date.Year, date.Month, date.Day).DayOfWeek;
            switch (weekstr.ToString())
            {
                case "Monday": week = "星期一"; break;
                case "Tuesday": week = "星期二"; break;
                case "Wednesday": week = "星期三"; break;
                case "Thursday": week = "星期四"; break;
                case "Friday": week = "星期五"; break;
                case "Saturday": week = "星期六"; break;
                case "Sunday": week = "星期天"; break;
            }
            return week;
        }
    }
}
