using MCQProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MCQProject.Respository
{
    public class MCQProjectClass:IMCQProject
    {
        private readonly sdirectdbContext dbContext;
        public MCQProjectClass(sdirectdbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ResponseModel GetQuestions()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var data = (from u in dbContext.Mcqproject110723s
                            select new MCQQuestionModel
                            {
                                Id = u.Id,
                                Question= u.Question,
                                Answer= u.Answer,
                                Option1 = u.Option1,
                                Option2 = u.Option2,
                                Option3 = u.Option3,
                                Option4 = u.Option4
                            }).ToList();
                response.Question = data;
                response.Message = "Questions fetched succesfull";
            }
            catch(Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public ResponseModel GetUserList()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var data = (from u in dbContext.McqprojectUser110723s
                            select new MCQUserModel
                            {
                                Id = u.Id,
                                UserName = u.UserName,
                                Qattempted = u.Qattempted,
                                TotalQ = u.TotalQ,
                                SubmissionDate = u.SubmissionDate,
                                CorrectQ = u.CorrectQ
                            }).ToList();
                response.UserList = data;
                response.Message = "User List fetched succesfully";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public ResponseModel GetSingleUser(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var checkUserExist = dbContext.McqprojectUser110723s.Where(i => i.Id == id).FirstOrDefault();
                if(checkUserExist == null)
                {
                    response.Message = "User doesn't exist";
                    return response;
                }
                var data = (from u in dbContext.McqprojectUser110723s
                            where u.Id==id
                            select new MCQUserModel
                            {
                                Id = u.Id,
                                UserName = u.UserName,
                                Qattempted = u.Qattempted,
                                TotalQ = u.TotalQ,
                                SubmissionDate = u.SubmissionDate,
                                CorrectQ = u.CorrectQ
                            }).FirstOrDefault();
                response.User = data;
                response.Message = "User List fetched succesfully";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public ResponseModel PostUserData(MCQUserModel user)
        {
            ResponseModel response=new ResponseModel();
            try
            {
                var builder = WebApplication.CreateBuilder();
                string conStr = builder.Configuration.GetConnectionString("con");
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("AddUserorQue", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("command", SqlDbType.VarChar).Value = "user";
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = user.Id;
                cmd.Parameters.Add("UserName", SqlDbType.VarChar).Value = user.UserName;
                cmd.Parameters.Add("QAttempted", SqlDbType.Int).Value = user.Qattempted;
                cmd.Parameters.Add("TotalQ", SqlDbType.Int).Value = user.TotalQ;
                cmd.Parameters.Add("CorrectQ", SqlDbType.Int).Value = user.CorrectQ;
                cmd.ExecuteNonQuery();
                response.Message = "User Data Added Succesfully";
            }
            catch(Exception e)
            {
                response.Message=e.Message;
            }
            return response;
        }

        public ResponseModel PostQuestion(MCQQuestionModel question)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var builder = WebApplication.CreateBuilder();
                string conStr = builder.Configuration.GetConnectionString("con");
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand("AddUserorQue", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("command", SqlDbType.VarChar).Value = "question";
                cmd.Parameters.Add("Id", SqlDbType.Int).Value = question.Id;
                cmd.Parameters.Add("Question", SqlDbType.VarChar).Value = question.Question;
                cmd.Parameters.Add("Answer", SqlDbType.Int).Value = question.Answer;
                cmd.Parameters.Add("Option1", SqlDbType.VarChar).Value = question.Option1;
                cmd.Parameters.Add("Option2", SqlDbType.VarChar).Value = question.Option2;
                cmd.Parameters.Add("Option3", SqlDbType.VarChar).Value = question.Option3;
                cmd.Parameters.Add("Option4", SqlDbType.VarChar).Value = question.Option4;
                cmd.ExecuteNonQuery();
                response.Message = "Question Added Succesfully";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
