using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities.Specifications
{

    /// <summary>
    ///     Represents an AND (&amp;) specification
    /// </summary>
    public class AndSpecification : CompositeSpecificationBase
    {

        /// <summary>
        ///     Creates a new <see cref="AndSpecification"/> providing a left and right part of the specification
        /// </summary>
        public AndSpecification(ISpecification left, ISpecification right) : base(left, right)
        {
        }

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => Left.IsSatisfiedBy(entity) & Right.IsSatisfiedBy(entity);

    }
}
