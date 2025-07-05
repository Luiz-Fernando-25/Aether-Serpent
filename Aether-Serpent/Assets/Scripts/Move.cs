using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] List<Transform> snakeBodies;
    [SerializeField] Transform body;

    private void Start()
    {
        snakeBodies = new List<Transform>();
        snakeBodies.Add(transform);
    }


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
        for (int i = snakeBodies.Count - 1; i > 0; i--)
        {
            snakeBodies[i].position = snakeBodies[i - 1].position;
        }
        moveSnake();
    }
    void moveSnake()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y);
    }

    void GrowingSnake()
    {
        Transform SpawnBody = Instantiate(body, snakeBodies[snakeBodies.Count - 1].position, Quaternion.identity);
        snakeBodies.Add(SpawnBody);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Food":
                GrowingSnake();
                break;
        }
    }
}
