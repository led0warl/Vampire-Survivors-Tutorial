using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vampire;

public class PlayerCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        //Check if the other game object has the ICollectible interface
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //If it does, call the collect method
            collectible.Collect();
        }
    }
}
