using System;
using System.Collections.Generic;
using System.Linq;
using FleetManager.Domain;

// this is inspired by CreoCraft.Infrastructure.InMemoryRepository
// from C:\Code\NetCoreWebApi20210218
namespace FleetManager.Infrastructure
{
    // XXX
    // leave off the interface compliance for now
    // : IRepository<TKey, TEntity> where TEntity : class, IEntity<TKey>
    public class InMemoryRepository
    {
        // the variable that will hold the actual repo/database
        // lets make it private to the class
        private readonly IDictionary<Guid, VehicleModel> _memory = new Dictionary<Guid, VehicleModel>();

        // TODO
        // add a ctor here that allows a list of VehicleModels to be added
        // this is to "seed" the repository
        public InMemoryRepository(List<VehicleModel> vehicleList)
        {
            _memory = vehicleList.ToDictionary(x => x.Id, x => x);
        }

        // need a way to get all items from the repo (and loopable)
        public IEnumerable<VehicleModel> Get()
        {
            return _memory.Values.ToArray();
        }

        // need a way to get a single item
        public VehicleModel Get(Guid id)
        {
            return _memory[id];
        }

        public List<VehicleModel> GetAll()
        {
            return _memory.Values.ToList();
        }

        // need a way to add an item to the repo
        // this was my way, but it makes more sense to include the id/key in the entity and then just use it
        //public void Add(TKey id, TEntity value)
        public void Add(VehicleModel item)
        {
            _memory.Add(item.Id, item);
        }

        // need a way to delete an item from the repo
        public bool Delete(Guid id)
        {
            return _memory.Remove(id);
        }
    }

    // we will use this later
    public interface IRepository<T, T1>
    {
    }
}
