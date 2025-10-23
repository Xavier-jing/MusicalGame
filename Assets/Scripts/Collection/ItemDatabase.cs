using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 所有需要收集的物品
/// </summary>
[CreateAssetMenu(fileName = "CollectionDatabase", menuName = "Data/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemData = new List<ItemData>();
}
