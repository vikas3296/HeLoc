using HelocService.Models.InputCopyBookModels.MortgageLoanBillingModels;
using System.Collections.Generic;

namespace HelocService.Models.InputCopyBookModels
{
    public class AccountsModel
    {
        public AccountsModel()
        {
            //ActiveBankruptcyInformationRecordModel = new ActiveBankruptcyInformationRecordModel();
            //ArchivedBankruptcyDetailRecordModel = new List<ArchivedBankruptcyDetailRecordModel>();
            //BlendedRateInformationRecordModel = new BlendedRateInformationRecordModel();
            //CoBorrowerRecordModel = new CoBorrowerRecordModel();
            //DisasterTrackingRecordModel = new DisasterTrackingRecordModel();
            //EmailAddressRecordModel = new EmailAddressRecordModel();
            //EscrowRecordModel = new List<EscrowRecordModel>();
            //FeeRecordModel = new List<FeeRecordModel>();
            //ForeignInformationRecordModel = new ForeignInformationRecordModel();
            //LateChargeDetailRecordModel = new LateChargeDetailRecordModel();
            //LateChargeInformationRecordModel = new LateChargeInformationRecordModel();
            MasterFileDataPart_1Model = new MasterFileDataPart_1Model();
            MasterFileDataPart2Model = new MasterFileDataPart2Model();
            MultiLockboxRecordModel = new MultiLockboxRecordModel();
            OptionalItemEscrowRecordModel = new List<OptionalItemEscrowRecordModel>();
            PL_RecordModel = new PL_RecordModel();
            //RateReductionRecordModel = new RateReductionRecordModel();
            //RHCDSOnlyRecordModel = new RHCDSOnlyRecordModel();
            //SolicitationRecordModel = new SolicitationRecordModel();
            //TrailerRecordModel = new TrailerRecordModel();
            //TransactionRecordModelList = new List<TransactionRecordModel>();
            //UserFieldRecordModel = new UserFieldRecordModel();
            //detModel = new DetModel();
            //EConsentModel = new EConsentModel();
            //CmsBillInput = new CmsBillingInputModel();
            //SupplementalCCFModel = new SupplementalCCFModel();
        }
        //public ActiveBankruptcyInformationRecordModel ActiveBankruptcyInformationRecordModel { get; set; }
        //public List<ArchivedBankruptcyDetailRecordModel> ArchivedBankruptcyDetailRecordModel { get; set; }
        //public BlendedRateInformationRecordModel BlendedRateInformationRecordModel { get; set; }
        //public CoBorrowerRecordModel CoBorrowerRecordModel { get; set; }
        //public DisasterTrackingRecordModel DisasterTrackingRecordModel { get; set; }
        //public EmailAddressRecordModel EmailAddressRecordModel { get; set; }
        //public List<EscrowRecordModel> EscrowRecordModel { get; set; }
        //public List<FeeRecordModel> FeeRecordModel { get; set; }
        //public ForeignInformationRecordModel ForeignInformationRecordModel { get; set; }
        //public LateChargeDetailRecordModel LateChargeDetailRecordModel { get; set; }
        //public LateChargeInformationRecordModel LateChargeInformationRecordModel { get; set; }
        public MasterFileDataPart_1Model MasterFileDataPart_1Model { get; set; }
        public MasterFileDataPart2Model MasterFileDataPart2Model { get; set; }
        public MultiLockboxRecordModel MultiLockboxRecordModel { get; set; }
        public List<OptionalItemEscrowRecordModel> OptionalItemEscrowRecordModel { get; set; }
        public PL_RecordModel PL_RecordModel { get; set; }
        //public RateReductionRecordModel RateReductionRecordModel { get; set; }
        //public RHCDSOnlyRecordModel RHCDSOnlyRecordModel { get; set; }
        //public SolicitationRecordModel SolicitationRecordModel { get; set; }
        //public TrailerRecordModel TrailerRecordModel { get; set; }
        //public List<TransactionRecordModel> TransactionRecordModelList { get; set; }
        //public UserFieldRecordModel UserFieldRecordModel { get; set; }
        public bool IsMatched { get; set; } = false;

        //public DetModel detModel { get; set; }
        //public SupplementalCCFModel SupplementalCCFModel { get; internal set; }

        //public EConsentModel EConsentModel { get; set; }
        //public CmsBillingInputModel CmsBillInput { get; set; }
    }
}
