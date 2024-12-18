using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;
public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinsUI; //den definere vores coint text i højre hjørne. 
    public ShopItemSO[] shopItemSO; //Collection of all the different stuff in the shop. 
    public ShopTemplate[] shopPanels; //shop temple script den referer til title, description og coins i vores template. 
    public GameObject[] shopPanelsGO; //referer til gameobjekt 
    public Button[] myPurchaseBtns;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        { 
            shopPanelsGO[i].SetActive(true);
        }

        coinsUI.text = "Coins: " + coins.ToString(); 
        LoadPanels();
        CheckPurchaseable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins()//Simple script to add coins 
    {
        coins++;
        coinsUI.text ="Coins: " + coins.ToString();
        CheckPurchaseable();
    }

    public void CheckPurchaseable() 
    {
        for (int i = 0; i < shopItemSO.Length; i++)// loops that goes through the items in the shop
        {
            if (coins >= shopItemSO  [i].baseCost) // hvis de coins jeg har er >= end varepris i shoppen så activere puchase button. 
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;

        }
    }
    public void PurchaseItem(int btnNo)
    {
        if (coins >= shopItemSO[btnNo -1].baseCost)
        {
            coins = coins - shopItemSO[btnNo -1].baseCost;
            coinsUI.text = " Coins: " + coins.ToString();
            CheckPurchaseable();

        }
    }
    public void LoadPanels()
    {
        for ( int i = 0; i < shopItemSO.Length; i++ )
        {
            shopPanels[i].titleTxt.text = shopItemSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemSO[i].description;
            shopPanels[i].costTxt.text = "Coins: " + shopItemSO[i].baseCost.ToString();
        }
    }
}
