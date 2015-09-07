using API.Core.Domain.Enums;

namespace API.Core.Service.Helpers
{
    public class UnitType
    {
        public static string GetUnitType(UnitOfMeasure unit)
        {
            string typeName = string.Empty;

            switch ((UnitOfMeasure) unit)
            {
                case UnitOfMeasure.Text: typeName = "System.String";
                    break;
                case UnitOfMeasure.Currency: typeName = "System.Int64";
                    break;
                case UnitOfMeasure.Date: typeName = "System.DateTime";
                    break;
                case UnitOfMeasure.Boolean: typeName = "System.String";
                    break;
            }

            return typeName;
        }
    }
}
