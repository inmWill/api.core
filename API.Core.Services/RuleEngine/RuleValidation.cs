using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using API.Core.Domain.Enums;

namespace API.Core.Service.RuleEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class RuleValidation
    {
        /// <summary>
        /// Dictionary that holds mapping between .NET Expression operator type and survey operator types.
        /// </summary>
        public Dictionary<OperatorType, ExpressionType> exprMap = new Dictionary<OperatorType, ExpressionType>();        

        /// <summary>
        /// 
        /// </summary>
        public RuleValidation()
        {
            exprMap.Add(OperatorType.EqualsTo, ExpressionType.Equal);
            exprMap.Add(OperatorType.NotEqualsTo, ExpressionType.NotEqual);
            exprMap.Add(OperatorType.GreaterThan, ExpressionType.GreaterThan);
            exprMap.Add(OperatorType.GreaterThanEqualsTo, ExpressionType.GreaterThanOrEqual);
            exprMap.Add(OperatorType.LessThan, ExpressionType.LessThan);
            exprMap.Add(OperatorType.LessThanEqualsTo, ExpressionType.LessThanOrEqual);
        }

        /// <summary>
        /// Return valid rules.
        /// </summary>
        /// <typeparam name="TTarget">TTarget is the source model</typeparam>
        /// <typeparam name="TValue">TValue is the destination model</typeparam>
        /// <typeparam name="TType"></typeparam>
        /// <param name="oType"></param>
        /// <param name="target"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsRuleValid<TTarget, TValue, TType>(OperatorType oType, TTarget target, TValue value)
        {


            
            if (oType == OperatorType.NoOperator)
                return true; 
            
            //if no matching operator found in the dictonary return false
            if (!exprMap.ContainsKey(oType))
                return false;
            
            //Build binary expression and compile
            ParameterExpression pLeft = Expression.Parameter(typeof(TTarget),  "target");            
            ParameterExpression pRight = Expression.Parameter(typeof(TValue), "value");

            object targetObj = new object();
            object valueObj = new object();

            PropertyInfo pLeftInfo = typeof(TTarget).GetProperty("ValidAnswer");
            PropertyInfo pRightInfo = typeof(TValue).GetProperty("Response");

            targetObj = pLeftInfo.GetValue(target);
            valueObj = pRightInfo.GetValue(value);

            targetObj = Convert.ChangeType(targetObj, typeof(TType));
            valueObj = Convert.ChangeType(valueObj, typeof(TType));

            //not using member expression. ran into type conversion issue at runtime.
            //Expression mLeft = Expression.Property(pLeft, pLeftInfo);
            //Expression mRight = Expression.Property(pRight, pRightInfo);

            ConstantExpression cLeft = Expression.Constant(targetObj, typeof(TType));
            ConstantExpression cRight = Expression.Constant(valueObj, typeof(TType));

            //Expression type maps enum values with expression type values using dictionary
            ExpressionType exprType = exprMap[oType];

            //build binary expression
            BinaryExpression binaryExpr = Expression.MakeBinary(exprType, cLeft, cRight);

            var f = Expression.Lambda<Func<TTarget, TValue, bool>>(binaryExpr, new ParameterExpression[] { pLeft, pRight });            
            var func = f.Compile();

            return func(target, value);
        }
    }
}

