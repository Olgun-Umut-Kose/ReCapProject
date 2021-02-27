using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.Cross_Cutting_Concerns.Validation;
using Core.Utilities.Interception.AutoFac;
using FluentValidation;

namespace Core.Aspect.AutoFac
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Geçersiz Validator Tipi");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            IValidator validator = (IValidator) Activator.CreateInstance(_validatorType);
            Type entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            // ReSharper disable once HeapView.ObjectAllocation
            var entities = invocation?.Arguments?.Where(x => x.GetType() == entityType);
            foreach (object entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
            
        }
    }
}