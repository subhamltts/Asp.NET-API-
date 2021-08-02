using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class ParticipantsDAL
    {
        Participant PartObj;
        public int UpdateParticipantName(ParticipantDTO DtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB(); //connection to Db
                PartObj = XobjDB.Participants.SingleOrDefault(d => d.ParticipantName == DtoObj.ParticipantName);
                if (PartObj != null)
                {
                    PartObj.ParticipantID = DtoObj.ParticipantID;
                    PartObj.ParticipantName = DtoObj.ParticipantName;
                    PartObj.ParticipantEmailID = DtoObj.ParticipantEmailID;
                    XobjDB.SaveChanges();
                    status = 1;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Update failed. Enter Proper Name");
            }
            return status;
        }
        public int deleteParticipantName(string ParticipantName)
        {
            int status = 0;
            try
            {

                ProjectX_DB XobjDB = new ProjectX_DB();



                PartObj = XobjDB.Participants.SingleOrDefault(d => d.ParticipantName == ParticipantName);
                if (PartObj != null)
                {
                    //XobjDB.Participants.Attach(PartObj);
                    XobjDB.Participants.Remove(PartObj);
                    XobjDB.SaveChanges();


                }
                else
                    throw new Exception();

            }

            catch (Exception )
            {
                Console.WriteLine("Deletion failed. Something Went Wrong");
            }
            return status;
        }
        public List<Participant> DisplayParticipant()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Participant> deptList = display.Participants.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ParticipantDTO> GetParticipantNameByID(int partId)
        {
            try
            {
                List<ParticipantDTO> lstResult = new List<ParticipantDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Participants.
                    Where(x => x.ParticipantID == partId).ToList();
                foreach(var item in rndPartList)
                {
                    lstResult.Add(new ParticipantDTO()
                    {
                        ParticipantID = item.ParticipantID,
                        ParticipantName = item.ParticipantName,
                        ParticipantEmailID = item.ParticipantEmailID
                    });
                }
                return lstResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
