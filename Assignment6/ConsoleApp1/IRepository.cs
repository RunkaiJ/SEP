

namespace ConsoleApp1
{
    public class Entity
    {
        public int Id { get; set; }
    }
    public interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }

    public class GenericRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly List<T> _dataSource;

        public GenericRepository()
        {
            _dataSource = new List<T>();
        }

        public void Add(T item)

        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _dataSource.Add(item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dataSource;
        }

        public T GetById(int id)
        {
            foreach (T element in _dataSource)
            {
                if (element.Id == id)
                {
                    return element;
                }
            }
            return default;
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            _dataSource.Remove(item);
        }

        public void Save()
        {
            Console.WriteLine("Content Saved.");
        }
    }
}
