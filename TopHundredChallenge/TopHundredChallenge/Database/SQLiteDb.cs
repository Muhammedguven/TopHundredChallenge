using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TopHundredChallenge.Models;
using Xamarin.Essentials;

namespace TopHundredChallenge.Database
{
    public class SQLiteDb
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "WatchedMovies.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<SpecificMovie>();
        }
        public static async Task<List<SpecificMovie>> GetMoviesAsync()
        {
            await Init();
            var watchedMovies = await db.Table<SpecificMovie>().ToListAsync();
            return watchedMovies;
        }
        public static async Task<int> SaveMovieAsync(SpecificMovie movie)
        {
            await Init();
            return await db.InsertAsync(movie);
        }
        public static async Task<int> DeleteMovieAsync(SpecificMovie movie)
        {
            await Init();
            return await db.DeleteAsync(movie);
        }
        public static async Task<int> DeleteCustomerAsync(SpecificMovie movie)
        {
            await Init();

            var result = await db.DeleteAsync(movie);
            await GetMoviesAsync();
            return result;
        }
    }
}
