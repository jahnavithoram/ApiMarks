using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Model
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       // public string SubID { get; set; }
    }
}
