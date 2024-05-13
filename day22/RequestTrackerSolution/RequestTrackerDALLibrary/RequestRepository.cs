using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class RequestRepository : IRepository<int, Request>, IRequestRepository
    {
        private readonly RequestTrackerContext _context;

        public RequestRepository()
        {
        }

        public RequestRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<Request> Add(Request entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Request> Delete(int key)
        {
            var request = await Get(key);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return request;
        }

        public async Task<Request> Get(int key)
        {
            return await _context.Requests.FindAsync(key);
        }

        public async Task<IList<Request>> GetAll()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<IList<Request>> GetAllRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        public Task<IList<Request>> GetRequestsByEmployee(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Request>> GetRequestsByUser(int userId)
        {
            return await _context.Requests.Where(r => r.RequestRaisedBy == userId).ToListAsync();
        }

        public async Task<Request> Update(Request entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
