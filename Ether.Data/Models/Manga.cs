using Ether.Data.Interfaces;
using System;

namespace Ether.Data.Models
{
    public class Manga : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Chapter { get; set; }

        public bool Completed { get; set; }

        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}