using System;

namespace i502Club.Ccrs.Interfaces
{
    public interface IBaseModel
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ExternalIdentifier { get; set; }
        string Operation { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}