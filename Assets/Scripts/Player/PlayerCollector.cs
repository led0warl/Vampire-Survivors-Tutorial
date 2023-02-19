using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vampire;

public class PlayerCollector : MonoBehaviour
{
    PlayerStat player;
    CircleCollider2D playerCollector;
    public float pullSpeed;

    private void Start()
    {
        player = FindObjectOfType<PlayerStat>();
        playerCollector = GetComponent<CircleCollider2D>();
        

    }

    private void Update()
    {
        playerCollector.radius = player.CurrentMagnet;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Check if the other game object has the ICollectible interface
        if (col.gameObject.TryGetComponent(out ICollectible collectible))
        {
            //Pulling animation
            //Gets the Rigidbody2D component on the item
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            //Vector2 pointing from the item to the player
            Vector2 forceDirection = (transform.position - col.transform.position).normalized;
            //Applies froce to the item in the dorceDirection with pullSpeed
            rb.AddForce(forceDirection * pullSpeed);


            //If it does, call the collect method
            collectible.Collect();
        }
    }
}
