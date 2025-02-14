﻿using ErrorAPI.Data;
using ErrorAPI.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorAPI.Repositories
{
    public class ErrorRepository : IErrorRepository
    {
        private readonly AppDbContext _context;

        public ErrorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ErrorDto>> GetErrorsByCodeAsync(string errorCode)
        {
            return await _context.Errors
                .Where(e => e.ErrorCode == errorCode)
                .ToListAsync();
        }

        public async Task<List<ErrorDto>> GetErrorsByDescriptionAsync(string description)
        {
            return await _context.Errors
                .Where(e => e.Description.Contains(description))
                .ToListAsync();
        }
        public async Task<IEnumerable<ErrorDto>> GetErrorsByCategoryAsync(string category) 
        {
            return await _context.Errors.Where(e => e.Category == category).ToListAsync();
        }
        public async Task<IEnumerable<ErrorDto>> GetErrorsAsync(string code = null, string description = null)
        {
            var query = _context.Errors.AsQueryable();
            if (!string.IsNullOrEmpty(code))
            {
                query = query.Where(e => e.ErrorCode.Contains(code));
            }
            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(e => e.Description.Contains(description));
            }
            return await query.ToListAsync();
        }
        public async Task<ErrorDto> GetErrorByIdAsync(int id)
        {
            return await _context.Errors.FindAsync(id);
        }

        public async Task AddErrorAsync(ErrorDto error)
        {
            _context.Errors.Add(error);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UpdateErrorAsync(ErrorDto error)
        {
            _context.Entry(error).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(error.Id))
                {
                    return false;
                }
                throw;
            }
        }
        public async Task<bool> DeleteErrorAsync(int id)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error == null)
            {
                return false;
            }

            _context.Errors.Remove(error);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<ErrorDto>> GetAllErrorsAsync() 
        {
            return await _context.Errors.ToListAsync();
        }
        private bool ErrorExists(int id)
        {
            return _context.Errors.Any(e => e.Id == id);
        }

        
    }
}
