using CRUDUsingMVCwithAdoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;
        //To handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);
        }
        //To add employee details
        public bool AddEmployee(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddNewEmpDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@District", obj.District);
            com.Parameters.AddWithValue("@LocalUnit", obj.LocalUnit);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //To view employee details with generic list
        public List<EmpModel> GetAllEmployees()
        {
            connection();
            List<EmpModel> EmpList = new List<EmpModel>();

            SqlCommand com = new SqlCommand("GetEmployees", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind EmpModel generic list using dataRow
            foreach (DataRow dr in dt.Rows)
            {
                EmpList.Add(
                    new EmpModel
                    {
                        Empid = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        State = Convert.ToString(dr["State"]),
                        District = Convert.ToString(dr["District"]),
                        LocalUnit = Convert.ToString(dr["LocalUnit"])
                    }
                    );
            }

            return EmpList;
        }
        //To update Employee details 
        public bool UpdateEmployee(EmpModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateEmpDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", obj.Empid);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@State", obj.State);
            com.Parameters.AddWithValue("@District", obj.District);
            com.Parameters.AddWithValue("@LocalUnit", obj.LocalUnit);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Employee details
        public bool DeleteEmployee(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteEmpById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@EmpId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<StateModel> GetAllStates()
        {
            connection();
            List<StateModel> stateList = new List<StateModel>();

            SqlCommand com = new SqlCommand("Settings.GetStates", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);//RESEARCH IT
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                stateList.Add(
                    new StateModel
                    {
                        StateId = Convert.ToInt32(dr["StateId"]),
                        StateName = Convert.ToString(dr["StateName"]),
                    });
            }
            return stateList;

        }

        //Get all districts
        public List<DistrictModel> GetAllDistricts(string id)
        {
            connection();
            List<DistrictModel> districtList = new List<DistrictModel>();

            SqlCommand com = new SqlCommand("Settings.GetDistricts", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StateId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                districtList.Add(
                    new DistrictModel
                    {
                        DistrictId = Convert.ToInt32(dr["DistrictId"]),
                        DistrictName = Convert.ToString(dr["DistrictName"]),
                    });
            }
            return districtList;
        }

        //Get All LocalUnits
        public List<LocalUnitModel> GetAllLocalUnitModels(string id)
        {
            connection();
            List<LocalUnitModel> localUnitList = new List<LocalUnitModel>();

            SqlCommand com = new SqlCommand("Settings.GetLocalUnits", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@DistrictId", id);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                localUnitList.Add(
                    new LocalUnitModel
                    {
                        LocalUnitId = Convert.ToInt32(dr["LocalUnitId"]),
                        LocalUnitName = Convert.ToString(dr["LocalUnitName"]),
                    });
            }
            return localUnitList;
        }
    }
}