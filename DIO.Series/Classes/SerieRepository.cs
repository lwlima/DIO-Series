using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> _listSerie = new List<Serie>();

        public void Add(Serie entity)
        {
            _listSerie.Add(entity);
        }

        public void Delete(int id)
        {
            _listSerie[id].Delete();
        }

        public Serie GetById(int id)
        {
            return _listSerie[id];
        }

        public List<Serie> List()
        {
            return _listSerie;
        }

        public int nextId()
        {
            return _listSerie.Count;
        }

        public void Update(int id, Serie entity)
        {
            _listSerie[id] = entity;
        }
    }
}
