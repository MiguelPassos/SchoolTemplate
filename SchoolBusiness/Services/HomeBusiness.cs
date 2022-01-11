using SchoolBusiness.Interfaces;
using SchoolEntities;
using SchoolEntities.Enumerators;
using SchoolRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolBusiness.Services
{
    public class HomeBusiness : IHomeBusiness
    {
        private readonly IHomeRepository _repository;

        public HomeBusiness(IHomeRepository repository) => _repository = repository;
    }
}