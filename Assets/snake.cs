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

    // iterate in reverse order, update the head last
    // first segment moves to next position
    // segments follow the one in front
    private void FixedUpdate()
    {
        for(int i = snake_body.Count -1; i > 0; i--) 
        {
            snake_body[i].position = snake_body[i - 1].position;
        }
        
        // snake movement
        this.transform.position = new Vector3 (
            Mathf.Round(this.transform.position.x) + p1_direction.x,
            Mathf.Round(this.transform.position.y) + p1_direction.y,
            0.0f );
    }
    
    private void Grow()
    {
        Transform segment = Instantiate(this.snake_prefab); 
        // new position at end of snake body
        segment.position = snake_body[snake_body.Count - 1].position;

        snake_body.Add(segment);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "food") {
            Grow();
        }
    }

}
