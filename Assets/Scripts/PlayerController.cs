using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

            Vector3 tempVector = transform.position;

            //Set only X position
            tempVector.x = touchPosition.x;
            transform.position = tempVector;
        }
    }
}
