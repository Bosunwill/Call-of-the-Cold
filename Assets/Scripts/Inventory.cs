using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    const string INV_KEY = "/inv";
    const string INV_COUNT_KEY = "/inv.count";

    public bool outOfRoom = false;

 


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            Load();
        }

    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;
    public int space = 20;
    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {

            if(items.Count >= space)
            {
                outOfRoom = true;
                Debug.Log("Not enough room.");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }
        
        return true;
    }


    public void Remove (Item item)
    {
        items.Remove(item);

        if(onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
    }


    //public void Save()
    //{
//
    //    string key = INV_KEY;
    //    string countKey = INV_COUNT_KEY;
//
    //    SaveSystem.Save(items.Count, countKey);
//
//
    //    for (int i = 0; i < items.Count; i++)
    //    {
    //        ItemsData data = new ItemsData(items[i]);
//
    //        SaveSystem.Save(data, key + i);
//
    //    }
//
    //    Debug.Log("Saved All Items!");
    //}
//



    public void Load()
    {


        UnityEngine.SceneManagement.SceneManager.LoadScene("theLobby");





       // string key = INV_KEY;
       // string countKey = INV_COUNT_KEY;
       // 
       // int count = SaveSystem.Load<int>(countKey);
//
       // for (int i = 0; i < count; i++)
       // {
       //     Item item = Instantiate(itemPrefab);
       //     ItemsData data = SaveSystem.Load<ItemsData>(key + i);
//
       //     item.Load(data);
       //     Add(item);
       // }
    }
    


    
}
