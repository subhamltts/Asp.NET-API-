using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class FacultyDAL
    {
        Faculty FacObj;
        public int UpdateFacultyName(FacultyDTO DtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB(); //connection to Db
                FacObj = XobjDB.Faculties.SingleOrDefault(d => d.FacultyName == DtoObj.FacultyName);
                if (FacObj != null)
                {
                    FacObj.PSNo = DtoObj.PSNo;
                    FacObj.FacultyName = DtoObj.FacultyName;
                    FacObj.EmailID = DtoObj.EmailID;
                    XobjDB.SaveChanges();
                    status = 1;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Update failed. Enter Proper Name");
            }
            return status;
        }
        public int DeleteFacultyName(string FacultyName)
        {
            int status = 0;
            try
            {

                ProjectX_DB XobjDB = new ProjectX_DB();



                FacObj = XobjDB.Faculties.SingleOrDefault(d => d.FacultyName == FacultyName);
                if (FacObj != null)
                {
                    XobjDB.Faculties.Remove(FacObj);
                    XobjDB.SaveChanges();


                }
                else
                    throw new Exception();

            }

            catch (Exception)
            {
                Console.WriteLine("Deletion failed. Something Went Wrong");
            }
            return status;
        }
        public List<Faculty> DisplayFaculty()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Faculty> deptList = display.Faculties.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<FacultyDTO> GetFacultyNameByID(int partId)
        {
            try
            {
                List<FacultyDTO> lstResult = new List<FacultyDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Faculties.
                    Where(x => x.PSNo == partId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new FacultyDTO()
                    {
                        PSNo = item.PSNo,
                        FacultyName = item.FacultyName,
                        EmailID = item.EmailID
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
