using System.Diagnostics;
using Castle.DynamicProxy;
using Core.Utilities.Interception.AutoFac;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspect.AutoFac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private float _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(float interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnSuccess(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.Write(invocation.Method.ReflectedType.FullName+"." + invocation.Method.Name + " istenilen süreden uzun sürdü tamamlanma süresi -->" + _stopwatch.Elapsed.TotalSeconds);
            }
            
            _stopwatch.Reset();
        }
    }
}