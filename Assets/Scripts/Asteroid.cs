﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    Sprite asteroidSprite0;
    [SerializeField]
    Sprite asteroidSprite1;
    [SerializeField]
    Sprite asteroidSprite2;
    
	void Start()
	{
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if (spriteNumber < 1)
        {
            spriteRenderer.sprite = asteroidSprite0;
        }
        else if (spriteNumber < 2)
        {
            spriteRenderer.sprite = asteroidSprite1;
        }
        else
        {
            spriteRenderer.sprite = asteroidSprite2;
        }
	}
	
    /// <param name="direction">direction for the asteroid to move</param>
    /// <param name="position">position for the asteroid</param>
    public void Initialize(Direction direction, Vector3 position)
    {
        // set asteroid position
        transform.position = position;

        // set random angle based on direction
        float angle;
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;
        if (direction == Direction.Up)
        {
            angle = 75 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else if (direction == Direction.Down)
        {
            angle = 255 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }

        // get asteroid moving
        StartMoving(angle);
    }
    
    public void StartMoving(float angle)
    {
        // apply impulse force to get asteroid moving
        const float MinImpulseForce = 1f;
        const float MaxImpulseForce = 3f;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Bullet"))
        {
            AudioManager.Play(AudioClipName.AsteroidHit);
            Destroy(coll.gameObject);

            if (transform.localScale.x < 0.5f)
            {
                Destroy(gameObject);
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.x /= 2;
                scale.y /= 2;
                transform.localScale = scale;

                CircleCollider2D collider = GetComponent<CircleCollider2D>();
                collider.radius /= 2;

                GameObject newAsteroid = Instantiate<GameObject>(gameObject,
                                         transform.position, Quaternion.identity);
                newAsteroid.GetComponent<Asteroid>().StartMoving(
                    Random.Range(0, 2 * Mathf.PI));
                newAsteroid = Instantiate<GameObject>(gameObject,
                    transform.position, Quaternion.identity);
                newAsteroid.GetComponent<Asteroid>().StartMoving(
                    Random.Range(0, 2 * Mathf.PI));
                Destroy(gameObject);
            }
        }
    }

    /// <returns>random direction vector</returns>
    Vector2 GetRandomDirectionVector()
    {
        float angle = Random.Range(0, 2 * Mathf.PI);
        return new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
