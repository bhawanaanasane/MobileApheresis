using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAheresisAdmin.Models.Treatments
{
    public class CommentTypeListModel : BaseEntityModel
    {
        public CommentTypeListModel() {
            this.commentTypes = new List<CommentTypeModel>();
        }
        public IList<CommentTypeModel> commentTypes {get;set;}
    }
}
