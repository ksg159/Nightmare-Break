using UnityEngine;
using System.Collections;

public class EspadaSwordEffect : MonoBehaviour
{
    ParticleSystem myParticle;
	GameObject giganticSword;
	public Renderer rend;
	public bool count;
<<<<<<< HEAD
	public CharacterStatus charStatus;
	public CharacterManager charManager;
	float giganticSwordAliveTime;
	public GameObject character;
=======
	public CharacterManager charManager;
	float giganticSwordAliveTime;
	public GameObject character;
	public GameObject swordEffect;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public int swordDamage;
	public AudioSource swordSound;
	public AudioClip swordSummonSound;
	public AudioClip swordFinishSound;

	public Rigidbody giganticSwordRigd;
	public float swordSpeed;

    void Start()
    {
		count = true;
       // myParticle = transform.GetChild(0).GetComponent<ParticleSystem>();
		character = GameObject.FindWithTag ("Player");
		swordSound = this.gameObject.GetComponent<AudioSource> ();
		swordSummonSound =  Resources.Load<AudioClip> ("Sound/WarriorEffectSound/GiganticSwordSummonEffectSound");
		swordFinishSound = Resources.Load<AudioClip> ("Sound/WarriorEffectSound/GiganticSwordFinishEffectSound");
		charManager = character.GetComponent<CharacterManager> ();
		giganticSwordRigd = GetComponent<Rigidbody> ();
		swordSpeed = 40;
		giganticSwordRigd.velocity = (transform.forward* swordSpeed);
<<<<<<< HEAD

        charStatus = charManager.CharStatus;
		giganticSword = this.gameObject;
		swordSound.volume = 0.1f;
		rend = GetComponent<Renderer> ();
		StartCoroutine(EffectMove());
		swordSound.PlayOneShot (swordSummonSound);
		Destroy (this.gameObject, 3.0f);
	}

    IEnumerator EffectMove()
    {
        while (myParticle.isPlaying)
        {
            myParticle.gameObject.transform.Translate(0, 0, 4 * Time.deltaTime, Space.Self);

            yield return null;
        }
    }

=======
		swordDamage = 10000;
		giganticSword = this.gameObject;
		swordSound.volume = 0.1f;
		rend = GetComponent<Renderer> ();
		swordSound.PlayOneShot (swordSummonSound);
		Destroy (this.gameObject, 3.0f);
	}
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    void OnCollisionEnter(Collision coll)
    {
		
        if (coll.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
<<<<<<< HEAD
			Instantiate(Resources.Load<GameObject>("Effect/SwordExplosion"), transform.position, Quaternion.identity);
=======
			swordEffect =Instantiate(Resources.Load<GameObject>("Effect/SwordExplosion"), transform.position,new Quaternion(90,-90,0,0))as GameObject;

			Destroy (swordEffect, 2.5f);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
			count = false;
			swordSound.PlayOneShot (swordFinishSound);
			Debug.Log ("in Field");
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
				Debug.Log (character);

				monsterDamage.HitDamage (swordDamage,character );
				swordDamage = 0;

			}
		}
	}

}