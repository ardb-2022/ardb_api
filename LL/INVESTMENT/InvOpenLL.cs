using System;
using System.Collections.Generic;
using SBWSDepositApi.Deposit;
using SBWSDepositApi.Models;
using SBWSFinanceApi.Config;
using SBWSFinanceApi.DL;
using SBWSFinanceApi.DL.INVESTMENT;
using SBWSFinanceApi.Models;
using SBWSFinanceApi.Utility;

namespace SBWSFinanceApi.LL
{
    public class InvOpenLL
    {
        InvOpenDL _dac = new InvOpenDL();
        internal InvOpenDM GetInvOpeningData(tm_deposit_inv td)
        {
            return _dac.GetInvOpeningData(td);
        }

        internal string InsertInvOpeningData(InvOpenDM td)
        {
            return _dac.InsertInvOpeningData(td);
        }
        
        internal int UpdateInvOpeningData(InvOpenDM td)
        {
            return _dac.UpdateInvOpeningData(td);
        }

        internal int DeleteInvOpeningData(td_def_trans_trf td)
        {
            return _dac.DeleteInvOpeningData(td);
        }
    }
}
