using Dapper;
using Ether.Data.Interfaces;
using Ether.Data.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Ether.Data.Dapper.SQLite.Repository
{
    internal class MangaRepository : IMangaRepository
    {
        private readonly string connectionString;

        public MangaRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Create(Manga entity)
        {
            Helpers.ThrowIfEntityNull(entity);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    INSERT INTO manga (Name, Chapter, Completed, Deleted, CreatedOn, ModifiedOn)
                    VALUES (@Name, @Chapter, @Completed, @Deleted, @CreatedOn, @ModifiedOn);
                    SELECT last_insert_rowid();";

                return dbConn.QueryFirst<int>(query, entity);
            }
        }

        public bool Delete(int id)
        {
            Helpers.ThrowIfIntZero(id);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = "DELETE FROM manga WHERE Id = @Id;";

                var result = dbConn.Execute(query, new { Id = id });

                return result > 0;
            }
        }

        public IEnumerable<Manga> GetAll()
        {
            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    SELECT Id, Name, Chapter, Completed, Deleted, CreatedOn, ModifiedOn
                    FROM manga;";

                return dbConn.Query<Manga>(query);
            }
        }

        public Manga GetById(int id)
        {
            Helpers.ThrowIfIntZero(id);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    SELECT Id, Name, Chapter, Completed, Deleted, CreatedOn, ModifiedOn
                    FROM manga
                    WHERE Id = @Id;";

                return dbConn.QueryFirstOrDefault<Manga>(query, new { Id = id });
            }
        }

        public bool Update(Manga entity)
        {
            Helpers.ThrowIfEntityNull(entity);

            using (var dbConn = new SQLiteConnection(connectionString))
            {
                const string query = @"
                    UPDATE tvshows SET
                        Name = @Name,
                        Chapter = @Chapter,
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