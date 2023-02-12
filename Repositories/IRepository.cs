namespace todolist.Repositories;

public interface IRepository<T> 
{
    void Create(T entity);

    T? Get(Func<T, bool> func);

    IEnumerable<T> GetAll(int id);

    bool Exists(T? entity);

    void Delete(int id);

    void Update(T entity);
}