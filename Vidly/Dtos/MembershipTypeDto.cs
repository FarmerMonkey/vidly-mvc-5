using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }

        //Note: Keep this lightweight--do not include other properties we do not need.
    }
}