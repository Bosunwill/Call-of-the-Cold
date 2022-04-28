using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
   public Item item;
   public string itemName = "New Item";
   public Sprite icon = null;
   public bool permItem = false;
   public AudioClip cas1;
   public AudioClip cas2;
   public AudioClip cas3;
   public bool isDefaultItem = false;
   public bool cassetteTape = false;
   public bool isCassette1 = false;
   public bool isCassette2 = false;
   public bool isCassette3 = false;
   public bool slotItem = false;
   public enum itemType {Batteries, KeyCard, ScrewDriver, CassettePlayer, HandHeldFan, Tape, TheCure}
   public itemType thisItem = itemType.Batteries;


   void Update()
   {

   }

   public virtual void Use()
   {
     
      // use item
      // cause event or animation/staus change like new arm attached

      Debug.Log("Using " + name);
   }

   public void Load(ItemsData data)
   {
      item = Resources.Load<Item>(data.ItemName);
   }
}
