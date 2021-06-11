using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.destroyerCubeTag) || collision.gameObject.CompareTag(Tags.lavaSurfaceTag) || collision.gameObject.CompareTag(Tags.roadTag))
        {
            GameManager.instance.GameEnd();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
    }
}
