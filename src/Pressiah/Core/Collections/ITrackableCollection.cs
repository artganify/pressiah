using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Core.Collections
{

    /// <summary>
    ///     Contract for a trackable collection, which fires events when an item has been added or removed
    /// </summary>
    public interface ITrackableCollection<T> : ICollection<T>
    {

        /// <summary>
        ///     Invoked when an item has been added to the collection
        /// </summary>
        event EventHandler<TrackableCollectionChangedEventArgs<T>> ItemAdded;

        /// <summary>
        ///     Invoked when an item has been removed from the collection
        /// </summary>
        event EventHandler<TrackableCollectionChangedEventArgs<T>> ItemRemoved;

    }
}
