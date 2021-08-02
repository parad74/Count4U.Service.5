using System.ComponentModel.DataAnnotations;

namespace Count4U.Service.Model
{ 
	public class FormExample
    {
        [Required]
        public Person SelectedPerson { get; set; }
    }
    
}