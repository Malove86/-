using MyWrApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.Model;

namespace test.DAL
{
    public class JRRTableDAL
    {  

        public List<JRRTable> GetAlldD_Infors()
        {
            string sql = "select * from DD_InforMation where DD_SDTime IS NOT NULL";
            DataTable dt = SqlHelper.ExecuteTable(sql);
            List<JRRTable> list = new List<JRRTable>();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    JRRTable inforMation = RowToDDInforMationID(item);
                    list.Add(inforMation);
                }
            }
            return list;
        }

        private JRRTable RowToDDInforMationID(DataRow dr)
        {
            JRRTable dD_Infor = new JRRTable()
            { 
                AutoID=Convert.ToInt32(dr["AutoID"]),
                JRName=dr["JRName"].ToString(),              
                EndJDTime= (DateTime?)SqlHelper.GetDBnullValue(dr["EndJDTime"]),
                intSatJQTime= (DateTime?)SqlHelper.GetDBnullValue(dr["intSatJQTime"]),
                SatJHTime= (DateTime?)SqlHelper.GetDBnullValue(dr["SatJHTime"])        
            };
            return dD_Infor;
        }
    }
}

