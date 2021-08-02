using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class ParticipantsBL
    {
        ProjextX_DAL.ParticipantsDAL DalObj = new ProjextX_DAL.ParticipantsDAL();
        public ParticipantDTO ParticipantInputValues(int Pid, string Pname, string Pemail)
        {
            try
            {
                ParticipantDTO dto_obj = new ParticipantDTO();
                dto_obj.ParticipantID = Pid;
                dto_obj.ParticipantName = Pname;
                dto_obj.ParticipantEmailID = Pemail;
                

                return dto_obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateParticipantInfo(ParticipantDTO dtonewObj)
        {
            int result = DalObj.UpdateParticipantName(dtonewObj);
            return result;
        }

        public int deleteParticipantInfo(string ParticipantName)
        {
            int result = DalObj.deleteParticipantName(ParticipantName);
            return result;
        }
        public List<ParticipantDTO> DisplayParticipant()
        {
            try
            {
                List<ParticipantDTO> depts = new List<ParticipantDTO>();

                foreach (var item in DalObj.DisplayParticipant())
                {
                    ParticipantDTO dtoObj = new ParticipantDTO
                    {
                        ParticipantID = item.ParticipantID,
                        ParticipantName = item.ParticipantName,
                        ParticipantEmailID = item.ParticipantEmailID,
                        
                    };
                    depts.Add(dtoObj);
                }
                return depts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public List<ParticipantDTO> GetParticipantName(int participantId)
        {
            var partList = DalObj.GetParticipantNameByID(participantId);
            return partList;
        }
        public int UpdateParticipantInfo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
