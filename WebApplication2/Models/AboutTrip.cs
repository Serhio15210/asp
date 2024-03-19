using System.Collections;

namespace WebApplication2.Models;

public class AboutTrip : IEnumerable
{
    public string Name { get; set; }
    public string Text { get; set; }
    public string Image { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}