﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    public int flagShipLive;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        flagShipLive = 0;

    }

    void Update()
    {
        if (transform.position.z < -7)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("EnemyFlagShip"))
        {

            return;

        }
        flagShipLive = flagShipLive + 1;


        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.CompareTag("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.AddScore(scoreValue);
        Destroy(other.gameObject);

        if (CompareTag("Enemy") || (CompareTag("EnemyFlagShip") && flagShipLive == 3))
        {
            Destroy(gameObject);
        }

    }

}
