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

    
        public void Update(DD_InforMation inforMation)
        {
            string sql = @" UPDATE DD_InforMation  SET  
                                DD_BMNum =  @DD_BMNum
                              , DD_KFNume = @DD_KFNume
                              , DD_RQTime = @DD_RQTime
                              , DD_QRTime = @DD_QRTime
                              , DD_ZDTime = @DD_ZDTime
                              , DD_SDTime = @DD_SDTime
                              , DD_HSTime = @DD_HSTime
                              , DD_ReseTime = @DD_ReseTime 
                                Where AutoID=@AutoID";
            SqlHelper.ExecuteNonQuery(sql, 
                new SqlParameter("@DD_BMNum", inforMation.DD_BMNum),
                new SqlParameter("@DD_KFNume", inforMation.DD_KFNume),
                new SqlParameter("@DD_RQTime", inforMation.DD_RQTime),
                new SqlParameter("@DD_QRTime", inforMation.DD_QRTime),
                new SqlParameter("@DD_ZDTime", SqlHelper.ToDBnullValue(inforMation.DD_ZDTime)),
                new SqlParameter("@DD_SDTime", inforMation.DD_SDTime),
                new SqlParameter("@DD_HSTime", inforMation.DD_HSTime),
                new SqlParameter("@DD_ReseTime", inforMation.DD_ReseTime),
                new SqlParameter("@AutoID", inforMation.AutoID)                                                          
                                    );

        }

    }
}

