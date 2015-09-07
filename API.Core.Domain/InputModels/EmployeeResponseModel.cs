namespace API.Core.Domain.InputModels
{
    public class EmployeeResponseModel
    {
        public int CurrentQuestionId { get; set; }
        public int SurveyId { get; set; }     
        public string Response { get; set; }
    }
}
