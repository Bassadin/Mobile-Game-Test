using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    float spritePixelWidth;

    void Start()
    {
        spritePixelWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            //Set only X position
            float targetXCoordinate = touchPosition.x;
            Vector2 tempVector = transform.position;
            tempVector.x = targetXCoordinate;
            transform.position = tempVector;
        }
    }
}
