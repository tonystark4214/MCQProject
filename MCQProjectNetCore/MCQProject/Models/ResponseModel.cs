namespace MCQProject.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public List<MCQQuestionModel> Question { get; set; }
        public List<MCQUserModel> UserList { get; set; }
        public MCQUserModel User { get; set; }
    }
}
