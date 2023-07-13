using System;
using System.Collections.Generic;

namespace MCQProject.Models
{
    public partial class McqprojectUser110723
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int? Qattempted { get; set; }
        public int? TotalQ { get; set; }
        public int? CorrectQ { get; set; }
        public DateTime? SubmissionDate { get; set; }
    }
}
