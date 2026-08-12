// Rui Min - Composite pattern
using System;
using System.Collections.Generic;
using System.Text;

namespace ICKIER_Furniture_Retailer_System
{
    internal class FurnitureCollection : CatalogComponent
    {
        private int collectionId;
        private string name;
        private string description;
        private List<CatalogComponent> children;

        public int CollectionId {  get { return collectionId; } set { collectionId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public List<CatalogComponent> Children { get { return children; } set { children = value; } }

        // constructor
        public FurnitureCollection(int id, string name, string desc)
        {
            this.collectionId = id;
            this.name = name;
            this.description = desc;
            children = new List<CatalogComponent>();
        }

        // add collections, sub-collections, items
        public override void Add(CatalogComponent component)
        {
            children.Add(component);
        }
        // remove collections, sub-collections, items
        public override void Remove(CatalogComponent component)
        {
            children.Remove(component);
        }
        // return desc of collection, sub-collection, item
        public override string GetDescription()
        {
            return description;
        }
        // return collection, sub-collection, item
        public override CatalogComponent GetChild(int index)
        {
            return children[index];
        }
        // return all collections, sub-collections, items
        public List<CatalogComponent> GetChildren()
        {
            return children;
        }
        //public override string Display()
        //{
        //    string output = name + "\n";

        //    foreach (CatalogComponent child in children)
        //    {
        //        output += "  " + child.Display() + "\n";
        //    }

        //    return output;
        //}
    }
}
