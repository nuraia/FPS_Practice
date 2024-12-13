
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewRecepie", menuName = "Recepie/Create New Recepie")]
public class Recepie : ScriptableObject
{
    public Item finalRecepie;
    public List<Item> Ingredients = new List<Item>();
}