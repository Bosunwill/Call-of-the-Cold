using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
   new public string name = "New Item";
   public Sprite icon = null;
   public bool isDefaultItem = false;

   public virtual void Use()
   {
      // use item
      // cause event or animation/staus change like new arm attached

      Debug.Log("Using " + name);
   }
}
