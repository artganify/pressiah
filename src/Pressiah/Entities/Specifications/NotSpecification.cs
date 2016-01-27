namespace Pressiah.Entities.Specifications
{
    /// <summary>
    ///     Represents a NOT (!) specification
    /// </summary>
    public class NotSpecification : SpecificationBase
    {

        private readonly ISpecification _specification;

        /// <summary>
        ///     Creates a new <see cref="NotSpecification"/>, specifying the inner specification to negate
        /// </summary>
        public NotSpecification(ISpecification specification)
        {
            _guard.AgainstNullArgument(nameof(specification), specification);
            _specification = specification;
        }

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => !_specification.IsSatisfiedBy(entity);

    }
}