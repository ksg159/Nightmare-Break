using UnityEngine;
using System.Collections;

public class SwordDance : MonoBehaviour 
{
<<<<<<< HEAD

	public CharacterStatus charStatus;
=======
    
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public CharacterManager charManager;
	public GameObject character;
	public int bladeStormDamage=1;
	public float bladeStormSpeed = 20;
	public Rigidbody bladeStromRigid;
	public GameObject swordDanceEffect;
	int skillLv;

	// Use this for initialization
	void Start ()
	{
		character = GameObject.FindWithTag ("Player");
		charManager = character.GetComponent<CharacterManager> ();
<<<<<<< HEAD
		charStatus = charManager.CharStatus;
		bladeStromRigid = GetComponent<Rigidbody> ();
		bladeStromRigid.velocity = transform.forward * bladeStormSpeed;
		swordDanceEffect = Resources.Load<GameObject> ("Effect/SwordShadow");
		skillLv = charStatus.SkillLevel [2];
		bladeStormDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)charStatus.HClass, 3).GetSkillData (skillLv).SkillValue)*  charStatus.Attack);
=======
		bladeStromRigid = GetComponent<Rigidbody> ();
		bladeStromRigid.velocity = transform.forward * bladeStormSpeed;
		swordDanceEffect = Resources.Load<GameObject> ("Effect/SwordShadow");
		skillLv = CharacterStatus.Instance.SkillLevel [2];
		bladeStormDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)CharacterStatus.Instance.HClass, 3).GetSkillData (skillLv).SkillValue)* CharacterStatus.Instance.Attack);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	}
	void Update()
	{
		if (!swordDanceEffect)
		{
			Debug.Log ("In danceDes");
			Destroy (this.gameObject);
		}
	}
	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Enermy"))
		{
			Debug.Log (skillLv);
			Debug.Log (bladeStormDamage);

			Monster monsterDamage = coll.gameObject.GetComponent<Monster> ();

			if (monsterDamage != null)
			{	
				monsterDamage.HitDamage (bladeStormDamage,character );
				bladeStormDamage = 0;
			}
		}
	}
}
