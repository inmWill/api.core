using System;

namespace API.Core.Domain.ViewModels
{
    public class SurveyViewModel
    {
        public string Title { get; set; }

        public string Instructions { get; set; }

        public string OtherInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Client_Id { get; set; }
    }
}
