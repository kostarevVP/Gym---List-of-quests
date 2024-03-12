using Cysharp.Threading.Tasks;

namespace WKosArch.Data
{
    public interface IRepository
    {
        UniTask Save();
        UniTask Load();
    }
}