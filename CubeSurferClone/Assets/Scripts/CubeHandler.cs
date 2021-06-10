using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.CompareTag(Tags.destroyerCubeTag))
        {
            if (collision.collider != null)
            {
                collision.collider.enabled = false;
            }
            gameObject.transform.parent = null;

            //Destroy(gameObject);
        }

        if (collision.transform.gameObject.CompareTag(Tags.powerupCubeTag) && transform.gameObject.CompareTag(Tags.mainCubeTag))
        {
            Transform go = collision.transform;
            go.gameObject.tag = Tags.mainCubeTag;

            float playerPosY = player.transform.position.y;
            playerPosY = playerPosY + 1.1f;
            player.transform.position = new Vector3(player.transform.position.x, playerPosY, player.transform.position.z);
            go.parent = player.transform;

            float posgoY = -(player.transform.childCount - 1.31f);
            go.localPosition = new Vector3(0, posgoY, 0);
        }

        if (collision.transform.gameObject.CompareTag(Tags.coinTag))
        {
            UIManager.instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}
