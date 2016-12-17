using UnityEngine;
using System.Collections;

public class SwordShadow : MonoBehaviour 
{
<<<<<<< HEAD
	public CharacterStatus charStatus;
=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	public CharacterManager charManager;
	public GameObject character;
	int swordShadowDamage;
	int skillLv;


	// Use this for initialization
	void Start () 
	{
		character = GameObject.FindWithTag ("Player");
		charManager = character.GetComponent<CharacterManager> ();
<<<<<<< HEAD
		charStatus = charManager.CharStatus;
		skillLv = charStatus.SkillLevel [1];
		swordShadowDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)charStatus.HClass, 2).GetSkillData (skillLv).SkillValue)*  charStatus.Attack);
=======
		skillLv = CharacterStatus.Instance.SkillLevel [1];
		swordShadowDamage =(int) ((SkillManager.instance.SkillData.GetSkill ((int)CharacterStatus.Instance.HClass, 2).GetSkillData (skillLv).SkillValue)* CharacterStatus.Instance.Attack);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	}	
	// Update is called once per frame


	void OnTriggerEnter(Collider coll)
	{

		Debug.Log (swordShadowDamage);
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Enermy"))
		{
			Monster monsterDamage = coll.gameObject.GetComponent<Monster> ();
			if (monsterDamage != null)
			{	
				monsterDamage.HitDamage (swordShadowDamage,character );
				swordShadowDamage = 0;
			}
		}
	}
}
