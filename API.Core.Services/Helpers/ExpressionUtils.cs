using System.Linq.Expressions;
using API.Core.Domain.Enums;

namespace API.Core.Service.Helpers
{
    public class ExpressionUtils
    {
        /// <summary>
        /// Returns .NET Expression type based on Operator Type
        /// </summary>
        /// <param name="opType"></param>
        /// <returns></returns>
        public static ExpressionType GetExpressionType(OperatorType opType)
        {
            ExpressionType exprType;
            
            switch ((OperatorType) opType )
            {
                case OperatorType.EqualsTo :  exprType = ExpressionType.Equal;
                    break;
                case OperatorType.NotEqualsTo: exprType = ExpressionType.NotEqual;
                    break;
                case OperatorType.GreaterThan: exprType = ExpressionType.GreaterThan;
                    break;
                case OperatorType.GreaterThanEqualsTo: exprType = ExpressionType.GreaterThanOrEqual;
                    break;
                case OperatorType.LessThan: exprType = ExpressionType.LessThan;
                    break;
                case OperatorType.LessThanEqualsTo: exprType = ExpressionType.LessThanOrEqual;
                    break;
                default: exprType = ExpressionType.IsFalse;
                    break;
            }

            return exprType;
            
        }
    }
}
