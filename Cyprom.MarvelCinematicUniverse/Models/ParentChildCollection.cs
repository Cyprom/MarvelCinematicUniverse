using System.Collections.Generic;

namespace Cyprom.MarvelCinematicUniverse.Models
{
    public class ParentChildCollection<P, C> : List<C>
        where P : class
        where C : ChildOf<P>
    {
        public P Parent;

        public ParentChildCollection(P parent) : base() {
            this.Parent = parent;
        }

        #region Overrides

        public new void Add(C child)
        {
            if (child != null)
            {
                child.Parent = Parent;
                base.Add(child);
            }
        }

        public new bool Remove(C child)
        {
            if (child != null)
            {
                child.Parent = null;
                return base.Remove(child);
            }
            return false;
        }

        public new void Clear()
        {
            foreach (var child in this)
            {
                child.Parent = null;
            }
            base.Clear();
        }

        #endregion
    }
}
