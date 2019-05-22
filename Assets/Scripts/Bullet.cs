using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float bulletSpeed = 10.0f;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        rigidbody2D.AddForce(new Vector2(0, 1) * bulletSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("BulletCleanupWall"))
        {
            Debug.Log(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
