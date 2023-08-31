using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class ChiefChair : MonoBehaviour
{
    


    private void OnTriggerEnter2D(Collider2D other)
    {
        Inventory inventory = FindAnyObjectByType<Inventory>();
        if (other.CompareTag("Player"))
        {
            if (inventory.lst_size != GameManager.Instance.n_items_to_collect)
            {
                Debug.Log("There are missing items out there! Come back when you catch them all!");
            }
            else {
                other.gameObject.SetActive(false);
                
                GameManager.Instance.NextLevel(3f);
            }
            
        }
    }

    private void delay() { }
}
