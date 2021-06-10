using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHandler : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    float addToPlayerPos = 1.15f;        //ani collisionlari onlemek icin ufak offsetler verdim
    [SerializeField]
    float distanceBetweenLastChild = 1.05f;

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
            gameObject.GetComponent<Rigidbody>().isKinematic = false;

            //Destroy(gameObject);
        }

        if (collision.transform.gameObject.CompareTag(Tags.powerupCubeTag) && transform.gameObject.CompareTag(Tags.mainCubeTag))
        {
            Transform go = collision.transform;
            go.gameObject.tag = Tags.mainCubeTag;

            //stackleyecegimiz cube icin tum playeri kaldirarak yer aciyoruz
            float playerPosY = player.transform.position.y;
            playerPosY = playerPosY + addToPlayerPos;
            player.transform.position = new Vector3(player.transform.position.x, playerPosY, player.transform.position.z);
            
            go.parent = player.transform;

            //son child in hemen altina eklemeyi yapiyoruz (childcount -1 cunku son child, henuz stacklemedigimiz cube)
            float posgoY = player.transform.GetChild(player.transform.childCount - 1).transform.localPosition.y;
            posgoY = posgoY - distanceBetweenLastChild;

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
