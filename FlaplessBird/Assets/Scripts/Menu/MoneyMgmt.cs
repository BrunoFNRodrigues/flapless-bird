using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyMgmt : MonoBehaviour
{
    //FIELDS:
    // singleton instance
    public static MoneyMgmt instance;

    // the player's money
    public int currentMoney;

    // Text that displays the player's money
    public TextMeshProUGUI txt_Money;

    // METHODS:
    // Static method to get the singleton instance
    public static MoneyMgmt Instance
    {
        get { return instance; }
    }


    // singleton and dont destroy on load
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void Init()
    {
        txt_Money.text = currentMoney.ToString();
    }

    // adds money to the player's money
    public void addMoney(int amount)
    {
        currentMoney += amount;
        txt_Money.text = currentMoney.ToString();
    }

    // use (remove) money from the player's money
    public void useMoney(int amount)
    {
        if (EnoughMoney(amount))
        {
            currentMoney -= amount;
            txt_Money.text = currentMoney.ToString();
        }
        //currentMoney -= amount;
        //txt_Money.text = currentMoney.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // EnoughtMoney: returns true if the player has enough money to buy the item
    public bool EnoughMoney(int price)
    {
        if (currentMoney >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // when current money is changed, update the text
    public void UpdateMoneyText()
    {
        txt_Money.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
