using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenWorld.Models
{
    [Serializable]
    public class ItemDatabase :ScriptableObject
    {
        [SerializeField]
        public ItemCategory[] ItemCategories;
    }
}
