using System;
using System.Collections.Generic;

namespace MCQProject.Models
{
    public partial class Mcqproject110723
    {
        public int Id { get; set; }
        public string Question { get; set; } = null!;
        public string? Answer { get; set; }
        public string Option1 { get; set; } = null!;
        public string Option2 { get; set; } = null!;
        public string Option3 { get; set; } = null!;
        public string Option4 { get; set; } = null!;
        public bool? IsActive { get; set; }
    }
}
