using i502Club.Ccrs.Enums;
using i502Club.Ccrs.Interfaces;
using System;

namespace i502Club.Ccrs.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public string ExternalIdentifier { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public OperationType Operation { get; set; }
    }
}
