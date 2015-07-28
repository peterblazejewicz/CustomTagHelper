using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomTagHelper.Models
{
    public class User
    {
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfBirth { get; set; }
        public int Id { get; set; }
        public int YearsEmployeed { get; set; }
        public string Blurb { get; set; }
        public string Name { get; set; }

    }
}
