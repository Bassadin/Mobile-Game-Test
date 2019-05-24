using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public const float shootingSpeed = 0.35f;
    public GameObject bulletPrefab;

    float spritePixelWidth;
    float shootingTimer;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        ResetShootingTimer();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spritePixelWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Shooting();
        MovePlayer();
    }

    private void Shooting()
    {
        if (Input.GetKey(KeyCode.Space) || Input.touchCount > 0)
        {
            if (shootingTimer <= float.Epsilon)
            {
                GameObject newBullet = Instantiate(bulletPrefab, rigidbody2D.position + Vector2.up * 0.5f, Quaternion.identity);
                newBullet.GetComponent<Bullet>().Launch();

                shootingTimer = shootingSpeed;
            }
            shootingTimer -= Time.deltaTime;
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            ResetShootingTimer();
        }
    }

    private void ResetShootingTimer() {
        shootingTimer = 0;
    }

    private void MovePlayer()
    {
        Vector2 positionVector = transform.position;
        Vector2 moveVector = Vector2.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            float targetXCoordinate = touchPosition.x;
            moveVector = new Vector2(targetXCoordinate > transform.position.x ? 1 : -1, 0);

        }
        else
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
