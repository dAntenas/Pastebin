using Pastebin.Core.Interfaces.Entity;

namespace Pastebin.Core.Interfaces.Repository
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        public IReadOnlyCollection<T> Get();

        public Task<IReadOnlyCollection<T>> GetAsync(CancellationToken cancel = default);

        public T GetById(Guid id);

        public Task<T> GetByIdAsync(Guid id, CancellationToken cancel = default);

        public void Add(T item);

        public Task AddAsync(T item, CancellationToken cancel = default);

        public void Update(T item);

        public Task UpdateAsync(T item, CancellationToken cancel = default);

        public void Remove(Guid id);

        public Task RemoveAsync(Guid id, CancellationToken cancel = default);
    }
}
