using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
 //vi bruger den til at tilføje  nyt shopitem       //navnet i menu                  // så den kommer først i menuen 
[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Objects/New shop Item", order = 1)]
//Vi bruger ScriptableObject så vi kan referer til data uden at tildele det til en gameobject.
// alt som stammer fra en monobehaviour skal være tilknyttet til en gameobjekt 
public class ShopItemSO : ScriptableObject
{
    public string title;
    public string description;
    // vi definere baseCost som int fordi vi skal lave bergerninger og konvertere bagefter til en string. 
    public int baseCost;


}
