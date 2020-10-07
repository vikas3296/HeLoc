namespace HelocService.Models.InputCopyBookModels
{
    public class EConsentInput
    {
        public EConsentInput()
        {
            EConsentRecord = new EConsentModel();
        }
        public EConsentModel EConsentRecord { get; set; }
    }
}
