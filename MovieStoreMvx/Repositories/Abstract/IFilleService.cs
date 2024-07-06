namespace MovieStoreMvx.Repositories.Abstract
{
    public interface IFilleService
    {
        public Tuple<int, string> SaveImage(IFormFile imageFile);
        public bool DeleteImage(string imageFileName);
    }
}
