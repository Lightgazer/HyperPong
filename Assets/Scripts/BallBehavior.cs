using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    void Awake()
    {
        Debug.Log(transform);
        // body = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Player Wall") {
			Debug.Log("!!!");
		}
    }
}
