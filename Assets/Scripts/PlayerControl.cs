using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public float speed = 10.0f;
	public float yBoundary = 9.0f;
	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;

	private int score;

	private Rigidbody2D rigidbody2D;

	private ContactPoint2D lastContactPoint;
	// Start is called before the first frame update
	void Start()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Vector2 velocity = rigidbody2D.velocity;

		if (Input.GetKey(upKey))
		{
			velocity.y = speed;
		}
		else if (Input.GetKey(downKey))
		{
			velocity.y = -speed;
		}
		else
		{
			velocity.y = 0.0f;
		}

		rigidbody2D.velocity = velocity;

		Vector3 position = transform.position;

		if (position.y > yBoundary)
		{
			position.y = yBoundary;
		}
		else if (position.y < -yBoundary)
		{
			position.y = -yBoundary;
		}

		transform.position = position;
	}

	public void AddScore()
	{
		score += 1;
	}

	public void ResetScore()
	{
		score = 0;
	}

	public int Score
	{
		get { return score; }
	}

	// Debug methods
	public ContactPoint2D LastContactPoint
	{
		get { return lastContactPoint; }
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Ball")
		{
			lastContactPoint = other.GetContact(0);
		}
	}
}
