using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private GameObject player;
    Rigidbody playerRb;
    Rigidbody rb;
    GameManager gameManager;
    UIManager uiManager;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        playerRb = player.transform.GetComponent<Rigidbody>();
        rb = transform.GetComponent<Rigidbody>();
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Tags.destroyerCubeTag) || collision.gameObject.CompareTag(Tags.lavaSurfaceTag) || collision.gameObject.CompareTag(Tags.roadTag))
        {
            gameManager.GameFail();
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag(Tags.multiplierTag))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            uiManager.CalculateAndAddToTotal(collision.transform.GetComponent<ScoreMultiplier>().multiplyValue);
            gameManager.GameWin();
        }

        // player yukaridaki multiplierdan hemen once cocugu olan ve kupleri azaltan colliderlara
        // carpabiliyor, onlara carpinca da bi sonraki levela gecebilmesi icin asagidaki scripti uygulamasi lazim
        // carpinca, parenti olan basamaga ulasip ondaki x degerini alarak hesaplamayi yapiyoruz
        if (collision.gameObject.CompareTag(Tags.destroyerOnMultiplier))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            playerRb.constraints = RigidbodyConstraints.FreezeAll;
            gameManager.GameWin();
            uiManager.CalculateAndAddToTotal(collision.transform.parent.GetComponent<ScoreMultiplier>().multiplyValue);
        }
    }
}
