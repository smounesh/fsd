using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository : IRepository<int, RequestSolution>, IRequestSolutionRepository
    {
        private readonly RequestTrackerContext _context;

        public RequestSolutionRepository(RequestTrackerContext context)
        {
            _context = context;
        }

        public async Task<RequestSolution> Add(RequestSolution entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<RequestSolution> Delete(int key)
        {
            var solution = await Get(key);
            if (solution != null)
            {
                _context.RequestSolutions.Remove(solution);
                await _context.SaveChangesAsync();
            }
            return solution;
        }

        public async Task<RequestSolution> Get(int key)
        {
            return await _context.RequestSolutions.FindAsync(key);
        }

        public async Task<IList<RequestSolution>> GetAll()
        {
            return await _context.RequestSolutions.ToListAsync();
        }

        public async Task<IList<RequestSolution>> GetSolutionsForRequest(int requestId)
        {
            return await _context.RequestSolutions.Where(rs => rs.RequestId == requestId).ToListAsync();
        }

        public async Task<IList<RequestSolution>> GetSolutionsByEmployee(int employeeId)
        {
            return await _context.RequestSolutions.Where(rs => rs.SolvedBy == employeeId).ToListAsync();
        }

        public async Task<RequestSolution> Update(RequestSolution entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}