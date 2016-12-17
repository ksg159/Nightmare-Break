using UnityEngine;
using System.Collections;

public class MonsterSpawnPoint : MonoBehaviour {

<<<<<<< HEAD
	//public DungeonManager dungeonManager;
=======
	//public DungeonManager DungeonManager.Instance;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public GameObject[] MonsterSpawn;
//	public GameObject[] DuckSpawn;
//	public GameObject[] RabbitSpawn;
//	public GameObject[] BearSpawn;
//	public GameObject[] BlackBearSpawn;
//
//	public int FrogCount;	
//	public int DuckCount;
//	public int RabbitCount;
//	public int BearCount;
//	public int BlackBearCount;
//
//	public Vector3[] spawnVector;
//
//	public int sumMonsterCount;

	public void RespawnPointSend(){
//		spawnVector = new Vector3[spawnVector.Length];
//		for (int i = 0; i < spawnVector.Length; i++) {
//			//spawnVector[i] = spawnVector [i];
//		}
	}

	// Use this for initialization
	public void SpawnMonsterGetting () {
//		sumMonsterCount = RabbitSpawn.Length + DuckSpawn.Length + FrogSpawn.Length;
<<<<<<< HEAD
//		//dungeonManager = GameObject.Find ("DungeonManager").GetComponent<DungeonManager>();
=======
//		//DungeonManager.Instance = GameObject.Find ("DungeonManager").GetComponent<DungeonManager>();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
//		spawnVector = new Vector3[sumMonsterCount];
//		for (int i = 0; i < sumMonsterCount; i++) {
//			if (i < FrogSpawn.Length) {
//				spawnVector [i] = FrogSpawn [i].transform.position;
//			} else if (i < FrogSpawn.Length + DuckSpawn.Length) {
//				spawnVector [i] = DuckSpawn [i - FrogSpawn.Length].transform.position;
//			} else if (i >= FrogSpawn.Length + DuckSpawn.Length) {
//				spawnVector [i] = RabbitSpawn [i - (FrogSpawn.Length + DuckSpawn.Length)].transform.position;
//
//			}
//		}
//		FrogCount = FrogSpawn.Length;
//		DuckCount = DuckSpawn.Length;
//		RabbitCount = RabbitSpawn.Length;
	}

	public void SpawnVectorGetting(){
		
	}

}
