using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Rigidbody2D rb;
    bool dropped = false;
    Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if(transform.position.y < -20)
        {
            rb.isKinematic = true;

            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;

            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

            transform.position = startPosition;

            dropped = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.tag == "Player" && dropped == false)
        {
            StartCoroutine(ShakeAndFall(.15f, .25f));

            dropped = true;
        }
    }

    public IEnumerator ShakeAndFall (float duration, float magnitude)
    {

        Vector2 originalPos = transform.position;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector2(transform.position.x + x, transform.position.y);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPos;

        rb.isKinematic = false;

    }
}
