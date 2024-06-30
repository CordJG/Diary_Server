namespace Diary_Server.Interface
{
    public interface IBaseContextHandler<T> where T : class
    {
        List<T> GetAll();
        T GetById(long id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
