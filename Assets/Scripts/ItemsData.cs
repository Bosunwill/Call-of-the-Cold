using UnityEngine;

[System.Serializable]
public class ItemsData
{

    public string ItemName;
    

    public ItemsData(Item item)
    {
        ItemName = item.name;
        
    }
}
