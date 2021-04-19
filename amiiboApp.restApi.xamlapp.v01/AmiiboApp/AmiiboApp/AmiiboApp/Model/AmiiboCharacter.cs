

namespace AmiiboApp.Model
{


    public class AmiiboCharacter //Deberia ser Characters
    {
        //Se declara un arreglo de personajes
        public Character[] amiibo { get; set; }
    }

    public class Character
    {
        public string key { get; set; }
        public string name { get; set; }
    }

}
