namespace HelocService.BusinessExpert
{
    public interface IWorkFlowExpert
    {
        bool StartWorkFlow(string _inputFile, string _trackingId);
    }
}
