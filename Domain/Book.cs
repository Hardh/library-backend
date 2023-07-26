namespace library_backend.Domain;

public class Book
{
    
    public Guid key { get; private set; }
    public string name { get; set; }
    public string author { get; set; }

    public Book()
    {
        key = Guid.NewGuid();
    }
    
}