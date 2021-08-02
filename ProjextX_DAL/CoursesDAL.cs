using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class CoursesDAL
    {
        Cours CouObj;
        public int UpdateCourseName(CoursesDTO DtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB(); //connection to Db
                CouObj = XobjDB.Courses.SingleOrDefault(d => d.CourseTitle == DtoObj.CourseTitle);
                if (CouObj != null)
                {
                    CouObj.CourseID = DtoObj.CourseID;
                    CouObj.CourseTitle = DtoObj.CourseTitle;
                    CouObj.Duration = DtoObj.Duration;
                    CouObj.Owner = DtoObj.Owner;
                    CouObj.AssessmentMode = DtoObj.AssessmentMode;
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
        public int DeleteCourseName(string cId)
        {
            int status = 0;
            try
            {

                ProjectX_DB XobjDB = new ProjectX_DB();

                CouObj = XobjDB.Courses.SingleOrDefault(d => d.CourseTitle == cId);
                if (CouObj != null)
                {
                    XobjDB.Courses.Remove(CouObj);
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
        public List<Cours> DisplayBatch()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Cours> deptList = display.Courses.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<CoursesDTO> GetCourseNameByID(string CouId)
        {
            try
            {
                List<CoursesDTO> lstResult = new List<CoursesDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Courses.
                    Where(x => x.CourseID == CouId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new CoursesDTO()
                    {
                        CourseID = item.CourseID,
                        CourseTitle = item.CourseTitle,
                        Duration = item.Duration,
                        Owner = item.Owner,
                        AssessmentMode = item.AssessmentMode
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
