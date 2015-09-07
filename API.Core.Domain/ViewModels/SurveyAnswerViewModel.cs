namespace API.Core.Domain.ViewModels
{
    public class SurveyAnswerViewModel
    {
        public int Id { get; set; }
        public int NextId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string LinkText { get; set; }
        public string Style { get; set; }
        public string Action { get; set; }       

        public string UserInput { get; set; }
        public bool UserResponse { get; set; }
    }
}