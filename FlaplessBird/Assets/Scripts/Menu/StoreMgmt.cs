using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreMgmt : MonoBehaviour
{
    // class that manages the store, and what the player buys in each game
    // this class is a singleton
    public static StoreMgmt instance;
    // the player's money from the MoneyMgmt class

    public MoneyMgmt moneyMgmt;

    // the player can only buy one 

    // change image of bought item to white
    public GameObject bought_wings_img;
    public GameObject bought_cape_img;
    public GameObject bought_umbrella_img;
    public GameObject bought_helmet_img;

    // the items that the player has bought
    public static int wings = 0; //invencible for x seconds 
    public static int cape = 0; // double money 
    public static int umbrella = 0; // slows down fall 
    public static int helmet = 0; // extra life 

    public static StoreMgmt Instance
    {
        get { return instance; }
    }


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void bought_wings()
    {
        Debug.Log("bought_wings function called");
        if(wings == 0 && moneyMgmt.EnoughMoney(1))
        {
            Debug.Log("Entrei");
            wings = 1;
            bought_wings_img.SetActive(true);
            moneyMgmt.useMoney(1);
        }  
    }

    public void bought_cape()
    {
        if (cape == 0 && moneyMgmt.EnoughMoney(2))
        {
            cape = 1;
            bought_cape_img.SetActive(true);
            moneyMgmt.useMoney(2);
        }
    }

    public void bought_umbrella()
    {
        if (umbrella == 0 && moneyMgmt.EnoughMoney(5))
        {
            umbrella = 1;
            bought_umbrella_img.SetActive(true);
            moneyMgmt.useMoney(5);
        }
    }

    public void bought_helmet()
    {
        if (helmet == 0 && moneyMgmt.EnoughMoney(4))
        {
            helmet = 1;
            bought_helmet_img.SetActive(true);
            moneyMgmt.useMoney(4);
        }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        //unactive items
        Debug.Log("MoneyMgmt reference: " + moneyMgmt);
        bought_wings_img.SetActive(false);
        bought_cape_img.SetActive(false);
        bought_umbrella_img.SetActive(false);
        bought_helmet_img.SetActive(false);
        // singleton
        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

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
    public void Reset()
    {
        wings = 0;
        cape = 0;
        umbrella = 0;
        helmet = 0;
    }

    // getters and setters
    public int getWings()
    {
        return wings;
    }

    public int getCape()
    {
        return cape;
    }

    public int getUmbrella()
    {
        return umbrella;
    }

    public int getHelmet()
    {
        return helmet;
    }

    public void setWings(int w)
    {
        wings = w;
    }

    public void setCape(int c)
    {
        cape = c;
    }

    public void setUmbrella(int u)
    {
        umbrella = u;
    }

    public void setHelmet(int h)
    {
        helmet = h;
    }

    


    
    
}
