namespace Pressiah.Entities.Specifications
{
    /// <summary>
    ///     Represents an ANDALSO (&amp;&amp;) specification
    /// </summary>
    public class AndAlsoSpecification : CompositeSpecificationBase
    {

        /// <summary>
        ///     Creates a new <see cref="AndAlsoSpecification"/> providing a left and right part of the specification
        /// </summary>
        public AndAlsoSpecification(ISpecification left, ISpecification right) 
            : base(left, right)
        {
        }

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => Left.IsSatisfiedBy(entity) && Right.IsSatisfiedBy(entity);

    }
}