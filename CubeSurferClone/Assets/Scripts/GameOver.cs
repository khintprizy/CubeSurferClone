using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //public bool isGameOver;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DestroyerCube" || collision.gameObject.tag == "LavaSurface" || collision.gameObject.tag == "Ground")
        {
            GameManager.singleton.Failed();
        }
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        
    }


}
