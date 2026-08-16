// Rui Min - Iterator pattern

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICKIER_Furniture_Retailer_System
{
    public class FurnitureFilterIterator : IFurnitureIterator
    {
        private List<FurnitureItem> furnitureItems;
        private int currentPosition;
        private Brand? brandFilter;
        private bool promotionFilter;

        public FurnitureFilterIterator(List<FurnitureItem> items, Brand? brand, bool promotionOnly)
        {
            furnitureItems = items;
            currentPosition = 0;
            brandFilter = brand;
            promotionFilter = promotionOnly;
            MoveToNextMatch();
        }

        public bool HasNext()
        {
            return currentPosition < furnitureItems.Count;
        }

        public FurnitureItem Next()
        {
            if (!HasNext())
            {
                throw new InvalidOperationException("No more matching furniture items.");
            }
            FurnitureItem item = furnitureItems[currentPosition];
            currentPosition++;
            MoveToNextMatch();
            return item;
        }

        // checks if the item matches the filter
        private bool MatchesFilter(FurnitureItem item)
        {
            if (brandFilter != null)
            {
                if (item.BrandName == null || item.BrandName.BrandId != brandFilter.BrandId)
                {
                    return false;
                }
            }

            if (promotionFilter)
            {
                if (item.ActivePromotion == null || !item.ActivePromotion.IsActive())
                {
                    return false;
                }
            }
            return true;
        }

        // skips items thats doesnt match the filter
        private void MoveToNextMatch()
        {
            while (currentPosition < furnitureItems.Count && !MatchesFilter(furnitureItems[currentPosition]))
            {
                currentPosition++;
            }
        }
    }
}
