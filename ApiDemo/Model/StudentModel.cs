using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo.Model
{
    public class StudentModel:BaseModel
    {
       
        public string Name { get; set; }
        public int Class { get; set; }
        public string Sec { get; set; }

    }
}
