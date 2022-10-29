
using System;
using System.Collections.Generic;
using SBWSFinanceApi.Config;
using SBWSFinanceApi.DL;
using SBWSFinanceApi.Models;
using SBWSFinanceApi.Utility;

namespace SBWSFinanceApi.LL
{
    public class FinanceReportLL
    {
       CashCumTrialDL _dacCashCumTrialDL = new CashCumTrialDL(); 
        internal List<tt_cash_cum_trial> PopulateCashCumTrial(p_report_param prp)
        {         
            return _dacCashCumTrialDL.PopulateCashCumTrial(prp);
        }  

         TrialBalanceDL _dacTrialBalanceDL = new TrialBalanceDL(); 
        internal List<tt_trial_balance> PopulateTrialBalance(p_report_param prp)
        {         
            return _dacTrialBalanceDL.PopulateTrialBalance(prp);
        }


        TrialBalanceDL _dacTrialBalanceDL1 = new TrialBalanceDL();
        internal List<trailDM> PopulateTrialGroupwise(p_report_param prp)
        {
            return _dacTrialBalanceDL1.PopulateTrialGroupwise(prp);
        }

        DailyCashBookDL _dacDailyCashBookDL = new DailyCashBookDL(); 
        internal List<tt_cash_account> PopulateDailyCashBook(p_report_param prp)
        {         
            return _dacDailyCashBookDL.PopulateDailyCashBook(prp);
        }

        internal List<tt_cash_account> PopulateDailyCashAccount(p_report_param prp)
        {
            return _dacDailyCashBookDL.PopulateDailyCashAccount(prp);
        }

        DayScrollBookDL _dacDayScrollBookDL = new DayScrollBookDL(); 
        internal List<tt_day_scroll> PopulateDayScrollBook(p_report_param prp)
        {     
              return _dacDayScrollBookDL.PopulateDayScrollBook(prp);          
        }

        BalanceSheet _dacBalanceSheetDL = new BalanceSheet();
        internal List<tt_balance_sheet> PopulateBalanceSheet(p_report_param prp)
        {
            return _dacBalanceSheetDL.PopulateBalanceSheet(prp);
        }

        ProfitandLoss _dacProfitandLossDL = new ProfitandLoss();
        internal List<tt_pl_book> PopulateProfitandLoss(p_report_param prp)
        {
            return _dacProfitandLossDL.PopulateProfitandLoss(prp);
        }

        internal List<tt_gl_trans> GetGeneralLedger(p_report_param prm)
        {
            var _dac = new RptGeneralLedgerTransactionDtlsDL();
            return _dac.GetGeneralLedger(prm);
        }

        internal List<tt_gl_trans> GetGLTransDtls(p_report_param prm)
        {
            var _dac = new RptGeneralLedgerTransactionDtlsDL();
            return _dac.GetGLTransDtls(prm);
        }

    }
}