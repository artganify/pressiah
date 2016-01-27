using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pressiah.Core;
using Pressiah.Core.Collections;
using Pressiah.Entities.Specifications;

namespace Pressiah.Entities
{
    
    public class EntityProcessingGroup : ComponentBase, IEntityGroup
    {

        /// <summary>
        ///     Returns a collection of entities within this group
        /// </summary>
        public TrackingHashSet<IEntity> Entities { get; } = new TrackingHashSet<IEntity>();

        public EntityProcessingGroup()
        {

            // add event handlers
            Entities.ItemAdded       += EntitiesOnItemAdded;
            Entities.ItemRemoved     += EntitiesOnItemRemoved;
        }

        private void EntitiesOnItemAdded(object sender, TrackableCollectionChangedEventArgs<IEntity> trackingCollectionItemAddedEventArgs)
        {
            throw new NotImplementedException();
        }

        private void EntitiesOnItemRemoved(object sender, TrackableCollectionChangedEventArgs<IEntity> trackingCollectionChangedEventArgs)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Invoked when an entity has been added to the group
        /// </summary>
        protected virtual void OnEntityAdded(IEntity entity)
        {
            
        }

        /// <summary>
        ///     Invoked when an entity has been removed from the group
        /// </summary>
        protected virtual void OnEntityRemoved(IEntity entity)
        {
            
        }

        #region explicit implementations

        IEnumerable<IEntity> IEntityGroup.Entities => Entities;

        #endregion
    }
}
