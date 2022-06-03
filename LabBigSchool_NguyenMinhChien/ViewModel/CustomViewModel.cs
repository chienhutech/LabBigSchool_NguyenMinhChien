using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabBigSchool_NguyenMinhChien.ViewModel
{
    public class CustomViewModel
    {
        [Required]
        public string Place { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }
    }
}