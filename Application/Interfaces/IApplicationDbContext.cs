using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Represent contract to work with DB.
    /// </summary>
    public interface IApplicationDbContext
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        DbSet<Product> Products { get; set; }

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
