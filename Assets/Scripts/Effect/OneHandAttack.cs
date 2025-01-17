﻿using UnityEngine;
using System.Collections;

public class OneHandAttack : MonoBehaviour 
{
	public Monster monster;
	int damage;
	public Rigidbody sphereRigid;
	public float sphereSpeed;
	// Use this for initialization
	public GameObject player;
	public Vector3 playerpos;

	public bool chase;
	void Start () 
	{
	//	monster = 
		damage = 10;
		StartCoroutine (SpherePosUp());
		sphereRigid = GetComponent<Rigidbody> ();
		sphereSpeed = 12;
		sphereRigid.velocity = transform.up * sphereSpeed;
		player = GameObject.FindGameObjectWithTag ("Player");
		chase = false;

	}


	IEnumerator SpherePosUp()
	{
		yield return new WaitForSeconds (1f);
		sphereRigid.velocity = transform.up * 0;
		playerpos = player.transform.position;
		playerpos.y = 0;
		chase = true;

		StartCoroutine (SphereChase());
	}

	IEnumerator SphereChase()
	{
		while(chase)
		{
			yield return null;

			transform.Translate ((playerpos - this.transform.position) * (sphereSpeed-7 )* Time.deltaTime);
			if (Vector3.Distance (transform.position, playerpos) < 0.5f)
			{
				chase = false;
				//Destroy (gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{
//		transform.Translate (playerpos*(sphereSpeed-5)*Time.deltaTime));
	}


	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Map"))
		{
//			Instantiate (Resources.Load<GameObject> ("Effect/Test"), transform.position, Quaternion.Euler (0, 0, 0));
			Destroy (gameObject);
		}

	}
}
