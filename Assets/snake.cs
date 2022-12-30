using System.Collections.Generic;
using UnityEngine;

public class snake : MonoBehaviour
{
    private Vector2 p1_direction = Vector2.right;    // by default snake will move right

    private List<Transform> snake_body;     // snake body, list of transforms
    public Transform snake_prefab;          // body prefab in inspector

    // snake body
    private void Start()
    {
        snake_body = new List<Transform>();
        snake_body.Add(this.transform);
    }

    private void Update()       // every frame on game object
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            p1_direction = Vector2.up; 
        }
        else if(Input.GetKeyDown(KeyCode.A)) {
            p1_direction = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.S)) {
            p1_direction = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.D)) {
            p1_direction = Vector2.right;
        }
    }

    // snake movement
    private void FixedUpdate()
    {
        this.transform.position = new Vector3 (
            Mathf.Round(this.transform.position.x) + p1_direction.x,
            Mathf.Round(this.transform.position.y) + p1_direction.y,
            0.0f );
    }

    private void Grow()
    {
        Transform snake_body = Instiantiate(this.snake_prefab); 
        snake_body.position = snake_body[snake_body.Count - 1].position;    // new position at end of snake body
        snake_body.Add(snake_prefab);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "food") {
            Grow();
        }
    }

}
