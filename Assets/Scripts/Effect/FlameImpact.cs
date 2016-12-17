using UnityEngine;
using System.Collections;

public class FlameImpact : MonoBehaviour 
{
	public ParticleSystem FireBallparticleSystem;
<<<<<<< HEAD
	public CharacterStatus charStatus;
=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public CharacterManager charManager;
	public GameObject character;
	public int flameImpactDamage;
	AudioSource ringSound;
	public AudioClip ringClipSound;
	int skillLv;
	// Use this for initialization
	void Start () 
	{
		character = GameObject.FindWithTag ("Player");
		charManager = character.GetComponent<CharacterManager> ();
<<<<<<< HEAD
		charStatus = charManager.CharStatus;
		skillLv = charStatus.SkillLevel [0];
		ringSound = this.gameObject.GetComponent<AudioSource> ();
		flameImpactDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)charStatus.HClass, 1).GetSkillData (skillLv).SkillValue)*  charStatus.Attack);
=======
		skillLv = CharacterStatus.Instance.SkillLevel [0];
		ringSound = this.gameObject.GetComponent<AudioSource> ();
		flameImpactDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)CharacterStatus.Instance.HClass, 1).GetSkillData (skillLv).SkillValue)* CharacterStatus.Instance.Attack);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Enermy"))
		{
			Debug.Log ("in monster");
			Monster monsterDamage = coll.gameObject.GetComponent<Monster> ();

			if (monsterDamage != null)
			{	
				monsterDamage.HitDamage (flameImpactDamage,character );
				flameImpactDamage = 0;
			}

			Destroy(gameObject);
			//Instantiate(Resources.Load<GameObject>("Effect/MeteorExplosion"), this.transform.position, Quaternion.identity);

		}

	}
}
