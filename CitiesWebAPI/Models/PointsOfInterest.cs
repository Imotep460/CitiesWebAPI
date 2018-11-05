using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CitiesWebAPI.Models
{
    public class PointsOfInterest
    {
        [Required (ErrorMessage = "Point of interest {0} is required. Please try again.")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Point of interest {1} is required.")]
        [StringLength (50, MinimumLength = 3, ErrorMessage = "A point of interest must have a name. Please try again.")]
        [DataType (DataType.Text)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Point of interest {2} is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "A point of interests description must be between 3 and 100 charecters long, please try again.")]
        public string Description { get; set; }

        //[Required (ErrorMessage = "Point of interest {3} is required. Please try again.")]
        //public string FoundInCity { get; set; }       
    }
}
