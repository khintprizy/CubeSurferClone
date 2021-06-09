using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSurface : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCube")
        {
            Destroy(other.gameObject);
        }
        /*if (other.gameObject.tag == "PlayerGFX")
        {
            other.GetComponent<GameOver>().Failed();
        }*/
    }
}
