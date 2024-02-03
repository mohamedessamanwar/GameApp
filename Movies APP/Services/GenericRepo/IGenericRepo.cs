namespace Game_APP.Services.GenericRepo;

public interface IGenericRepo<T> where T : class
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
