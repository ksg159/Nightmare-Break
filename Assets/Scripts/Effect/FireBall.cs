using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

  	public ParticleSystem FireBallparticleSystem;
<<<<<<< HEAD
	public CharacterStatus charStatus;
=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public CharacterManager charManager;
	public GameObject character;
	public int FireBallDamage;
	public float FireBallSpeed = 180;
	public Rigidbody FireBallRigid;

	int skillLv;
	AudioSource fireBallSound;
	AudioClip flyingBall;
    void Start()
    {
		character = GameObject.FindWithTag ("Player");
<<<<<<< HEAD
		charManager = character.GetComponent<CharacterManager> ();
		charStatus = charManager.CharStatus;
=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
		FireBallRigid = GetComponent<Rigidbody> ();
		FireBallRigid.velocity = transform.forward* FireBallSpeed;
		fireBallSound =this.gameObject.GetComponent<AudioSource> ();

		flyingBall = Resources.Load<AudioClip> ("Sound/MageEffectSound/MeteorDropSound");

		fireBallSound.PlayOneShot (flyingBall);

		FireBallparticleSystem = GetComponent<ParticleSystem>();
<<<<<<< HEAD
		skillLv = charStatus.SkillLevel [0];
		FireBallDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)charStatus.HClass, 1).GetSkillData (skillLv).SkillValue)*  charStatus.Attack);
=======
		skillLv = CharacterStatus.Instance.SkillLevel [0];
		FireBallDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)CharacterStatus.Instance.HClass, 1).GetSkillData (skillLv).SkillValue)* CharacterStatus.Instance.Attack);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
		Destroy (this.gameObject, 0.45f);
	}

    void Update()
    {
		FireBallparticleSystem.Simulate(1.5f, true);
    }

	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.layer == LayerMask.NameToLayer("Map"))
		{
			Destroy(gameObject);
			Instantiate(Resources.Load<GameObject>("Effect/MeteorExplosion"), coll.contacts[0].point, Quaternion.identity);
		}

	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Enermy"))
		{
			Debug.Log ("in monster");
			Monster monsterDamage = coll.gameObject.GetComponent<Monster> ();

			if (monsterDamage != null)
			{	
				monsterDamage.HitDamage (FireBallDamage,character );
				FireBallDamage = 0;
			}

			Destroy(gameObject);
			Instantiate(Resources.Load<GameObject>("Effect/MeteorExplosion"), this.transform.position, Quaternion.identity);

		}
	}

}
