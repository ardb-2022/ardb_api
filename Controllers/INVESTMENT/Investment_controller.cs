using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SBWSDepositApi.Deposit;
using SBWSDepositApi.Models;
using SBWSFinanceApi.LL;
using SBWSFinanceApi.Models;

namespace SBWSFinanceApi.Controllers
{
    [Route("api/INVESTMENT")]
    [ApiController]
    [EnableCors("AllowOrigin")]

    public class Investment_controller
    {
        InvOpenLL _ll = new InvOpenLL();

        [Route("InsertInvOpeningData")]
        [HttpPost]
        public string InsertInvOpeningData([FromBody] InvOpenDM tvd)
        {
            return _ll.InsertInvOpeningData(tvd);
        }

        [Route("GetInvOpeningData")]
        [HttpPost]
        public InvOpenDM GetInvOpeningData([FromBody] tm_deposit_inv tvd)
        {
            return _ll.GetInvOpeningData(tvd);
        }

        
        [Route("UpdateInvOpeningData")]
        [HttpPost]
        public int UpdateInvOpeningData([FromBody] InvOpenDM tvd)
        {
            return _ll.UpdateInvOpeningData(tvd);
        }

        
        [Route("DeleteInvOpeningData")]
        [HttpPost]
        public int DeleteInvOpeningData([FromBody] td_def_trans_trf tvd)
        {
            return _ll.DeleteInvOpeningData(tvd);
        }

    }
}
