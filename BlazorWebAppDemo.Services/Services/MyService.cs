namespace BlazorWebAppDemo.Services.Services
{

    public class MyService : IMyService
    {
        public List<string> Names { get; set; } = new();

        public void AddName(string name)
        {
            Names.Add(name);
        }

        public MyService()
        {
            AddName("Neven");
            AddName("Maja");
            AddName("Netko");
        }
    }

    public interface IMyService
    {
        List<string> Names { get; set; }
        void AddName(string name);
    }
}
