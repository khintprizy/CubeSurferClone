using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private int cubeCount;

    Vector3 unitVector;

    private static CameraController _instance;
    public static CameraController instance
    {
        get
        {
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        player = PlayerMovement.instance.gameObject;
        offset = transform.position - player.transform.position;

        ChangeZoom();
    }

    private void LateUpdate()
    {
        Vector3 pos = player.transform.position + offset - unitVector;
        pos.y = 13f + cubeCount/2;                 // y ekseninde kamera sabit

        // Lerp kullaninca zoom in ve zoom out daha smooth gerceklesiyor
        transform.position = Vector3.Lerp(transform.position, pos, .3f);
    }

    //asagidaki fonksiyonu ne zaman cubeCount degisse cagiracagiz
    public void ChangeZoom()
    {
        cubeCount = player.transform.childCount;
        unitVector = transform.forward * cubeCount;
    }
}
