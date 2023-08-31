using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> collectedItems = new List<string>();
    public int lst_size;


    public void AddToInvetory(Collectible collectible)
    {
        
        collectedItems.Add(collectible.name);
        lst_size = collectedItems.Count;
    }


    
}
