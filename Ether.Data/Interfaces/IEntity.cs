using System;

namespace Ether.Data.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }

        bool Completed { get; set; }

        bool Deleted { get; set; }

        DateTime CreatedOn { get; set; }

        DateTime ModifiedOn { get; set; }
    }
}