namespace Game_APP.Services.GenericRepo;
public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly Models.Data.AppContext  context;
    public GenericRepo(Models.Data.AppContext context) 
    {
        this.context = context;
    }
    public IEnumerable<T> GetAll()
    {
        return context.Set<T>().AsNoTracking();
    }
    public T? GetById(int id)
    {
       return context.Set<T>().Find(id);
    }
    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }
    public void Update(T entity)
    {
        
    }
    public void Delete(T entity)
    {
       context.Set<T>().Remove(entity);

    }
}
