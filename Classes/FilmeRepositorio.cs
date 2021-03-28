using System;
using System.Collections.Generic;
using Localiza_labs_2.Intefaces;

namespace Localiza_labs_2
{
    public class FilmeeRepositorio : IRepositorio<Filme>
    {
        private List<Filme> listaSerie = new List<Filme>();
        public void Atualiza(int id, Filme objeto)
        {
           listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
            //implemento envio de e-mail
        }

        public void Insere(Filme objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Filme> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Filme RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}