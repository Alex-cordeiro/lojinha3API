using Business.Interfaces;
using Lojinha3.Data.Repository.Generic;
using Lojinha3.Domain.Model;
using System.Collections.Generic;

namespace Business.Implementations
{
    public class DesenvolvedoraBusinessImplementation : IDesenvolvedoraBusiness
    {
        private readonly IRepository<Desenvolvedora> _repository;

        public DesenvolvedoraBusinessImplementation(IRepository<Desenvolvedora> repository)
        {
            _repository = repository;
        }

        public Desenvolvedora Create(Desenvolvedora desenvolvedora)
        {
            return _repository.Create(desenvolvedora);
        }

        public bool Delete(int id)
        {
             if(_repository.Delete(id))
                return true;
             return false;
        }

        public List<Desenvolvedora> FindAll()
        {
            return _repository.FindAll();
        }

        public Desenvolvedora FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Desenvolvedora Update(Desenvolvedora desenvolvedora)
        {
            return _repository.Update(desenvolvedora);
        }
    }
}
