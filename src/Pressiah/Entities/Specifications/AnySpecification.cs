namespace Pressiah.Entities.Specifications
{
    /// <summary>
    ///     Represents an any specification
    /// </summary>
    public class AnySpecification : SpecificationBase
    {

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => true;

    }
}