using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressiah.Core;

namespace Pressiah.Entities
{

    /// <summary>
    ///     Represents a group of entities
    /// </summary>
    public interface IEntityGroup : IComponent
    {

        /// <summary>
        ///     Returns all entities within this group
        /// </summary>
        IEnumerable<IEntity> Entities { get; } 

    }
}
