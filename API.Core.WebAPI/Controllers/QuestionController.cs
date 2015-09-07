using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Domain.ViewModels;
using API.Core.Service.Interfaces;
using API.Core.Utils.Common;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService = null;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public QuestionController(IQuestionService questionService)
        {
            //if (questionService == null)
            //    throw new ArgumentNullException("questionService");            

            //_surveyQService = questionService;

            _questionService = questionService.CheckNull<IQuestionService>("questionService");
        }


        public IHttpActionResult Get()
        {

            try
            {
                var questions = _questionService.Get().AsQueryable<Question>();

                if (questions == null) // expression is always false
                    return NotFound();

                return Ok(questions);
            }
            catch (Exception ex)
            {
                _logger.Error("Error retrieving questions: {0}", ex.Message);
                return BadRequest();
            }

        }

        public IHttpActionResult Get(int id)
        {
            try
            {

                var question = _questionService.Get(id);

                if (question == null)
                    return NotFound();

                return Ok(question);
            }
            catch (Exception ex)
            {
                _logger.Error("Error retrieving question: {0}", ex.Message);
                return BadRequest();
            }

        }

        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult GetMockQuestion(int id)
        {
            try
            {
                var mockQuestions = BuildMockSurvey();
                var question = mockQuestions.FirstOrDefault(q => q.Id == id);

                return Ok(question);
            }
            catch (Exception ex)
            {
                _logger.Error("Error retrieving question: {0}", ex.Message);
                return BadRequest();
            }

        }


        // this is temporary while we figure out the repo to view model transformation for survey questions.
        private static IEnumerable<SurveyQuestionViewModel> BuildMockSurvey()
        {
            var mockQuestions = new List<SurveyQuestionViewModel>();

            var question1 = new SurveyQuestionViewModel
            {
                Id = 1,
                Title = "Hi ACTIVEUSER, Please choose the option that best describes your relationship with USERSPOUSE.",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "First question in flow.",
                Type = "MultipleChoiceSimple",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 111,
                        NextId = 2,
                        Title = "Spouse",
                        Description = "Legally married spouse",
                        LinkText = "",
                        Style = "blockButton-info",
                        UserInput = "Spouse",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 112,
                        NextId = 2,
                        Title = "Domestic Partner",
                        Description = "DP Definition from client.",
                        LinkText = "",
                        Style = "blockButton-info",
                        UserInput = "Domestic Partner",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 113,
                        NextId = 999,
                        Title = "Ineligible Participant",
                        Description = "The dependent currently enrolled does not meet the definition of a Spouse or Domestic Partner.",
                        LinkText = "",
                        Style = "blockButton-warning",
                        UserInput = "Ineligible Participant",
                        Action = ""
                    }
                }
            };

            mockQuestions.Add(question1);

            var question2 = new SurveyQuestionViewModel
            {
                Id = 2,
                Title = "Choose the option that best describes your Spouse or Domestic Partner's working status.",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "Second question in flow.",
                Type = "MultipleChoiceSimple",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 211,
                        NextId = 3,
                        Title = "Employed",
                        Description = "Your spouse or domestic partner works for an organization, institution, government entity, agency, company, professional services firm, small business, store or individual where they earn a wage or salary.",
                        LinkText = "",
                        Style = "blockButton-info",
                        UserInput = "Employed",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 212,
                        NextId = 4,
                        Title = "Employed by Demo Company",
                        Description = "Your spouse or domestic partner is also an employee of ABC Company where they earn a wage or salary.",
                        LinkText = "",
                        Style = "blockButton-info",
                        UserInput = "Employed by Demo Company",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 213,
                        NextId = 4,
                        Title = "Self-Employed",
                        Description = "Your spouse or domestic partner works for himself or herself instead of working for an employer that pays a salary or wage where they earn their income through profitable operations from a trade or business that they operate directly.",
                        LinkText = "",
                        Style = "blockButton-info",
                        UserInput = "Self-Employed",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 214,
                        NextId = 4,
                        Title = "Unemployed",
                        Description = "Your spouse or domestic partner does not have a job.",
                        LinkText = "",
                        Style = "blockButton-warning",
                        UserInput = "Unemployed",
                        Action = ""
                    }
                }
            };

            mockQuestions.Add(question2);

            var question3 = new SurveyQuestionViewModel
            {
                Id = 3,
                Title = "Thank You!  You have indicated your spouse or domestic partner is employed. To complete the required verification you have two options to choose from. please select the option you feel is applicable to you.",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "Third question in flow.",
                Type = "MultipleChoiceDetailed",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 311,
                        NextId = 5,
                        Title = "Option 1",
                        Description = "<ul><li>Condition 1</li><li>Condition 2</li><li>Condition 3</li></ul><p>If all of the above conditions above are met, then you will be required to pay an additional contribution to ABC Company that will be withheld from your wages or salary.  If you don't know if all of the conditions apply to your spouse or domestic partner and their employer, we recommmed you proceed with Option 2 and we will obtain more information for you.  However, if you know all of these conditions apply to your spouse or domestic partner and their employer then click the 'Surcharge Applies' button below.</p>",
                        LinkText = "Surcharge Applies",
                        Style = "blockButton-info",
                        UserInput = "Option 1",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 312,
                        NextId = 6,
                        Title = "Option 2",
                        Description = "<p>If you do not believe or cannot confirm all of the conditions required by ABC Company are met you will need to proceed with this option.  By proceeding with this option you will need to do the following after you click the >>Next button below:</p><ul><li>You will be provided a form on ??Where?? that you will need to print and provide to your spouse or domestic partner</li><li>Your spouse or domestic partner will be required to provide sign and date section 1 of the form.  By signing the form your spouse or domestic partner will authorize ConSova Corporation to contact their employer.</li><li>Your spouse or domestic partner or their employer must complete all requested information on section 2 of the form.</li><li>ConSova Corporation may contact your spouse or domestic partner's employer to verify benefit eligibility.</li></ul><p>Please note if you select Option 1 above you, your spouse or domestic partner or their employer will not be required to provide any additional information at this time.</p>",
                        LinkText = "Next Step",
                        Style = "blockButton-info",
                        UserInput = "Option 2",
                        Action = ""
                    }
                }
            };

            mockQuestions.Add(question3);

            var question4 = new SurveyQuestionViewModel
            {
                Id = 999,
                Title = "You have indicated that your enrolled dependent, USERSPOUSE, is not eligible.  Is this correct?",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "999 question in flow.",
                Type = "BooleanChoice",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 991,
                        NextId = 1,
                        Title = "",
                        Description = "",
                        LinkText = "No",
                        Style = "blockButton-info",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 992,
                        NextId = 9991,
                        Title = "",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",
                        Action = ""
                    }
                }
            };

            mockQuestions.Add(question4);

            var question5 = new SurveyQuestionViewModel
            {
                Id = 9991,
                Title = "We have received your confirmation that the USERSPOUSE is not an eligible dependent.  We will update your records and your dependent will no longer be eligible for benefit coverage.  You will receive a confirmation email regarding your selection.",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "9991 question in flow.",
                Type = "BooleanChoice",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 991,
                        NextId = 0,
                        Title = "",
                        Description = "",
                        LinkText = "Start Over",
                        Style = "blockButton-info",
                        UserInput = "Confirmed Ineliglibe",
                        Action = "StartOver"
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 992,
                        NextId = 0,
                        Title = "",
                        Description = "",
                        LinkText = "Finish Survey",
                        Style = "blockButton-info",
                        Action = "SurveyComplete"
                    }
                }
            };

            mockQuestions.Add(question5);

            var question6 = new SurveyQuestionViewModel
            {
                Id = 5,
                Title = "You have selected Option 1 where you have determined the Surcharge Applies to you. Is this correct?",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "9991 question in flow.",
                Type = "BooleanChoice",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 991,
                        NextId = 3,
                        Title = "",
                        Description = "",
                        LinkText = "No",
                        Style = "blockButton-info",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 992,
                        NextId = 7,
                        Title = "",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",                        
                        Action = ""
                    }
                }
            };

            mockQuestions.Add(question6);

            var question7 = new SurveyQuestionViewModel
            {
                Id = 7,
                Title = "You have verified your DEPENDENTTYPE is Employed and they meet the conditions and requirements to have a surcharge withheld from your wages and salary.  To complete your declaration, please check each term and condition.",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "7 question in flow.",
                Type = "ConfirmMultiple",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 71,
                        NextId = 0,
                        Title = "If my [Spouse or Domestic Partner] becomes employed, I understand that I am required to log into www.ivb-ocv.com to update my [Spouse or Domestic Partner] working status within 30 days of them obtaining employment.",
                        Description = "",
                        LinkText = "",
                        Style = "blockButton-info",
                        UserInput = "",
                        UserResponse = false,
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 72,
                        NextId = 0,
                        Title = "I hereby certify and warrant to ABC Company that all information I have provided is true, correct and current as of this date.",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",
                        UserInput = "",
                        UserResponse = false,
                        Action = ""
                    }
                    ,
                    new SurveyAnswerViewModel
                    {
                        Id = 73,
                        NextId = 0,
                        Title = "I also understand my employer and ConSova may use other employment verification methods to verify my representations I have made regarding my enrolled dependent spouse/domestic partner.  I further understand if I submit false or erroneous information I may be subject to wage and salary withholdings equivalent to the additional contribution amounts that otherwise would have been collected.",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",
                        UserInput = "",
                        UserResponse = false,
                        Action = ""
                    }
                    ,
                    new SurveyAnswerViewModel
                    {
                        Id = 74,
                        NextId = 0,
                        Title = "I authorize ABC Company and ConSova Corporation to verify any and all information provided by me or my spouse/domestic partner and may contact any institution or organization to verify the facts provided herein as long as my spouse or domestic partner is enrolled in ABC Company's healthcare plans.",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",
                        UserInput = "",
                        UserResponse = false,
                        Action = ""
                    }
                }
            };

            mockQuestions.Add(question7);

            var question8 = new SurveyQuestionViewModel
            {
                Id = 6,
                Title = "Thank You!  You have indicated your spouse or domestic partner is eligible, employed and requires our assistance to verify their benefits eligibility.  We will need to gather more information from you, your spouse or domestic partner and their employer.  Before we begin we would like to know your preferred method of contact and provide more helpful information.  To get started click Next.",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "7 question in flow.",
                Type = "BooleanChoice",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 991,
                        NextId = 3,
                        Title = "",
                        Description = "",
                        LinkText = "Pay Surcharge",
                        Style = "blockButton-info",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 992,
                        NextId = 0,
                        Title = "",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",
                        UserInput = "Begin Full Verification",
                        Action = "SurveyComplete"
                    }
                }
            };

            mockQuestions.Add(question8);

            var question9 = new SurveyQuestionViewModel
            {
                Id = 4,
                Title = "You have indicated the following status of your DEPENDENTTYPE : [WORK STATUS] Is this correct?",
                HelpText = "Instructions for the EE to best answer this question will go here.",
                Description = "7 question in flow.",
                Type = "BooleanChoice",
                Answers = new List<SurveyAnswerViewModel>
                {
                    new SurveyAnswerViewModel
                    {
                        Id = 991,
                        NextId = 2,
                        Title = "",
                        Description = "",
                        LinkText = "No",
                        Style = "blockButton-info",
                        Action = ""
                    },
                    new SurveyAnswerViewModel
                    {
                        Id = 992,
                        NextId = 0,
                        Title = "",
                        Description = "",
                        LinkText = "Yes",
                        Style = "blockButton-info",
                        UserInput = "Begin Full Verification",
                        Action = "SurveyComplete"
                    }
                }
            };

            mockQuestions.Add(question9);

            return mockQuestions;
        }


        public void Post([FromBody] Question question)
        {
            try
            {
                _questionService.Post(question);
            }
            catch (Exception ex)
            {
                _logger.Error("Error creating question: {0}", ex.Message);
            }
        }

        public IHttpActionResult Put([FromBody] Question question)
        {
            try
            {
                var putValue = _questionService.Put(question);
                return Ok(putValue);

            }
            catch (Exception ex)
            {
                _logger.Error("Error updating question: {0}", ex.Message);
                return BadRequest();
            }
        }

        public void Delete(int id)
        {
            try
            {
                _questionService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.Error("Error deleting question: {0}", ex.Message);
            }
        }

        public void Delete([FromBody] Question question)
        {
            try
            {
                _questionService.Delete(question);
            }
            catch (Exception ex)
            {
                _logger.Error("Error deleting question: {0}", ex.Message);
            }
        }
    }
}