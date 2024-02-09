namespace DemoCorso.Core.Interfaces;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }
}


