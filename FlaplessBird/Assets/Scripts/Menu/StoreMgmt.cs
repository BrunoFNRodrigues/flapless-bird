using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreMgmt : MonoBehaviour
{
    // class that manages the store, and what the player buys in each game
    // this class is a singleton
    public static StoreMgmt instance;

    // the player's money

    // the items that the player has bought
    public int wings = 0;
    public int cape = 0;
    public int umbrella = 0;
    public int helmet = 0;

    
    // the list of items that the player can buy
    //public List<StoreItem> storeItems = new List<StoreItem>();

    // the list of items that the player has bought
    //public List<StoreItem> boughtItems = new List<StoreItem>();

    /*ITEMS:
    wings: invencible for x seconds - 0
    gold_cape: double money - 1
    umbrella: slows down fall - 2
    helmet: extra life - 3
    */

    public void bought_wings()
    {
        wings = 1;
    }

    public void bought_cape()
    {
        cape = 1;
    }

    public void bought_umbrella()
    {
        umbrella = 1;
    }

    public void bought_helmet()
    {
        helmet = 1;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        // singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // add all the items to the store
        //storeItems.Add(new StoreItem("Wings", 100, 0));
        //storeItems.Add(new StoreItem("Gold Cape", 200, 1));
        //storeItems.Add(new StoreItem("Umbrella", 300, 2));
        //storeItems.Add(new StoreItem("Helmet", 400, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function that buys an item
    public void BuyItem(int itemIndex)
    {
        //TODO: check if the player has enough money

        // add the item to the bought items list

        // turn the item off in the store

        // turn the item on in the game


    }


    
    
}
