using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;
    public float speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value;
        }
    }


    [SerializeField]
    private float dragSpeed = 1f;

    private Vector2 lastTapPos;

    Rigidbody playerRb;

    public static PlayerMovement instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        playerRb.velocity = Vector3.forward * _speed * Time.deltaTime * 20;
    }

    private void Update()
    {
        //transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime);

        DragHandler();

        float posX = Mathf.Clamp(transform.position.x, -2.75f, 2.75f);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

    void DragHandler()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = currentTapPos;
            }

            float delta = lastTapPos.x - currentTapPos.x;
            lastTapPos = currentTapPos;

            transform.Translate(Vector3.left.normalized * dragSpeed * delta * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }
}
