using AnotherWebApi.Domain;

namespace AnotherWebApi.Repositories
{
    public interface IPhoneRepository
    {
        Phone Get(int id);
    }
}
