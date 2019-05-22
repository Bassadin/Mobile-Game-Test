using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;

    float spritePixelWidth;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spritePixelWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 positionVector = transform.position;
        Vector2 moveVector = Vector2.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            float targetXCoordinate = touchPosition.x;

            if (targetXCoordinate > transform.position.x)
            {
                moveVector = new Vector2(1, 0);
            } else
            {
                moveVector = new Vector2(-1, 0);
            }

        } else
        {
            moveVector = new Vector2(Input.GetAxis("Horizontal"), 0);
        }

        if (moveVector.sqrMagnitude != 0)
        {
            Vector2 position = rigidbody2D.position;
            position += moveVector * speed * Time.deltaTime;
            rigidbody2D.MovePosition(position);
        }
    }
}
