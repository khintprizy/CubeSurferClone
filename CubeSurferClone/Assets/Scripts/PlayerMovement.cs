using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float dragSpeed = 10f;

    private Vector2 lastTapPos;

    Rigidbody playerRb;
    GameManager gameManager;

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

    private static PlayerMovement _instance;
    public static PlayerMovement instance
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
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameManager.instance;
    }

    private void FixedUpdate()
    {
        //Vector3 tempVect = new Vector3(0, 0, 1);                            //rb.moveposition ile hareket
        //tempVect = tempVect.normalized * speed * Time.fixedDeltaTime;
        //playerRb.MovePosition(transform.position + tempVect);

        playerRb.velocity = transform.forward.normalized * _speed * Time.fixedDeltaTime * 20;     //rb velocity ile hareket
        //DragHandler();
        DragController();
    }

    private void Update()
    {
        //transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime);      //Translate ile hareket
        
        //playerRb.velocity = new Vector3(playerRb.velocity.x, playerRb.velocity.y, _speed * 20) * Time.deltaTime;
    }

    void DragHandler()
    {
        if (Input.GetMouseButton(0))
        {
            if (gameManager.isGameOver)
            {
                return;
            }

            //playerRb.velocity = Vector3.forward.normalized * _speed * Time.fixedDeltaTime * 20;

            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = currentTapPos;
            }

            float delta = lastTapPos.x - currentTapPos.x;
            lastTapPos = currentTapPos;

            //playerRb.velocity = new Vector3(-1, 0, 0).normalized * dragSpeed * delta * Time.deltaTime * 20;
            transform.Translate(Vector3.left.normalized * dragSpeed * delta/4 * Time.fixedDeltaTime);

            float posX = Mathf.Clamp(transform.position.x, -2.75f, 2.75f);
            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }
    }

    void DragController()
    {
        if (Input.GetMouseButton(0))
        {
            if (gameManager.isGameOver)
            {
                return;
            }

            float mouseX = Input.GetAxisRaw("Mouse X");
            transform.Translate(Vector3.left.normalized * dragSpeed * -mouseX * Time.fixedDeltaTime);

        }
    }
}
