﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;


    void Start()
	{
        // save asteroid radius
        GameObject asteroid = Instantiate<GameObject>(prefabAsteroid);
        CircleCollider2D collider = asteroid.GetComponent<CircleCollider2D>();
        float asteroidRadius = collider.radius;
        Destroy(asteroid);

        float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
        float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        Asteroid script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Left, 
            new Vector2(ScreenUtils.ScreenRight + asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Down, 
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenTop + asteroidRadius));

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Right, 
            new Vector2(ScreenUtils.ScreenLeft - asteroidRadius,
                ScreenUtils.ScreenBottom + screenHeight / 2));

        asteroid = Instantiate<GameObject>(prefabAsteroid);
        script = asteroid.GetComponent<Asteroid>();
        script.Initialize(Direction.Up, 
            new Vector2(ScreenUtils.ScreenLeft + screenWidth / 2,
                ScreenUtils.ScreenBottom - asteroidRadius));
    }
	void Update()
	{
		
	}
}
