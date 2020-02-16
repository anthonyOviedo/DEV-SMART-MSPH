using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Form 
    {

        #region Definition of Properties

        public int id{ get; set; }
        public string nombre { get; set; }
        public string departmentId{ get; set; }
        public string FormType { get; set; }
        public DateTime dateRegistered{ get; set; }
        public string html { get; set; }

        #endregion

    }
}
