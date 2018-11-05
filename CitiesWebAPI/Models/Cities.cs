using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CitiesWebAPI.Models
{
    public class Cities
    {
        [Required (ErrorMessage ="Cities {0} is required. Please try again.")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Cities {1} is required please input a city name")]
        [StringLength (50, MinimumLength = 3, ErrorMessage = "A city name must be between 3 and 50 charecters long. Please try again.")]
        [DataType (DataType.Text)]
        public string Name { get; set; }

        [Required (ErrorMessage = "Cities {2} is required, a city must have a description")]
        [StringLength (100, MinimumLength = 3, ErrorMessage = "A city description must be between 3 and 100 charecters long. Please try again.")]
        public string Description { get; set; }

        public List<PointsOfInterest> PointOfInterest { get; set; }
    }
}
