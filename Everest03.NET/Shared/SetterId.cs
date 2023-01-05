namespace Everest03.NET.Shared
{
    public class SetId : ISetId
    {
        public long Id { get; private set; }
        public void handle(long id)
        {
            Id = id;
        }
    }
}
