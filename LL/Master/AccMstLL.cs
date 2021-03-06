
using System;
using System.Collections.Generic;
using SBWSFinanceApi.Config;
using SBWSFinanceApi.DL;
using SBWSFinanceApi.Models;
using SBWSFinanceApi.Utility;

namespace SBWSFinanceApi.LL
{
    public class AccMstLL
    {
       AccMstDL _dac = new AccMstDL(); 
        public List<m_acc_master> GetAccountMaster(m_acc_master mum)
        {
           return _dac.GetAccountMaster(mum);
        }
        public List<mm_acc_type> GetAccountTypeMaster()
        {
           return _dac.GetAccountTypeMaster();
        }
        public List<mm_constitution> GetConstitution()
        {
           return _dac.GetConstitution();
        }
         public List<mm_oprational_intr> GetOprationalInstr()
        {
           return _dac.GetOprationalInstr();
        }
        
        public List<m_user_master> GetUserDtls(m_user_master mum)
        {
           return _dac.GetUserDtls(mum);
        }

        public List<m_user_type> GetUserType(m_user_type mum)
        {
           return _dac.GetUserType(mum);
        }

        public int UpdateUserstatus(m_user_master mum)
         {
           return _dac.UpdateUserstatus(mum);
        }

        public List<mm_category> GetCategoryMaster()
        {
           return _dac.GetCategoryMaster();
        }
        public List<mm_state> GetStateMaster()
        {
           return _dac.GetStateMaster();
        }
        public List<mm_dist> GetDistMaster()
        {
           return _dac.GetDistMaster();
        }
        public List<mm_vill> GetVillageMaster(mm_vill mum)
        {
           return _dac.GetVillageMaster(mum);
        }
        public List<mm_service_area> GetServiceAreaMaster(mm_service_area mum)
        {
           return _dac.GetServiceAreaMaster(mum);
        }
        public List<mm_block> GetBlockMaster(mm_block mum)
        {
           return _dac.GetBlockMaster(mum);
        }
        public List<mm_kyc> GetKycMaster()
        {
           return _dac.GetKycMaster();
        }
        public List<mm_title> GetTitleMaster()
        {
           return _dac.GetTitleMaster();
        }
         public List<m_branch> GetBranchMaster(m_branch mum)
        {
           return _dac.GetBranchMaster(mum);
        }

        public List<mm_ardb> GetARDBMaster()
        {
           return _dac.GetARDBMaster();
        }
        public List<sm_parameter> GetSystemParameter()
        {
           return _dac.GetSystemParameter();
        }
        internal List<mm_operation> GetOperationMaster()
        {
            return _dac.GetOperationMaster();
        }
        internal List<mm_operation> GetOperationDtls()
        {
            return _dac.GetOperationDtls();
        }
        
        internal List<mm_instalment_type> GetInstalmentTypeMaster()
        {
            return _dac.GetInstalmentTypeMaster();
        }

        internal List<mm_crop> GetCropMaster()
        {
            return _dac.GetCropMaster();
        }

        internal List<mm_activity> GetActivityMaster()
        {
            return _dac.GetActivityMaster();
        }

        internal List<mm_sector> GetSectorMaster()
        {
            return _dac.GetSectorMaster();
        }
        
          
        internal int UpdateSystemParameter(sm_parameter smParam)
        {
            return _dac.UpdateSystemParameter(smParam);
        }

       

    }
}