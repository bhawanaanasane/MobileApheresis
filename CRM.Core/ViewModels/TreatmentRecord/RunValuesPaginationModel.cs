using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Core.ViewModels.TreatmentRecord
{
   public class RunValuesPaginationModel
    {
        
             public RunValuesPaginationModel()
        {
            List = new List<RunValuesVM>();

        }
        public List<RunValuesVM> List { get; set; }
    }
}
