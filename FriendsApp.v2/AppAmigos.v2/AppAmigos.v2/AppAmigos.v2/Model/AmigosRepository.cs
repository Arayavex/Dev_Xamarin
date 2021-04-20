using AppAmigos.v2.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AppAmigos.v2.Model
{
    public class AmigosRepository
    {

        public IList<Amigos> Amigos { get; set; }

        //Constructor para que use informacion de la db
        public AmigosRepository()
        {
            //Se le asigna a la propieda 'Amigos' para que devuelva la lista de amigos
            Task.Run(async () =>
                      Amigos = await App.Database.GetItemsAsync()).Wait();
        }

        public IList<Amigos> GetAll()
        {
            return Amigos;
        }

        public IList<Amigos> GetAllByFirstLetter(string letter)
        {
            var query = from q in Amigos
                        where q.Nombre.StartsWith(letter)
                        select q;

            return query.ToList();
        }

        public ObservableCollection<Grouping<string, Amigos>> GetrAllGrouped()
        {

            IEnumerable<Grouping<string, Amigos>> sorted = new Grouping<string, Amigos>[0];

            if (Amigos != null)
            {
                sorted =
                    from f in Amigos
                    orderby f.Nombre
                    group f by f.Nombre[0].ToString()
                    into theGroup
                    select
                    new Grouping<string, Amigos>
                        (theGroup.Key, theGroup);
            }

            return new ObservableCollection<Grouping<string, Amigos>>(sorted);
        }

    }
}
