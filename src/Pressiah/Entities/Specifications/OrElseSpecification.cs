namespace Pressiah.Entities.Specifications
{
    /// <summary>
    ///     Represents an ORELSE (||) specification
    /// </summary>
    public class OrElseSpecification : CompositeSpecificationBase
    {

        /// <summary>
        ///     Creates a new <see cref="OrElseSpecification"/> providing a left and right part of the specification
        /// </summary>
        public OrElseSpecification(ISpecification left, ISpecification right)
            : base(left, right)
        {
        }

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => Left.IsSatisfiedBy(entity) || Right.IsSatisfiedBy(entity);

    }
}