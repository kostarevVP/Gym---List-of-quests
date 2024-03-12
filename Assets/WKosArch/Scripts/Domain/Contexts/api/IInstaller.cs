using Assets.LocalPackages.WKosArch.Scripts.Common.DIContainer;

namespace Assets.LocalPackages.WKosArch.Scripts.Domain.Contexts.api
{
    public interface IInstaller
    {
        void InstallBindings(IDIContainer localContainer);
    }
}
