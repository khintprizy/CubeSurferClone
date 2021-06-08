using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float dragSpeed = 1f;

    private Vector2 lastTapPos;

    private void Update()
    {
        transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime);

        DragHandler();

        if (transform.position.x > 2.75f)
        {
            transform.position = new Vector3(2.75f, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -2.75f)
        {
            transform.position = new Vector3(-2.75f, transform.position.y, transform.position.z);
        }
    }

    void DragHandler()
    {
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
