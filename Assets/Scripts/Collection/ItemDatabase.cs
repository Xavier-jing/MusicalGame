using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ������Ҫ�ռ�����Ʒ
/// </summary>
[CreateAssetMenu(fileName = "CollectionDatabase", menuName = "Data/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> itemData = new List<ItemData>();
}
