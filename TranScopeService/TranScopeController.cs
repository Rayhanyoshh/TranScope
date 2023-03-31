
using Microsoft.AspNetCore.Mvc;
using R_Common;
using TranScopeBack;
using TranScopeCommon;


namespace TransScopeService
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TranScopeController : ControllerBase, ITranScope
    {
        [HttpPost]
        public TranScopeResultDTO ProcessAllWithTransactionDB(int poProcessRecordCount)
        {
            R_Exception loException = new R_Exception();
            TranScopeResultDTO loRtn = null;
            TranScopeCls loCls;

            try
            {
                loCls = new TranScopeCls();
                loRtn = new TranScopeResultDTO();
                loRtn.data = loCls.ProcessAllWithTransactionDB(poProcessRecordCount);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }

        [HttpPost]
        public TranScopeResultDTO ProcessWithoutTransaction(int ProcessRecordCount)
        {
            R_Exception loException = new R_Exception();
            TranScopeResultDTO loRtn = null;
            TranScopeCls loCls;

            try
            {
                loCls = new TranScopeCls();
                loRtn = new TranScopeResultDTO();
                loRtn.data = loCls.ProcessWithoutTransactionDB(ProcessRecordCount);
            }
            catch (Exception ex)
            {
                loException.Add(ex);
            }
        EndBlock:
            loException.ThrowExceptionIfErrors();

            return loRtn;
        }
    }
}