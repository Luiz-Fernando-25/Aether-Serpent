using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Vector2 direction;

    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0)
            direction = Vector2.right * xAxis;
        if (yAxis != 0)
            direction = Vector2.up * yAxis;         
    }

    private void FixedUpdate()
    {
        moveSnake();
    }
    void moveSnake()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y);
    }
}
