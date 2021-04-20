namespace AppAmigos.v2.Services
{

    //La idea de esta interfaz es que cada una de las plataformas (iOS, Android,...) tenga la ruta de un archivo y que el archivo sea la db
    public interface IFileHelper
    {
        //Devuelve un String (ruta del archivo), con el metodo GetLocalFilePath que recibe como parametro el nombre del archivo.
        string GetLocalFilePath(string fileName);
    }
}
