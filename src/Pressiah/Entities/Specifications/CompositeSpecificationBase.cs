using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities.Specifications
{

    /// <summary>
    ///     Provides the base for composite specifications
    /// </summary>
    public abstract class CompositeSpecificationBase : SpecificationBase
    {

        /// <summary>
        ///     Returns the left part of the specification
        /// </summary>
        public ISpecification Left { get; }

        /// <summary>
        ///     Returns the right part of the specification
        /// </summary>
        public ISpecification Right { get; }

        /// <summary>
        ///     Creates a new <see cref="CompositeSpecificationBase"/> providing a left and right part of the specification
        /// </summary>
        protected CompositeSpecificationBase(ISpecification left, ISpecification right)
        {
            _guard.AgainstNullArgument(nameof(left), left);
            _guard.AgainstNullArgument(nameof(right), right);

            Left    = left;
            Right   = right;
        }

    }
}
