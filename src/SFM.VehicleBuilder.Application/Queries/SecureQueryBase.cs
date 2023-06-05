using SFM.VehicleBuilder.Application.Authorization;
using SFM.VehicleBuilder.Domain.Correlation;

namespace SFM.VehicleBuilder.Application.Queries
{
    /// <summary>
    ///   An abstract base query class that provides implementations of various required interfaces.
    /// </summary>
    /// <typeparam name="TResponse">The response type returned by the query.</typeparam>
    public abstract class SecureQueryBase<TResponse> : QueryBase<TResponse>, IRequireAuthorization
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="SecureQueryBase{TResponse}"/> class.
        /// </summary>
        /// <param name="correlationId">A unique correlation identifier provided by the client.</param>
        protected SecureQueryBase(CorrelationId correlationId)
            : base(correlationId)
        {
        }

        /// <inheritdoc/>
        public AuthorizationData AuthorizationData { get; set; }
    }
}
