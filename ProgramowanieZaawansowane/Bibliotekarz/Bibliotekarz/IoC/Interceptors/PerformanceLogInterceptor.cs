using Castle.DynamicProxy;
using System;
using System.Diagnostics;

namespace Bibliotekarz.IoC.Interceptors
{
    public class PerformanceLogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            //Wywołanie metody interceptowanej.
            invocation.Proceed();

            stopwatch.Stop();
            Console.WriteLine($"{invocation.TargetType.GetType().Name}.{invocation.Method.Name} wykonała się w czasie: {stopwatch.Elapsed}.");
        }
    }
}
