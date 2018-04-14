using Dapper;
using Ether.Data.Interfaces;
using Ether.Data.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Ether.Data.Dapper.SQLite.Repository
{
    internal class TvShowRepository : ITvShowRepository
    {
        private readonly string connectionString;

        public TvShowRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create(TvShow entity)
        {
            Helpers.ThrowIfEntityNull(entity);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    INSERT INTO tvshows (Name, Season, Episode, Completed, Deleted, CreatedOn, ModifiedOn)
                    VALUES (@Name, @Season, @Episode, @Completed, @Deleted, @CreatedOn, @ModifiedOn);
                    SELECT last_insert_rowid();";

                return dbConn.QueryFirst<int>(query, entity);
            }
        }

        public bool Delete(int id)
        {
            Helpers.ThrowIfIntZero(id);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = "DELETE FROM tvshows WHERE Id = @Id;";

                var result = dbConn.Execute(query, new { Id = id });

                return result > 0;
            }
        }

        public IEnumerable<TvShow> GetAll()
        {
            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    SELECT Id, Name, Season, Episode, Completed, Deleted, CreatedOn, ModifiedOn
                    FROM tvshows;";

                return dbConn.Query<TvShow>(query);
            }
        }

        public TvShow GetById(int id)
        {
            Helpers.ThrowIfIntZero(id);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    SELECT Id, Name, Season, Episode, Completed, Deleted, CreatedOn, ModifiedOn
                    FROM tvshows
                    WHERE Id = @Id;";

                return dbConn.QueryFirstOrDefault<TvShow>(query, new { Id = id });
            }
        }

        public bool Update(TvShow entity)
        {
            Helpers.ThrowIfEntityNull(entity);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    UPDATE tvshows SET
                        Name = @Name,
                        Season = @Season,
                        Episode = @Episode,
                        Completed = @Completed,
                        Deleted = @Deleted,
                        CreatedOn = @CreatedOn,
                        ModifiedOn = @ModifiedOn,
                    WHERE Id = @Id;";

                var result = dbConn.Execute(query, entity);

                return result > 0;
            }
        }
    }
}