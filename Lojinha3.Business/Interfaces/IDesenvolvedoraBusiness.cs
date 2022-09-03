using Lojinha3.Domain.Model;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IDesenvolvedoraBusiness
    {
        public Desenvolvedora Create(Desenvolvedora desenvolvedora);
        public Desenvolvedora FindByID(long id);
        List<Desenvolvedora> FindAll();
        Desenvolvedora Update(Desenvolvedora desenvolvedora);
        bool Delete(long id);
    }
}
