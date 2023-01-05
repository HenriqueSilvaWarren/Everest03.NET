namespace Everest03.NET.Shared
{
    public class SetterId : ISetterId
    {
        public long Id { get; private set; }
        public void handle(long id)
        {
            Id = id;
        }
    }
}
