

namespace Business.Models
{
   public class Departamento
    {
        #region Definition of Properties
        public int departamento_Id { get; set; }
        public string nombre { get; set; }
        public string persona_id { get; set; }
       
        
        #endregion
        #region Definition of Constructors
        public Departamento()
        {
            this.departamento_Id = 0;
            this.nombre = string.Empty;
            this.persona_id = string.Empty;
      
        }
        #endregion

    }
}
