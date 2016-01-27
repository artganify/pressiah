using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities.Specifications
{

    /// <summary>
    ///     Represents a base implementation of a <see cref="ISpecification"/>
    /// </summary>
    public abstract class SpecificationBase : ISpecification
    {

        /// <summary>
        ///     Returns an instance of a <see cref="AnySpecification"/>
        /// </summary>
        public static readonly AnySpecification Any = new AnySpecification();

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public abstract bool IsSatisfiedBy(IEntity entity);

        /// <summary>
        ///     Operator override for <see cref="AndSpecification"/>
        /// </summary>
        public static SpecificationBase operator &(SpecificationBase left, SpecificationBase right)
        {
            return new AndSpecification(left, right);
        }

        /// <summary>
        ///     Operator override for <see cref="OrSpecification"/>
        /// </summary>
        public static SpecificationBase operator |(SpecificationBase left, SpecificationBase right)
        {
            return new OrSpecification(left, right);
        }

        /// <summary>
        ///     Operator override for <see cref="NotSpecification"/>
        /// </summary>
        public static SpecificationBase operator !(SpecificationBase specification)
        {
            return new NotSpecification(specification);
        }

    }

}
