namespace library_backend.models;

public class BookRedis
{
    public Guid key { get; private set; }
    public string name { get; set; }
    public string author { get; set; }

    public BookRedis()
    {
        key = Guid.NewGuid();
    }
    
}