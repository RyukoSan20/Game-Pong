using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
	public float initialForceX;
	public float initialForceY;

	private Rigidbody2D rigidbody2D;

	private Vector2 trajectoryOrigin;
	// Start is called before the first frame update
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
		RestartBall();
		trajectoryOrigin = transform.position;
	}

	public void ResetBall()
	{
		transform.position = Vector2.zero;
		rigidbody2D.velocity = Vector2.zero;
	}

	public void PushBall()
	{
		float randomInitialForceY = Random.Range(-initialForceY, initialForceY);

		int direction = Random.Range(0, 2);

		if (direction < 1.0f)
		{
			rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(-initialForceX, randomInitialForceY), 10.0f);
		}
		else
		{
			rigidbody2D.velocity = Vector2.ClampMagnitude(new Vector2(initialForceX, randomInitialForceY), 10.0f);
		}
	}

	public void RestartBall()
	{
		ResetBall();

		Invoke("PushBall", 2);
	}

	// Debug methods
	private void OnCollisionExit2D(Collision2D other)
	{
		trajectoryOrigin = transform.position;
	}

	public Vector2 TrajectoryOrigin
	{
		get { return trajectoryOrigin; }
	}
}
