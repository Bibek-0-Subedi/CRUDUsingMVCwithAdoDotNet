using CRUDUsingMVCwithAdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDUsingMVCwithAdoDotNet.Repository
{
    public class AddressRepository
    {
        private SqlConnection con;

        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }

        //Geting all states
        public List<StateModel> GetAllStates()
        {
            connection();
            List<StateModel> stateList = new List<StateModel>();

            SqlCommand com = new SqlCommand("GetStates", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);//RESEARCH IT
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                stateList.Add(
                    new StateModel
                    {
                        StateId = Convert.ToInt32(dr["StateId"]),
                        StateName = Convert.ToString(dr["StateName"]),
                        StateNameLocal = Convert.ToString(dr["StateNameLocal"]),
                    });
            }
            return stateList;

        }

        //Get all districts
        public List<DistrictModel> GetAllDistricts()
        {
            connection();
            List<DistrictModel> districtList = new List<DistrictModel>();

            SqlCommand com = new SqlCommand("GetDistricts", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                districtList.Add(
                    new DistrictModel
                    {
                        DistrictId = Convert.ToInt32(dr["DistrictId"]),
                        StateId = Convert.ToInt32(dr["StateId"]),
                        DistrictName = Convert.ToString(dr["DistrictName"]),
                        DistrictNameLocal = Convert.ToString(dr["DistrictNameLocal"])
                    });
            }
            return districtList;
        }

        //Get All LocalUnits
        public List<LocalUnitModel> GetAllLocalUnitModels()
        {
            connection();
            List<LocalUnitModel> localUnitList = new List<LocalUnitModel>();

            SqlCommand com = new SqlCommand("GetLocalUnits", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach(DataRow dr in dt.Rows)
            {
                localUnitList.Add(
                    new LocalUnitModel
                    {
                        LocalUnitId = Convert.ToInt32(dr["LocalUnitId"]),
                        DistrictId = Convert.ToInt32(dr["DistrictId"]),
                        LocalUnitName = Convert.ToString(dr["LocalUnitName"]),
                        LocalUnitNameLocal = Convert.ToString(dr["LocalUnitNameLocal"])
                    });
            }
            return localUnitList;
        }
    }
}