﻿using UnityEngine;
using System.Collections;

public class Magic_Meteor : MonoBehaviour {

	public GameObject meteorEffect;
	private float time;
	private float timeInterval;
	private float currentTime;
    Vector3 pos;

    void Start()
	{
		timeInterval = 0.1f;
		currentTime = 0;
		time = 2.0f;
    
        StartCoroutine(meteorBurst());
	}

	IEnumerator meteorBurst()
	{
        GameObject[] meteor = new GameObject[15];
      //  while (currentTime < time) {
            for (int i = 0; i < meteor.Length; i++)
            {
            pos = new Vector3(transform.parent.position.x + Random.Range(-3, 3), transform.parent.position.y + Random.Range(-3, 3), transform.parent.position.z);
<<<<<<< HEAD
            meteor[i] = Instantiate(meteorEffect, pos, transform.rotation) as GameObject;
=======
			meteor[i] = Instantiate(meteorEffect, pos, transform.rotation) as GameObject;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
                yield return new WaitForSeconds(timeInterval);
            }
          //  yield return new WaitForSeconds(0.5f);
          //  currentTime += 0.5f;
    //    }
       // currentTime = 0;
        Destroy(transform.parent.gameObject);

	}
}
