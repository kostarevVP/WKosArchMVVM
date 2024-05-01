using System;

namespace WKosArch.DependencyInjection
{
    public interface IDIContainer : IDisposable
    {
        DIBuilder<T> Register<T>(Func<DIContainer, T> factory);
        DIBuilder<T> Register<T>(string tag, Func<DIContainer, T> factory);
        DIBuilder<T> RegisterSingleton<T>(Func<DIContainer, T> factory);
        DIBuilder<T> RegisterSingleton<T>(string tag, Func<DIContainer, T> factory);
        T Resolve<T>(string tag = "");
    }
}