using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    [SerializeField]
    private CubeValues values;

    private GameObject player;
    private Rigidbody cubeRb;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        cubeRb = gameObject.GetComponent<Rigidbody>();
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
            cubeRb.constraints = RigidbodyConstraints.FreezeAll;
            

            //Destroy(gameObject);
        }

        if (collision.transform.gameObject.CompareTag(Tags.powerupCubeTag) && transform.gameObject.CompareTag(Tags.mainCubeTag))
        {
            Transform go = collision.transform;
            go.gameObject.tag = Tags.mainCubeTag;

            //------------V2 INCELEMESI UZERINE EKLENDI ----------------------
            //rb ekleniyor
            Rigidbody addedRb = go.gameObject.AddComponent<Rigidbody>();
            addedRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            addedRb.mass = 100;
            addedRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            //script ekleniyor
            CubeHandler addedScript = go.gameObject.AddComponent<CubeHandler>();
            addedScript.values = values;
            //-----------------------------------------------------------------

            //stackleyecegimiz cube icin tum playeri kaldirarak yer aciyoruz
            float playerPosY = player.transform.position.y;
            playerPosY = playerPosY + values.addToPlayerPos;
            player.transform.position = new Vector3(player.transform.position.x, playerPosY, player.transform.position.z);
            
            go.parent = player.transform;

            //son child in hemen altina eklemeyi yapiyoruz (childcount -1 cunku son child, henuz stacklemedigimiz cube)
            float posgoY = player.transform.GetChild(player.transform.childCount - 1).transform.localPosition.y;
            posgoY = posgoY - values.distanceBetweenLastChild;

            go.localPosition = new Vector3(0, posgoY, 0);

            //float posgoY = -(player.transform.childCount - 1.31f);
            //go.localPosition = new Vector3(0, posgoY, 0);
        }

        if (collision.transform.gameObject.CompareTag(Tags.coinTag))
        {
            UIManager.instance.AddScore(1);
            Destroy(collision.gameObject);
        }
    }
}
