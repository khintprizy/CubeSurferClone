using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //public bool isGameOver;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DestroyerCube" || collision.gameObject.tag == "LavaSurface")
        {
            Failed();
        }
    }

    public void Failed()
    {
        player.GetComponent<PlayerMovement>().speed = 0;
        Debug.Log("GameOver!!!!!!");
    }
}
