﻿using Lojinha3.Domain.Model.Games;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IDesenvolvedoraBusiness
    {
        public Desenvolvedora Create(Desenvolvedora desenvolvedora);
        public Desenvolvedora FindByID(long id);
        List<Desenvolvedora> FindAll();
        Desenvolvedora Update(Desenvolvedora desenvolvedora);
        bool Delete(int id);
    }
}
