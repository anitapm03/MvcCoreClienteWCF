namespace MvcCoreClienteWCF.Helpers
{
    public enum Folders { Images = 0, Documents = 1 }

    public class HelperPathProvider
    {
        IWebHostEnvironment environment;

        public HelperPathProvider(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public string MapPath(string fileName, Folders folders)
        {
            string carpeta = "";
            if (folders == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folders == Folders.Documents)
            {
                carpeta = "documents";
            }
            string path = Path.Combine(this.environment.WebRootPath,
                 carpeta, fileName);
            return path;
        }
    }
}
