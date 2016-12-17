using UnityEngine;
using System.Collections;

public class SceneChangeObject : MonoBehaviour {
<<<<<<< HEAD
	public DungeonManager dungeonManager;
=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public GameObject[] Players;
	public int lookAtSceneNumber;
	public GameObject sceneObject;
	public int ColliderEnterCount;


//	public void SceneChangeObjectSet(GameObject[] _Players, int playerLength){
//		Players = new GameObject[playerLength];
//		Players = _Players;
//		sceneObject = this.gameObject;
//		ColliderEnterCount = 0;
<<<<<<< HEAD
//		dungeonManager = transform.GetComponentInParent<DungeonManager>();
//	}

	public void SceneChangeObjectSet(int _number){
		dungeonManager = transform.parent.GetComponent<DungeonManager>();
=======
//		DungeonManager.Instance = transform.GetComponentInParent<DungeonManager>();
//	}

	public void SceneChangeObjectSet(int _number){
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
		//Players = new GameObject[playerLength];
		//Players = _Players;
		sceneObject = this.gameObject;
		ColliderEnterCount = 0;
		lookAtSceneNumber = _number;

		sceneObject.SetActive (false);
	}




	
	public void OnTriggerEnter(Collider coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			ColliderEnterCount+=1;

			if (lookAtSceneNumber != 4) {
				if (ColliderEnterCount == 4) {
<<<<<<< HEAD
					dungeonManager.SceneChange ();
=======
					DungeonManager.Instance.SceneChange ();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
				}
			}
		}
	}

	public void OnTriggerExit(Collider coll){
		if(coll.gameObject.layer == LayerMask.NameToLayer("Player")){
			ColliderEnterCount -= 1;
		}
	}
}
