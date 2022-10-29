using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBWSFinanceApi.LL;
using SBWSFinanceApi.Models;

namespace SBWSFinanceApi.Controllers
{
    [EnableCors("AllowOrigin")] 
    [Route("api/Finance")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        FinanceReportLL _ll = new FinanceReportLL(); 
        [Route("PopulateDailyCashBook")]
        [HttpPost]
        public List<tt_cash_account> PopulateDailyCashBook([FromBody] p_report_param prp)
        {
           return _ll.PopulateDailyCashBook(prp);
        }

        [Route("PopulateDailyCashAccount")]
        [HttpPost]
        public List<tt_cash_account> PopulateDailyCashAccount([FromBody] p_report_param prp)
        {
            return _ll.PopulateDailyCashAccount(prp);
        }

        [Route("PopulateCashCumTrial")]
        [HttpPost]
        public List<tt_cash_cum_trial> PopulateCashCumTrial([FromBody] p_report_param prp)
        {
           return _ll.PopulateCashCumTrial(prp);
        }
        
        [Route("PopulateDayScrollBook")]
        [HttpPost]
        public List<tt_day_scroll> PopulateDayScrollBook([FromBody] p_report_param prp)
        {      
           return _ll.PopulateDayScrollBook(prp);
        }

        [Route("PopulateBalanceSheet")]
        [HttpPost]
        public List<tt_balance_sheet> PopulateBalanceSheet([FromBody] p_report_param prp)
        {
            return _ll.PopulateBalanceSheet(prp);
        }

        [Route("PopulateProfitandLoss")]
        [HttpPost]
        public List<tt_pl_book> PopulateProfitandLoss([FromBody] p_report_param prp)
        {
            return _ll.PopulateProfitandLoss(prp);
        }

        [Route("GetGeneralLedger")]
      [HttpPost]
      public List<tt_gl_trans> GetGeneralLedger([FromBody] p_report_param prm)
      {
         return _ll.GetGeneralLedger(prm);
      }

        
      [Route("GetGLTransDtls")]
      [HttpPost]
      public List<tt_gl_trans> GetGLTransDtls([FromBody] p_report_param prm)
        {
            return _ll.GetGLTransDtls(prm);
        }


      [Route("PopulateTrialBalance")]
      [HttpPost]
      public List<tt_trial_balance> PopulateTrialBalance([FromBody] p_report_param prm)
      {
         return _ll.PopulateTrialBalance(prm);
      }
        

      [Route("PopulateTrialGroupwise")]
      [HttpPost]
      public List<trailDM> PopulateTrialGroupwise([FromBody] p_report_param prm)
        {
            return _ll.PopulateTrialGroupwise(prm);
        }

    }
}

