using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class GraderDAL
    {
        Grader GraObj;
        public int UpdateGraderName(GraderDTO DtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB(); //connection to Db
                GraObj = XobjDB.Graders.SingleOrDefault(d => d.Marks_Obtained == DtoObj.Marks_Obtained);
                if (GraObj != null)
                {
                    GraObj.BatchID = DtoObj.BatchID;
                    GraObj.ParticipantID = DtoObj.ParticipantID;
                    GraObj.CourseID = DtoObj.CourseID;
                    GraObj.Marks_Obtained = DtoObj.Marks_Obtained;
                    GraObj.Feedback = DtoObj.Feedback;
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
        public int DeleteGraderName(string cId)
        {
            int status = 0;
            try
            {

                ProjectX_DB XobjDB = new ProjectX_DB();

                GraObj = XobjDB.Graders.SingleOrDefault(d => d.BatchID == cId);
                if (GraObj != null)
                {
                    XobjDB.Graders.Remove(GraObj);
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
        public List<GraderDTO> GetCourseameByMarks(int CouId)
        {
            try
            {
                List<GraderDTO> lstResult = new List<GraderDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Graders.
                    Where(x => x.Marks_Obtained == CouId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new GraderDTO()
                    {
                        BatchID = item.BatchID,
                        ParticipantID = item.ParticipantID,
                        CourseID = item.CourseID,
                        Marks_Obtained = item.Marks_Obtained,
                        Feedback = item.Feedback
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
