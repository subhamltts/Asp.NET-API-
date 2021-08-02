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
    public class ParticipantsController : ApiController
    {
        ParticipantsBL blObj; //Refernence Creation
        //Actions
        [HttpGet]
        [ActionName("GetParticipant")]
        public HttpResponseMessage FetchAllParticipant()
        {
            try
            {
                blObj = new ParticipantsBL();
                List<ParticipantDTO> lst = blObj.DisplayParticipant();
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
                    response.Content = new StringContent("There is no participant @ this Moment");
                    return response;
                }
            }
            catch(Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent("Something went Wrong Try after SomeTimes");
                return response;
                throw;
            }
        }
        
        [HttpGet]
        [ActionName("GetParticipantName")]
        public HttpResponseMessage FetchParticipantName(int Pid)
        {
            try
            {
                blObj = new ParticipantsBL();
                List<ParticipantDTO> lst = blObj.GetParticipantName(Pid);
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
                    response.Content = new StringContent("There is no participant @ this Moment");
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
    }
}
