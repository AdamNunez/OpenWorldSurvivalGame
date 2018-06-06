using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;


namespace OpenWorld.Models
{
    [Serializable]
    public class Item
    {
        [SerializeField]
        public string Name;
        [SerializeField]
        public Sprite Icon;
        [SerializeField]
        public int MaxStackSize;
        [SerializeField]
        public GameObject WorldObject;
    }

    [Serializable]
    public class ItemCategory
    {
        [SerializeField]
        public string CategoryName;
        [SerializeField]
        public Item[] CategoryItems;
    }
}
