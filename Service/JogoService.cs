using Lojinha3API.Context;
using Lojinha3API.Models;
using Lojinha3API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lojinha3API.Service
{
    public interface IJogoService
    {
        public IEnumerable<JogoDto> FindAll();
        public IEnumerable<JogoDto> FindById(int IdJogo);
        public bool Insert(Jogo jogo);
        public bool Update(int id,Jogo jogo);
        public bool Delete(int IdJogo);
        public Jogo Exists(int Id);
    }
    public class JogoService : IJogoService
    {
        private readonly LojinhaContext _lojinhaContext;

        public JogoService(LojinhaContext lojinhaContext)
        {
            _lojinhaContext = lojinhaContext;
        }

        public bool Delete(int IdJogo)
        {
            var jogoRetornadovalido = Exists(IdJogo);
            if(jogoRetornadovalido != null)
            {
                _lojinhaContext.Jogos.Remove(jogoRetornadovalido);
                _lojinhaContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Jogo Exists(int Id)
        {
            var jogoRetornado = _lojinhaContext.Jogos.SingleOrDefault(p => p.Id == Id);
            if (jogoRetornado != null)
                return jogoRetornado;
            return null;
        }

        public IEnumerable<JogoDto> FindAll()
        {
            var produtosretornadosdto = from jogo in _lojinhaContext.Jogos
                                        join desenvolvedora in _lojinhaContext.Desenvolvedoras on jogo.DesenvolvedoraId equals desenvolvedora.Id
                                        join plataforma in _lojinhaContext.Plataformas on jogo.PlataformaId equals plataforma.Id

                                        select new JogoDto()
                                        {
                                            Id = jogo.Id,
                                            Titulo = jogo.Titulo,
                                            AnoLancamento = jogo.AnoLancamento,
                                            IdDesenvolvedora = jogo.DesenvolvedoraId,
                                            IdPlataforma = jogo.PlataformaId,
                                            Plataforma = plataforma,
                                            Desenvolvedora = desenvolvedora
                                        };
            return produtosretornadosdto;
        }

        public IEnumerable<JogoDto> FindById(int IdJogo)
        {
            var produtosretornadosdto = from jogo in _lojinhaContext.Jogos
                                        join desenvolvedora in _lojinhaContext.Desenvolvedoras on jogo.DesenvolvedoraId equals desenvolvedora.Id
                                        join plataforma in _lojinhaContext.Plataformas on jogo.PlataformaId equals plataforma.Id
                                        where jogo.Id == IdJogo
                                        select new JogoDto()
                                        {
                                            Id = jogo.Id,
                                            Titulo = jogo.Titulo,
                                            AnoLancamento = jogo.AnoLancamento,
                                            IdDesenvolvedora = jogo.DesenvolvedoraId,
                                            IdPlataforma = jogo.PlataformaId,
                                            Plataforma = plataforma,
                                            Desenvolvedora = desenvolvedora
                                        };
            return produtosretornadosdto;
        }

        public bool Insert(Jogo jogo)
        {
            try
            {
                _lojinhaContext.Add(jogo);
                _lojinhaContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public bool Update(int id,Jogo Novojogo)
        {
            int jogoId = Convert.ToInt32(Novojogo.Id);
            try
            {
                var jogoRetornadoValido = Exists(jogoId);
                if (jogoRetornadoValido != null)
                {
                    _lojinhaContext.Entry(jogoRetornadoValido).CurrentValues.SetValues(Novojogo);
                    _lojinhaContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
