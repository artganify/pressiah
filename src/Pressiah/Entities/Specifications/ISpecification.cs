using Pressiah.Core;

namespace Pressiah.Entities.Specifications
{

    /// <summary>
    ///     Represents a specification which can be applied on an <see cref="IEntity"/>
    /// </summary>
    public interface ISpecification
    {

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        bool IsSatisfiedBy(IEntity entity);

    }

}
