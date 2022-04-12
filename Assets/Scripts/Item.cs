using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
   new public string name = "New Item";
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


   void Update()
   {

   }

   public virtual void Use()
   {
     
      // use item
      // cause event or animation/staus change like new arm attached

      Debug.Log("Using " + name);
   }
}
