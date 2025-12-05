using System;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            playerController.AddScore(1); //call add acore function when colliding food with animal
            Destroy(gameObject); //animal
            Destroy(other.gameObject); //food
        }
    }
}