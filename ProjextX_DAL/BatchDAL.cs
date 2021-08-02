using ProjectX_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjextX_DAL
{
    public class BatchDAL
    {
        Batch BatObj;
        public int UpdateBatchName(BatchDTO DtoObj)
        {
            int status = 0;
            try
            {
                ProjectX_DB XobjDB = new ProjectX_DB(); //connection to Db
                BatObj = XobjDB.Batches.SingleOrDefault(d => d.BatchName == DtoObj.BatchName);
                if (BatObj != null)
                {
                    BatObj.BatchID = DtoObj.BatchID;
                    BatObj.BatchName = DtoObj.BatchName;
                    BatObj.BatchStrength = DtoObj.BatchStrength;
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
        public int DeleteBatchName(string batchName)
        {
            int status = 0;
            try
            {

                ProjectX_DB XobjDB = new ProjectX_DB();



                BatObj = XobjDB.Batches.SingleOrDefault(d => d.BatchName == batchName);
                if (BatObj != null)
                {
                    XobjDB.Batches.Remove(BatObj);
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
        public List<Batch> DisplayBatch()
        {
            try
            {
                var display = new ProjectX_DB();

                List<Batch> deptList = display.Batches.ToList();

                return deptList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BatchDTO> GetBatchNameByID(string BatId)
        {
            try
            {
                List<BatchDTO> lstResult = new List<BatchDTO>();
                ProjectX_DB XobjDB = new ProjectX_DB();
                var rndPartList = XobjDB.Batches.
                    Where(x => x.BatchName == BatId).ToList();
                foreach (var item in rndPartList)
                {
                    lstResult.Add(new BatchDTO()
                    {
                        BatchID = item.BatchID,
                        BatchName = item.BatchName,
                        BatchStrength = item.BatchStrength
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
