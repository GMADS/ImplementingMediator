using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsingMediator.Application.Models;
using UsingMediator.Interfaces;

namespace UsingMediator.Repositories
{
    public class PeopleRepository : IRepository<People>
    {
        private static Dictionary<int, People> _people = new Dictionary<int, People>();

        public async Task Add(People people)
        {
            people.Id = _people.Values.Count + 1;
            await Task.Run(() => PeopleRepository._people.Add(people.Id, people));
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => _people.Remove(id));
        }

        public async Task Edit(People people)
        {
            await Task.Run(() => PeopleRepository._people.Remove(people.Id));
            await Task.Run(() => PeopleRepository._people.Add(people.Id, people));
        }

        public async Task<People> Get(int id)
        {
            return await Task.Run(() => _people.GetValueOrDefault(id));
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            return await Task.Run(() => _people.Values.ToList());
        }
    }
}
