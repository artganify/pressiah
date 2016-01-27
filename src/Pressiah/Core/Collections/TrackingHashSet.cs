using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Core.Collections
{

    /// <summary>
    ///     Represents a tracking hash set
    /// </summary>
    public class TrackingHashSet<T> : ISet<T>, ITrackableCollection<T>
    {

        private readonly HashSet<T> _innerHashSet = new HashSet<T>(); 

        /// <summary>
        ///     Invoked when an item has been added to the collection
        /// </summary>
        public event EventHandler<TrackableCollectionChangedEventArgs<T>> ItemAdded;

        /// <summary>
        ///     Invoked when an item has been removed from the collection
        /// </summary>
        public event EventHandler<TrackableCollectionChangedEventArgs<T>> ItemRemoved;

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="TrackingHashSet{T}"/>.
        /// </summary>
        public int Count => _innerHashSet.Count;

        /// <summary>
        ///     Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both.
        /// </summary>
        public void UnionWith(IEnumerable<T> other) => _innerHashSet.UnionWith(other);

        /// <summary>
        ///     Modifies the current set so that it contains only elements that are also in a specified collection.
        /// </summary>
        public void IntersectWith(IEnumerable<T> other) => _innerHashSet.IntersectWith(other);

        /// <summary>
        ///     Removes all elements in the specified collection from the current set.
        /// </summary>
        public void ExceptWith(IEnumerable<T> other) => _innerHashSet.ExceptWith(other);

        /// <summary>
        ///     Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both. 
        /// </summary>
        public void SymmetricExceptWith(IEnumerable<T> other) => _innerHashSet.SymmetricExceptWith(other);

        /// <summary>
        ///     Determines whether a set is a subset of a specified collection.
        /// </summary>
        public bool IsSubsetOf(IEnumerable<T> other) => _innerHashSet.IsSubsetOf(other);

        /// <summary>
        ///     Determines whether the current set is a superset of a specified collection.
        /// </summary>
        public bool IsSupersetOf(IEnumerable<T> other) => _innerHashSet.IsSupersetOf(other);

        /// <summary>
        ///     Determines whether the current set is a proper (strict) superset of a specified collection.
        /// </summary>
        public bool IsProperSupersetOf(IEnumerable<T> other) => _innerHashSet.IsProperSupersetOf(other);

        /// <summary>
        ///     Determines whether the current set is a proper (strict) subset of a specified collection.
        /// </summary>
        public bool IsProperSubsetOf(IEnumerable<T> other) => _innerHashSet.IsProperSubsetOf(other);

        /// <summary>
        ///     Determines whether the current set overlaps with the specified collection.
        /// </summary>
        public bool Overlaps(IEnumerable<T> other) => _innerHashSet.Overlaps(other);

        /// <summary>
        ///     Determines whether the current set and the specified collection contain the same elements.
        /// </summary>
        public bool SetEquals(IEnumerable<T> other) => _innerHashSet.SetEquals(other);

        /// <summary>
        ///     Adds an element to the current set and returns a value to indicate if the element was successfully added. 
        /// </summary>
        public bool Add(T item)
        {
            var hasBeenAdded = _innerHashSet.Add(item);
            if(hasBeenAdded)
                ItemAdded?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(item));

            return hasBeenAdded;
        }

        /// <summary>
        ///     Removes all items from the <see cref="TrackingHashSet{T}"/>.
        /// </summary>
        public void Clear()
        {
            var itemsToRemove = new List<T>();
            lock (_innerHashSet)
                itemsToRemove.AddRange(_innerHashSet);
            
            _innerHashSet.Clear();
            foreach(var removedItem in itemsToRemove)
                ItemRemoved?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(removedItem));
        }

        /// <summary>
        ///     Determines whether the <see cref="TrackingHashSet{T}"/> contains a specific value.
        /// </summary>
        public bool Contains(T item) => _innerHashSet.Contains(item);

        /// <summary>
        ///     Copies the elements of the <see cref="TrackingHashSet{T}"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex) => _innerHashSet.CopyTo(array, arrayIndex);

        /// <summary>
        ///     Removes the first occurrence of a specific object from the <see cref="TrackingHashSet{T}"/>.
        /// </summary>
        public bool Remove(T item)
        {
            var hasBeenRemoved = _innerHashSet.Remove(item);
            if (hasBeenRemoved)
                ItemRemoved?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(item));

            return hasBeenRemoved;
        }

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        public IEnumerator<T> GetEnumerator() => _innerHashSet.GetEnumerator();

        #region explicit implementations

        void ICollection<T>.Add(T item) => Add(item);

        bool ICollection<T>.IsReadOnly => false;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

    }
}
