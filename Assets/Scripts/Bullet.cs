using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // death support
    const float LifeSeconds = 1;
    Timer deathTimer;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
	{
		// create and run death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = LifeSeconds;
        deathTimer.Run();
	}
	
	void Update()
	{
		// kill bullet when timer is done
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
	}

    // <param name="forceDirection">force direction</param>
    public void ApplyForce(Vector2 forceDirection)
    {
        const float forceMagnitude = 10;
        GetComponent<Rigidbody2D>().AddForce(
            forceMagnitude * forceDirection,
            ForceMode2D.Impulse);
    }
}
