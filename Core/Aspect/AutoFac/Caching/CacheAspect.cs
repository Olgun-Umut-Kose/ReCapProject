using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy;
using Core.Cross_Cutting_Concerns.Caching;
using Core.Utilities.Interception.AutoFac;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.AutoFac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            
        }

        public override void Intercept(IInvocation invocation)
        {
            string methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            List<object> arguments = invocation.Arguments.ToList();
            string key = $"{methodName}({string.Join(",",arguments.Select(x=>x?.ToString()??"null"))})";
            if (_cacheManager.IsAdded(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key,invocation.ReturnValue,_duration);
        }
    }
}