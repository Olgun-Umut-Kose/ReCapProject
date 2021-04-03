using System;
using Castle.DynamicProxy;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Interception.AutoFac
{
    public  class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation){}
        protected virtual void OnAfter(IInvocation invocation){}

        protected virtual void OnException(IInvocation invocation, Exception e)
        {
            //invocation.ReturnValue = new ErrorResult("Bir sorun ile karşılaşıldı: " + e.Message + "inner: " + e.InnerException.Message);
        }
        protected virtual void OnSuccess(IInvocation invocation){}
        
        
        public override void Intercept(IInvocation invocation)
        {
            bool isSuccess = true;

            try
            {
                OnBefore(invocation);
                invocation.Proceed();
                OnAfter(invocation);
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
        }
    }
}