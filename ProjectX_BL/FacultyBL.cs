using ProjectX_DTO;
using ProjextX_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectX_BL
{
    public class FacultyBL
    {
        ProjextX_DAL.FacultyDAL DalObj = new ProjextX_DAL.FacultyDAL();
        public FacultyDTO FacultyInputValues(int Pid, string Pname, string Pemail)
        {
            try
            {
                FacultyDTO dto_obj = new FacultyDTO();
                dto_obj.PSNo = Pid;
                dto_obj.FacultyName = Pname;
                dto_obj.EmailID = Pemail;


                return dto_obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateFacultyInfo(FacultyDTO dtonewObj)
        {
            int result = DalObj.UpdateFacultyName(dtonewObj);
            return result;
        }

        public int deleteFacultyInfo(string FName)
        {
            int result = DalObj.DeleteFacultyName(FName);
            return result;
        }
        public List<FacultyDTO> DisplayFaculty()
        {
            try
            {
                List<FacultyDTO> depts = new List<FacultyDTO>();

                foreach (var item in DalObj.DisplayFaculty())
                {
                    FacultyDTO dtoObj = new FacultyDTO
                    {
                        PSNo = item.PSNo,
                        FacultyName = item.FacultyName,
                        EmailID = item.EmailID,

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

        public List<FacultyDTO> GetFacultyName(int FId)
        {
            var partList = DalObj.GetFacultyNameByID(FId);
            return partList;
        }
        public int UpdateFacultyInfo(string name)
        {
            throw new NotImplementedException();
        }
    }
}
