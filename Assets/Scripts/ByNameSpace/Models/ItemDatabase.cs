using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OpenWorld.Models
{
    [Serializable]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField]
        public ItemCategory[] ItemCategories;


        public Item GetItemData(string itemName)
        {
            foreach (ItemCategory category in ItemCategories)
            {
                foreach (Item item in category.CategoryItems)
                {
                    if (item.Name == itemName)
                        return item;
                }
            }
            return null;

        }

        public GameObject GetWorldItem(string itemName)
        {
            foreach (ItemCategory category in ItemCategories)
            {
                foreach (Item item in category.CategoryItems)
                {
                    if (item.Name == itemName)
                        return item.WorldObject;
                }
            }
            return null;
        }
    }
}
