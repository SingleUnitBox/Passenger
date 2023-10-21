using AnotherWebApi.Domain;

namespace AnotherWebApi.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private static ISet<Phone> _phones = new HashSet<Phone>
        {
            new Phone { Id = 1, Name = "nokia", Number = "111" },
            new Phone { Id = 2, Name = "samsung", Number = "222" },
            new Phone { Id = 3, Name = "xiaomi", Number = "333" },
        };
        public Phone Get(int id)
        {
            return _phones.FirstOrDefault(p => p.Id == id);
        }
    }
}
