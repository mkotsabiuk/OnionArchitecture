using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    ///<inheritdoc/>
    public class CreateProductCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the barcode.
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        public decimal Rate { get; set; }

        ///<inheritdoc/>
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateProductCommandHandler"/> class.
            /// </summary>
            /// <param name="context">The context.</param>
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            /// <summary>
            /// Handles the specified command.
            /// </summary>
            /// <param name="command">The command.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Barcode = command.Barcode,
                    Name = command.Name,
                    Rate = command.Rate,
                    Description = command.Description
                };
                await _context.Products.AddAsync(product, cancellationToken);
                await _context.SaveChangesAsync();
                return product.Id;
            }
        }
    }
}
