namespace i502Club.Ccrs.Enums
{
    public enum LabTestStatus
    {
        Required = 1,
        NotRequired,
        Pass, 
        Fail,
        FailExtractableOnly, 
        FailRetestAllowed,
        FailRetestAllowedExtractable,
        FailRetestAllowedExtractableOnly,
        InProcess,
        SampleCreated
    }
}
