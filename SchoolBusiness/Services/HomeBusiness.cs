using SchoolBusiness.Interfaces;
using SchoolRepository.Inte3rfaces;
using System;

namespace SchoolBusiness.Services
{
    public class HomeBusiness : IHomeBusiness
    {
        private readonly IHomeRepository _repository;

        public HomeBusiness(IHomeRepository repository) => _repository = repository;

        public void MetodoTeste()
        {
            _repository.Teste();
        }
    }
}
