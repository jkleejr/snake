using UnityEngine;

public class food : MonoBehaviour
{
    public BoxCollider2D gridSpace;

    private void Start()
    {
        RandomizePosition();        // spawn
    }

    private void RandomizePosition()
    {
        Bounds bounds = this.gridSpace.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);    // align to grid
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "p1") {
            RandomizePosition();    // re randomize position
        }
    }
}

