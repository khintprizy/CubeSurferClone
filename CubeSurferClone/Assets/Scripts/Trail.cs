using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    GameObject player;
    GameObject theLastChild;
    private Vector3 offsetFromGround;
    private int totalChildCount;

    GameManager gameManager;

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        gameManager = GameManager.instance;
        offsetFromGround = new Vector3(0, 0, 0.15f);    // yerden biraz yuksekte durunca daha iyi gorunuyor
        totalChildCount = player.transform.childCount;

        CalculateTrailPosition(1);
    }

    void Update()
    {
        //totalChildCount = player.transform.childCount;

        if (gameManager.isGameOver || totalChildCount < 3)
        {
            transform.gameObject.SetActive(false);
            return;
        }

        //theLastChild = player.transform.GetChild(totalChildCount - 1).gameObject;
        //transform.position = theLastChild.transform.position + offsetFromGround;
    }

    //cube sayisi degistiginde diger scriptlerden cagiracagiz
    public void CalculateTrailPosition(int lastChildCal)
    {
        totalChildCount = player.transform.childCount;

        theLastChild = player.transform.GetChild(totalChildCount - lastChildCal).gameObject;

        transform.parent = theLastChild.transform;
        //transform.localPosition = theLastChild.transform.localPosition + offsetFromGround;
        transform.localPosition = offsetFromGround;
    }
}
