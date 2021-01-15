using SmartCampus.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartCampus.Controllers
{
    public class ProfileController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"
                             select ProfileId,ProfileName from Profile";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SmartCampusAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);

            }
            return Request.CreateResponse(HttpStatusCode.OK, table);

        }
        
        [HttpPost]
        public HttpResponseMessage addDepartment(Profile pro)
        {
            try
            {
                string query = @"INSERT INTO Profile (ProfileName) VALUES ('" +
                pro.ProfileName + "')";


                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SmartCampusAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

      
        public HttpResponseMessage Put(Profile pro)
        {
            try
            {
                string query = @"UPDATE Profile SET ProfileName =  '" + pro.ProfileName + "'  WHERE ProfileId='" + pro.ProfileId + "' ";



                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["SmartCampusAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);

                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
      
      public HttpResponseMessage Delete(int id)
      {
          try
          {
              //               string query = "DELETE from Department whare DepartmentId='" + id + "' ";
              string query = "DELETE FROM Profile WHERE ProfileId='" + id + "'";
              DataTable table = new DataTable();

              using (var con = new SqlConnection(ConfigurationManager.
                  ConnectionStrings["SmartCampusAppDB"].ConnectionString))
              using (var cmd = new SqlCommand(query, con))
              using (var da = new SqlDataAdapter(cmd))
              {
                  cmd.CommandType = CommandType.Text;
                  da.Fill(table);

              }

              return Request.CreateResponse(HttpStatusCode.OK, "delete Successfully!!");
          }
          catch (Exception)
          {

              return Request.CreateResponse(HttpStatusCode.OK);
          }
      }
  }
  
    }

