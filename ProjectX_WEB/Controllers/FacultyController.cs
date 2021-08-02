using Newtonsoft.Json;
using ProjectX_BL;
using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectX_WEB.Controllers
{
    public class FacultyController : ApiController
    {
        FacultyBL blObj; //Refernence Creation
        //Actions
        [HttpGet]
        [ActionName("GetFaculty")]
        public HttpResponseMessage FetchAllFaculty()
        {
            try
            {
                blObj = new FacultyBL();
                List<FacultyDTO> lst = blObj.DisplayFaculty();
                if (lst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no faculty @ this Moment");
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw;
            }
        }

        [HttpGet]
        [ActionName("GetFacultyName")]
        public HttpResponseMessage FetchParticipantName(int Pid)
        {
            try
            {
                blObj = new FacultyBL();
                List<FacultyDTO> lst = blObj.GetFacultyName(Pid);
                if (lst != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(lst));
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NoContent);
                    response.Content = new StringContent("There is no Faculty @ this Moment");
                    return response;
                }
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw ex;
            }
        }
    }
}
