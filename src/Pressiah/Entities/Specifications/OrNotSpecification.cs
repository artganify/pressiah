namespace Pressiah.Entities.Specifications
{
    /// <summary>
    ///     Represents an ORNOT (|!) specification
    /// </summary>
    public class OrNotSpecification : CompositeSpecificationBase
    {

        /// <summary>
        ///     Creates a new <see cref="OrNotSpecification"/> providing a left and right part of the specification
        /// </summary>
        public OrNotSpecification(ISpecification left, ISpecification right)
            : base(left, right)
        {
        }

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => Left.IsSatisfiedBy(entity) |! Right.IsSatisfiedBy(entity);

    }
}