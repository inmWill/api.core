using System;
using System.Collections.Generic;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Clients;

namespace API.Core.Domain.Models.SurveyBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public class Survey : BaseEntity
    {
        
        public int Id { get; set; }
        public string Title { get; set; }

        public string Instructions { get; set; }

        public string OtherInfo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual ICollection<AppUserInfo> Employees { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public int Client_Id { get; set; }
        public Client Client { get; set; }   
    }
}
