using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "DestroyerCube")
        {
            if (collision.collider != null)
            {
                collision.collider.enabled = false;
            }
            //gameObject.transform.parent = null;
            /*float playerPosY = player.transform.position.y;
            playerPosY = playerPosY - 1f;
            player.transform.position = new Vector3(player.transform.position.x, playerPosY, player.transform.position.z);*/
            Destroy(gameObject);
        }

        if (collision.transform.gameObject.tag == "PowerUp" && transform.gameObject.tag == "MainCube")
        {
            Transform go = collision.transform;
            go.gameObject.tag = "MainCube";

            float playerPosY = player.transform.position.y;
            playerPosY = playerPosY + 1.1f;
            player.transform.position = new Vector3(player.transform.position.x, playerPosY, player.transform.position.z);
            go.parent = player.transform;

            float posgoY = -(player.transform.childCount - 1.31f);
            go.localPosition = new Vector3(0, posgoY, 0);
        }

        if (collision.transform.gameObject.tag == "Coin")
        {
            GameManager.singleton.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}
