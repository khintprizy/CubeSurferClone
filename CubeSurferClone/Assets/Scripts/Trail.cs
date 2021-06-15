using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    GameObject player;
    GameObject theLastChild;
    private Vector3 offsetFromGround;
    private int totalChildCount;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        offsetFromGround = new Vector3(0, 0.15f, 0);
        totalChildCount = player.transform.childCount;
    }

    void Update()
    {
        totalChildCount = player.transform.childCount;

        if (GameManager.instance.isGameOver || totalChildCount < 3)
        {
            transform.gameObject.SetActive(false);
            return;
        }

        theLastChild = player.transform.GetChild(totalChildCount - 1).gameObject;



        transform.position = theLastChild.transform.position + offsetFromGround;

    }
}
