using Dapper;
using Ether.Data.Interfaces;
using Ether.Data.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Ether.Data.Dapper.SQLite.Repository
{
    internal class AnimeRepository : IAnimeRepository
    {
        private readonly string connectionString;

        public AnimeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create(Anime entity)
        {
            Helpers.ThrowIfEntityNull(entity);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    INSERT INTO anime (Name,  Episode, Completed, Deleted, CreatedOn, ModifiedOn)
                    VALUES (@Name, @Episode, @Completed, @Deleted, @CreatedOn, @ModifiedOn);
                    SELECT last_insert_rowid();";

                return dbConn.QueryFirst<int>(query, entity);
            }
        }

        public bool Delete(int id)
        {
            Helpers.ThrowIfIntZero(id);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = "DELETE FROM anime WHERE Id = @Id;";

                var result = dbConn.Execute(query, new { Id = id });

                return result > 0;
            }
        }

        public IEnumerable<Anime> GetAll()
        {
            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    SELECT Id, Name, Episode, Completed, Deleted, CreatedOn, ModifiedOn
                    FROM anime;";

                return dbConn.Query<Anime>(query);
            }
        }

        public Anime GetById(int id)
        {
            Helpers.ThrowIfIntZero(id);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    SELECT Id, Name, Episode, Completed, Deleted, CreatedOn, ModifiedOn
                    FROM anime
                    WHERE Id = @Id;";

                return dbConn.QueryFirstOrDefault<Anime>(query, new { Id = id });
            }
        }

        public bool Update(Anime entity)
        {
            Helpers.ThrowIfEntityNull(entity);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    UPDATE tvshows SET
                        Name = @Name,
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