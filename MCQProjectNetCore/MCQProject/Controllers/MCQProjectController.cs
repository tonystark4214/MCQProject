using MCQProject.Models;
using MCQProject.Respository;
using Microsoft.AspNetCore.Mvc;

namespace MCQProject.Controllers
{
    public class MCQProjectController : Controller
    {
        private readonly IMCQProject imcq;
        public MCQProjectController(IMCQProject imcq)
        {
            this.imcq = imcq;
        }

        [HttpGet]
        [Route("GetQuestions")]
        public IActionResult GetQuestions()
        {
            return Ok(imcq.GetQuestions());
        }

        [HttpGet]
        [Route("GetUserList")]
        public IActionResult GetUserList()
        {
            return Ok(imcq.GetUserList());
        }

        [HttpGet]
        [Route("GetSingleUser")]
        public IActionResult GetSingleUser(int id)
        {
            return Ok(imcq.GetSingleUser(id));
        }

        [HttpPost]
        [Route("PostUserData")]
        public IActionResult PostUserData([FromBody] MCQUserModel user)
        {
            if (!ModelState.IsValid)
            {
                ResponseModel response = new ResponseModel();
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage));
                response.Message = message;

                return Ok(response);

            }
            return Ok(imcq.PostUserData(user));
        }

        [HttpPost]
        [Route("PostQuestion")]
        public IActionResult PostQuestion([FromBody] MCQQuestionModel question)
        {
            if (!ModelState.IsValid)
            {
                ResponseModel response = new ResponseModel();
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                 .Select(e => e.ErrorMessage));
                response.Message = message;

                return Ok(response);

            }
            return Ok(imcq.PostQuestion(question));
        }
    }
}
