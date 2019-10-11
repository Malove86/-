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
   public class CustomerDAL
    {
        //根据订单日期获取每月送货确认定单数
        // GetByDDRQ、Update、DeleteById、GetAll、GetPagedData(分页) Insert(插入新数据)

        public DD_Customer GetByDDRQ(DateTime dateTime)
        {
            DataTable data = SqlHelper.ExecuteDataTable("select * from DD_Customer where DD_RQTime=@dateTime",
                new SqlParameter("@dateTime",dateTime));
            if (data.Rows.Count<=0)
            {
                return null;
            }
            else if (data.Rows.Count>1)
            {
                throw new Exception("严重错误，查出多条记录！");
            }
            else
            {
                DataRow dataRow = data.Rows[0];
                DD_Customer dD_Customer = new DD_Customer()
                {

                    DD_CZTime = (DateTime?)SqlHelper.FromDbValue(dataRow["DD_CZTime"]),
                    DD_HS = (string)dataRow["DD_HS"],
                    DD_QRTime = (DateTime?)SqlHelper.FromDbValue(dataRow["DD_QRTime"]),
                    DD_RQTime = (DateTime?)SqlHelper.FromDbValue(dataRow["DD_RQTime"]),
                    DD_SDTime = (DateTime?)SqlHelper.FromDbValue(dataRow["DD_SDTime"]),
                    DD_ZDTime = (DateTime?)SqlHelper.FromDbValue(dataRow["DD_ZDTime"]),
                    XS_BMNum = (string)dataRow["XS_BMNum"],
                    XS_KHNum = (string)dataRow["XS_KHNum"]                     
                };
                return dD_Customer;

            }
        }

        public void DeleteById(int id)
        {
            SqlHelper.ExecuteNonQuery("delete from DD_Customer where AutoId=@id",
                new SqlParameter("@id",id));
        }




    }
}
