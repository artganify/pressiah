using System;

namespace Pressiah.Core.Collections
{
    /// <summary>
    ///     Event arguments used to indicate a change within a <see cref="ITrackableCollection{T}"/>
    /// </summary>
    public class TrackableCollectionChangedEventArgs<T> : EventArgs
    {

        /// <summary>
        ///     Returns the item affected by the change
        /// </summary>
        public T Item { get; }

        /// <summary>
        ///     Creates a new <see cref="TrackableCollectionChangedEventArgs{T}"/>, specifying the item affected by the change
        /// </summary>
        public TrackableCollectionChangedEventArgs(T item)
        {
            Item = item;
        } 

    }
}