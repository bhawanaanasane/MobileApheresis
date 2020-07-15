using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
  public  class OtherLabValuesPaginationModel
    {
        public OtherLabValuesPaginationModel()
        {
            List = new List<OtherLabValuesVM>();

        }
        public List<OtherLabValuesVM> List { get; set; }
    }
}
