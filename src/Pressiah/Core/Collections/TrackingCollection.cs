using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pressiah.Core.Collections
{

    /// <summary>
    ///     Represents a simple trackable collection
    /// </summary>
    public class TrackingCollection<T> : Collection<T>, ITrackableCollection<T>
    {

        /// <summary>
        ///     Invoked when an item has been added to the collection
        /// </summary>
        public event EventHandler<TrackableCollectionChangedEventArgs<T>> ItemAdded;

        /// <summary>
        ///     Invoked when an item has been removed from the collection
        /// </summary>
        public event EventHandler<TrackableCollectionChangedEventArgs<T>> ItemRemoved;

        /// <summary>
        ///     Adds a range of elements to the current collection
        /// </summary>
        /// <param name="items"></param>
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items) {
                Add(item);
            }
        }

        /// <summary>
        ///     Removes all elements from the <see cref="TrackingCollection{T}"/>.
        /// </summary>
        protected override void ClearItems()
        {
            var itemsToRemove = new List<T>();
            lock (Items)
            {
                itemsToRemove.AddRange(Items);
            }


            base.ClearItems();

            foreach(var removedItem in itemsToRemove)
                ItemRemoved?.Invoke(this, 
                new TrackableCollectionChangedEventArgs<T>(removedItem));
        }

        /// <summary>
        ///     Inserts an element into the <see cref="TrackingCollection{T}"/> at the specified index.
        /// </summary>
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            ItemAdded?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(item));
        }

        /// <summary>
        ///     Removes the element at the specified index of the <see cref="TrackingCollection{T}"/>.
        /// </summary>
        protected override void RemoveItem(int index)
        {
            T itemToRemove;
            lock (Items) {
                itemToRemove = Items[index];
            }

            base.RemoveItem(index);
            ItemRemoved?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(itemToRemove));
        }

        /// <summary>
        ///     Replaces the element at the specified index.
        /// </summary>
        protected override void SetItem(int index, T item)
        {
            T itemToReplace;
            lock (Items) {
                itemToReplace = Items[index];
            }

            base.SetItem(index, item);

            ItemRemoved?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(itemToReplace));
            ItemAdded?.Invoke(this, new TrackableCollectionChangedEventArgs<T>(item));
        }

        /// <summary>
        ///     Returns an enumerator to iterate over the collection
        /// </summary>
        /// <returns></returns>
        public new List<T>.Enumerator GetEnumerator()
        {
            return ((List<T>)Items).GetEnumerator();
        }

    }
}
