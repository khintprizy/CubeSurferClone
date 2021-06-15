using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.destroyerCubeTag) || collision.gameObject.CompareTag(Tags.lavaSurfaceTag) || collision.gameObject.CompareTag(Tags.roadTag))
        {
            GameManager.instance.GameWin();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag(Tags.multiplierTag))
        {
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            player.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            UIManager.instance.CalculateAndAddToTotal(collision.transform.GetComponent<ScoreMultiplier>().multiplyValue);
            GameManager.instance.GameWin();
        }
    }
}
