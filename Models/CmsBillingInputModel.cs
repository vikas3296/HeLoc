using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelocService.Models.InputCopyBookModels
{
    public class CmsBillingInputModel
    {
        public CmsBillingInputModel()
        {
            DetRecord = new DetModel();
            TransRecord = new TransModel();
        }
        public DetModel DetRecord { get; set; }
        public TransModel TransRecord { get; set; }
    }
}
