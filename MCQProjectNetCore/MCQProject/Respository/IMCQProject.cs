using MCQProject.Models;

namespace MCQProject.Respository
{
    public interface IMCQProject
    {
        public ResponseModel GetQuestions();
        public ResponseModel GetUserList();
        public ResponseModel GetSingleUser(int id);

        public ResponseModel PostUserData(MCQUserModel user);

        public ResponseModel PostQuestion(MCQQuestionModel user);
    }
}
