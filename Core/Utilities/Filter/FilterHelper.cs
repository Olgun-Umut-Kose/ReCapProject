using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Utilities.Filter
{
    public class FilterHelper
    {
        public static Func<TDto, bool> DynamicFilter<TDto, TFilterDto>(TFilterDto filter)
        {
            Expression propertyExp, someValue, containsMethodExp, combinedExp;
            Expression<Func<TDto, bool>> exptemp = c => true , oldExp;
            Func<TDto, bool> exp = c => true ;
            
            MethodInfo method;

            var parameterExp = Expression.Parameter(typeof(TDto), "type");
            foreach (PropertyInfo propertyInfo in filter.GetType().GetProperties())
            {
                if (propertyInfo.GetValue(filter, null) != null)
                {
                    oldExp = exptemp;
                    propertyExp = Expression.Property(parameterExp, propertyInfo.Name);
                    method = typeof(object).GetMethod("Equals", new[] { typeof(object) });
                    someValue = Expression.Constant(filter.GetType().GetProperty(propertyInfo.Name).GetValue(filter, null), typeof(object));
                    containsMethodExp = Expression.Call(propertyExp, method, someValue);
                    exptemp = Expression.Lambda<Func<TDto, bool>>(containsMethodExp, parameterExp);
                    combinedExp = Expression.AndAlso(exptemp.Body, oldExp.Body);
                    exptemp = Expression.Lambda<Func<TDto, bool>>(combinedExp, exptemp.Parameters[0]);
                    exp = exptemp.Compile();

                }
            }
            return exp;
        }
    }
}