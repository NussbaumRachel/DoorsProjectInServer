using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class CheckService
        : ICheck
    {
        DbManager db;
        readonly ILogger<CheckService>? _logger;
        //readonly SemaphoreSlim _mutex = new(1, 1);

        public CheckService(DbManager db, ILogger<CheckService>? logger = null)
        {
            this.db = db;
            this._logger = logger;
        }

        public void Create(Check item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (string.IsNullOrWhiteSpace(item.Value)) throw new ArgumentException("Value cannot be null or whitespace.", nameof(item.Value));

            item.Value = item.Value.Trim();
            db.Checks.Add(item);

            try
            {
                //_mutex.Wait();
                db.SaveChanges();
            }
            catch (DbUpdateException dbEx) // EF Core specific
            {
                _logger?.LogError(dbEx, "Failed to save Check {@Check}", item);
                throw new InvalidOperationException("Failed to save the check to the database. See inner exception for details.", dbEx);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Unexpected error while saving Check {@Check}", item);
                throw;
            }
            //finally
            //{
            //    _mutex.Release();
            //}
        }
       


        public bool Delete(int id)
        {
            var ch = db.Checks.Find(id);
            if (ch == null) throw new ArgumentNullException(nameof(id), "לא נמצא הצ'ק המתאים");
            db.Checks.Remove(ch);
            db.SaveChanges();
            return true;
        }

        public bool Delete(Check item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var ch = db.Checks.Find(item.Id);
            if (ch == null) throw new ArgumentNullException(nameof(item), "לא נמצא הצ'ק המתאים");
            db.Checks.Remove(ch);
            db.SaveChanges();
            return true;
        }

        public void DeleteAll(List<Check> l)
        {
            if (l == null) return;
            foreach (var c in l)
                Delete(c);
        }

        public async Task<Check> Get(int id)
        {
            var list = await GetAll();
            var ch = list.Find(c => c.Id == id);
            if (ch == null) throw new KeyNotFoundException("Check not found.");
            return ch;
        }

        public async Task<List<Check>> GetAll()
        {
            return await db.Checks.ToListAsync();
        }

        public void Update(Check item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var existing = db.Checks.Find(item.Id);
            if (existing == null) throw new KeyNotFoundException("Check not found for update.");

            // example shallow copy of updatable properties
            existing.Key = item.Key;
            existing.Value = string.IsNullOrWhiteSpace(item.Value) ? existing.Value : item.Value.Trim();

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException dbEx)
            {
                _logger?.LogError(dbEx, "Failed to update Check {@Check}", item);
                throw new InvalidOperationException("Failed to update the check. See inner exception.", dbEx);
            }
        }
    }
}
  
