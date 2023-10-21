using AnotherWebApi.Domain;
using AnotherWebApi.Repositories;

namespace AnotherWebApi.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneService(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }
        public Phone Get(int id)
        {
            return _phoneRepository.Get(id);
        }
    }
}
