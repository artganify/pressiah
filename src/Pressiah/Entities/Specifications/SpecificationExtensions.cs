using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities.Specifications
{

    /// <summary>
    ///     Extensions for <see cref="ISpecification"/>
    /// </summary>
    public static class SpecificationExtensions
    {

        /// <summary>
        ///     Creates a new AND specification from the provided left and right side of the specification
        /// </summary>
        public static ISpecification And(this ISpecification left, ISpecification right) => new AndSpecification(left, right);

        /// <summary>
        ///     Creates a new OR specification from the provided left and right side of the specification
        /// </summary>
        public static ISpecification Or(this ISpecification left, ISpecification right) => new OrSpecification(left, right);

        /// <summary>
        ///     Creates a new AND ALSO specification from the provided left and right side of the specification
        /// </summary>
        public static ISpecification AndAlso(this ISpecification left, ISpecification right) => new AndAlsoSpecification(left, right);

        /// <summary>
        ///     Creates a new AND NOT specification from the provided left and right side of the specification
        /// </summary>
        public static ISpecification AndNot(this ISpecification left, ISpecification right) => new AndNotSpecification(left, right);

        /// <summary>
        ///     Creates a new OR ELSE specification from the provided left and right side of the specification
        /// </summary>
        public static ISpecification OrElse(this ISpecification left, ISpecification right) => new OrElseSpecification(left, right);

        /// <summary>
        ///     Creates a new OR NOT specification from the provided left and right side of the specification
        /// </summary>
        public static ISpecification OrNot(this ISpecification left, ISpecification right) => new OrNotSpecification(left, right);

        /// <summary>
        ///     Creates a new NOT specification from the provided one
        /// </summary>
        public static ISpecification Not(this ISpecification specification) => new NotSpecification(specification);

    }
}
