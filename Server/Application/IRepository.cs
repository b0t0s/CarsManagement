namespace CarsManagement.Server.Application;

public interface IRepository<T>
{
    T GetItem(int id);
    List<T> GetItems();
    void Add(T item);
    void Update(T item);
    public void AddOrUpdate(T item);
    void Delete(int id);
}