using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Entities.Specifications
{

    /// <summary>
    ///     Represents an implementation of a <see cref="ISpecification"/> which evaluates entities using predicates
    /// </summary>
    public abstract class PredicateSpecificationBase : SpecificationBase
    {

        /// <summary>
        ///     Returns the predicate of the current specification
        /// </summary>
        protected abstract Func<IEntity, bool> Predicate { get; }

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        public override string ToString() => Predicate?.ToString() ?? string.Empty;

        /// <summary>
        ///     Returns whether the current <see cref="ISpecification"/> is satisfied by the provided <see cref="IEntity"/>
        /// </summary>
        public override bool IsSatisfiedBy(IEntity entity) => Predicate?.Invoke(entity) ?? true;

    }
}
