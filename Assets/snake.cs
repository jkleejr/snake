using UnityEngine;

public class snake : MonoBehaviour
{
    private Vector2 snake_direction = Vector2.right;    // by default snake will move right

    private void Update()       // every frame on game object
    {
        if(Input.GetKeyDown(KeyCode.W)) {
            snake_direction = Vector2.up; 
        }
        else if(Input.GetKeyDown(KeyCode.A)) {
            snake_direction = Vector2.left;
        }
        else if(Input.GetKeyDown(KeyCode.S)) {
            snake_direction = Vector2.down;
        }
        else if(Input.GetKeyDown(KeyCode.D)) {
            snake_direction = Vector2.right;
        }

    }

    private void FixedUpdate()      // snake movement
    {
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + snake_direction.x,
            Mathf.Round(this.transform.position.y) + snake_direction.y,
            0.0f
        );
    }

}
