namespace API.Core.Domain.Enums
{
    public enum ApplicationTypes
    {
        JavaScript = 0,
        NativeConfidential = 1
    };

    public enum UserType
    {
        Standard = 1,
        Presenter = 2,
        Organizer = 3,
        Client = 4,
        Staff = 5,
        Reviewer = 6,
        Admin = 7,
        Banned = 8
    }

    public enum AuditStatus
    {
        Complete = 1,
        Ineligible = 2,
        Dropped = 3, 
        NonResponder = 4
    }

    public enum SurveyType
    {
        Ocv = 1,
        Dev = 2,
        Simple = 3,
        Complex = 4
    }

    public enum QuestionType
    {
        Conditional = 1,
        Informational = 2
    }

    public enum UnitOfMeasure
    {
        Date = 1,
        Currency = 2,
        Text = 3,
        Boolean = 4
    }

    public enum InputOptionType
    {
        Text = 1,
        Radio = 2,
        MultiLine = 3
    }

    public enum OperatorType
    {
        EqualsTo = 1,
        NotEqualsTo = 2,
        GreaterThan = 3,
        LessThan = 4,
        GreaterThanEqualsTo = 5,
        LessThanEqualsTo = 6,
        NoOperator = 7
    }

    public enum SurchargeResultType
    {
        Surcharge = 1,
        NoSurcharge = 2,
        Incomplete = 3,
        Eligible = 4,
        Ineligible = 5
    }

    public enum State
    {
        Added,
        Unchanged,
        Deleted,
        Modified
    }

    public enum NotificationType
    {
        Email,
        SMS,
        Voice

    }

    public enum NotificationStatus
    {
        Sent,
        Received,
        Rejected,
        Error
    }

    public enum RuleType
    {
        Simple = 1,
        Complex = 2
    }
}
