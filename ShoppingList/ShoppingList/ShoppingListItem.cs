using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShoppingListItem
    {
        public string ListItemName { get; set; }

        public ShoppingListItem(string listItemName)
        {
            ListItemName = listItemName ?? throw new ArgumentNullException(nameof(listItemName));
        }

        public override string ToString()
        {
            return $"{ListItemName}";
        }

        
    }
}
