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
    public class DD_InforMationDAL
    {
        public DD_InforMation dD_information(string dtime)
        {
            string sql = "select * from DD_InforMation where DD_RQTime=@DD_RQTime";

            DataTable data = SqlHelper.ExecuteTable(sql, new SqlParameter("@DD_RQTime", dtime));
            DD_InforMation dD_Infor = null;
            if (data.Rows.Count > 0)
            {
                dD_Infor = RowToDDInforMation(data.Rows[0]);
            }
            return dD_Infor;
        }

        private DD_InforMation RowToDDInforMation(DataRow dr)
        {
            DD_InforMation dD_Infor = new DD_InforMation()
            {
				DD_BMNum=dr["DD_BMNum"].ToString(),
				DD_KFNume=dr["DD_KFNume"].ToString(),
				DD_RQTime=Convert.ToDateTime(dr["DD_RQTime"]),
				DD_QRTime= Convert.ToDateTime(dr["DD_QRTime"]),
				DD_SDTime= Convert.ToDateTime(dr["DD_SDTime"]),
				DD_ReseTime= Convert.ToDateTime(dr["DD_ReseTime"]),
				DD_HSTime= dr["DD_HSTime"].ToString(),
				DD_ZDTime= Convert.ToDateTime(dr["DD_BMNum"])			
            };                      
            return dD_Infor;
        }

        public List<DD_InforMation> GetAlldD_Infors()
        {
            string sql = "select * from DD_InforMation where DD_SDTime IS NOT NULL";
            DataTable dt = SqlHelper.ExecuteTable(sql);
            List<DD_InforMation> list = new List<DD_InforMation>();
            if (dt.Rows.Count>0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    DD_InforMation inforMation = RowToDDInforMationID(item);
                    list.Add(inforMation);
                }
            }
            return list;
        }

        private DD_InforMation RowToDDInforMationID(DataRow dr)
        {
            DD_InforMation dD_Infor = new DD_InforMation()
            { 
                AutoID=Convert.ToInt32(dr["AutoID"]),
                DD_BMNum=dr["DD_BMNum"].ToString(),
                DD_KFNume=dr["DD_KFNume"].ToString(),
                DD_RQTime= (DateTime?)SqlHelper.GetDBnullValue(dr["DD_RQTime"]),
                DD_QRTime= (DateTime?)SqlHelper.GetDBnullValue(dr["DD_QRTime"]),
                DD_SDTime= (DateTime?)SqlHelper.GetDBnullValue(dr["DD_SDTime"]),
                DD_ZDTime=(DateTime?)SqlHelper.GetDBnullValue(dr["DD_ZDTime"]),
                DD_HSTime=dr["DD_HSTime"].ToString(),
                DD_ReseTime= (DateTime?)SqlHelper.GetDBnullValue(dr["DD_ReseTime"])
                
            };
            return dD_Infor;
        }
    }
}

