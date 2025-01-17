﻿using UnityEngine;
using System.Collections;

public class WarriorManager : CharacterManager
{
	//GiganticSword
	public GameObject GiganticSword;
	public float giganticSwordSpeed;
	public GameObject giganticSwordTemp;

	public GameObject SwordDance;
	public bool rise = false;
	public CharWeapon bloodingWeapon;
	public float riseCooltime;
    private GameObject wind;
    [SerializeField]
    private TrailRenderer trailRenderer;
    private GameObject[] attackEffect;
	int skillLv;
	public AudioClip swordFinishSound;
	public AudioClip giganticSwordFinishSound;
	public EspadaSwordEffect espadasword;
	public bool poweroverwhelming;

	public override void NormalAttack ()
	{
		base.NormalAttack ();
	}

	public override void SetClassObject ()
	{
        attackEffect = new GameObject[3];
        
        for(int i=0; i<attackEffect.Length;i++)
        {
            attackEffect[i] = Resources.Load<GameObject>("Effect/WarriorNormalAttack" + (i + 1));
        }
	}

<<<<<<< HEAD
	public override void SetCharacterType ()
	{
		charStatus.HClass = CharacterStatus.CharClass.Warrior;
	}
=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	//warrior mealstrom
	public override void ProcessSkill1 ()
	{
		float maelstromSpeed = 0.5f;
		float maelstromDistance;
        skillTime += Time.deltaTime;
<<<<<<< HEAD
        if (!wind)
        {
     	   wind = Instantiate(Resources.Load<GameObject>("Effect/Wind"), new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity) as GameObject;
			wind.transform.parent = this.gameObject.transform;
        }

		//transform.Translate ((Vector3.forward * testinput.vertical - Vector3.right * testinput.horizontal) * Time.deltaTime * (charStatus.MoveSpeed -6.0f), Space.World);
=======

		transform.Translate ((Vector3.forward * testinput.vertical - Vector3.right * testinput.horizontal) * Time.deltaTime * (CharacterStatus.Instance.MoveSpeed-5f), Space.World);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308


        if (enermy != null)
		{
			for (int i = 0; i < enermy.Length; i++)
			{
				if (enermy [i] != null)
				{
					maelstromDistance = Vector3.Distance (this.transform.position, enermy [i].transform.position);
                
					if (maelstromDistance < 10)
					{
						enermy [i].transform.Translate ((this.transform.position - enermy [i].transform.position) * maelstromSpeed * Time.deltaTime, Space.World);
					}
				}
			}
		}

		if (skillTime >= 1.5f)
		{
			skillTime = 0;
		}

	}
<<<<<<< HEAD
=======
	public void WindEffect()
	{
		wind = Instantiate(Resources.Load<GameObject>("Effect/Wind"), new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity) as GameObject;
		wind.transform.parent = this.gameObject.transform;
	}
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

	//Warrior Cutoff
	public override void ProcessSkill2 ()
	{
		skillTime += Time.deltaTime;


			animator.speed = 1;
			skillTime = 0;


	}

	public override void ProcessSkill3 ()
	{

	}

	public override void ProcessSkill4 ()
	{

	}

	public void SwordDanceEffect()
	{
		if (!SwordDance)
		{
<<<<<<< HEAD
			if (transform.rotation.y == 0)
=======
			if (charDir)
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
			{
				SwordDance = Instantiate (Resources.Load<GameObject> ("Effect/SwordDance"), new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z + 0.5f), Quaternion.Euler (-90, 0, 0)) as GameObject;
			}
			else
			{
				SwordDance = Instantiate (Resources.Load<GameObject> ("Effect/SwordDance"), new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z - 0.5f), Quaternion.Euler (90, 0, 0)) as GameObject;
			}
		}
	}

	public void CutOffMove ()
	{
		Instantiate (Resources.Load<GameObject> ("Effect/SwordShadow"), new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z), Quaternion.identity);

		Ray cutOffDistance = new Ray (this.transform.position, transform.forward);
		RaycastHit rayHit;

		if (Physics.Raycast (cutOffDistance, out rayHit, 5f, 1 << LayerMask.NameToLayer ("Map")))
		{
			transform.Translate (0, 0, rayHit.distance - 0.5f);

		}
		else
		{
			transform.Translate (0, 0, 5);
		}
	}

	public void CutoffStop ()
	{
		//animator.speed = 0;
	}

	public void SwordDanceBoxSummon ()
	{
		Debug.Log ("DanceSummon");
		Instantiate (Resources.Load<GameObject> ("Effect/SwordDanceBox"), new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

	}

	public void GiganticSwordSummon ()
	{
		float giganticSwordPos;
		if (charDir)
		{
			giganticSwordPos = 7.0f;
		}
		else
		{
			giganticSwordPos = -7.0f;
		}

		giganticSwordTemp = Instantiate (Resources.Load<GameObject> ("GiganticSword"), transform.position + new Vector3 (0.0f, 20.0f, giganticSwordPos), Quaternion.Euler (new Vector3 (90.0f, 90.0f, -180.0f))) as GameObject;
		espadasword = giganticSwordTemp.GetComponent<EspadaSwordEffect> ();
		giganticSwordTemp.gameObject.GetComponent<Rigidbody> ().AddForce (-Vector3.up * giganticSwordSpeed, ForceMode.Impulse);
	}

	public override void HitDamage (int _damage)
	{
		if (!poweroverwhelming)
		{
			
<<<<<<< HEAD
			if (CharStatus.SkillLevel [5] < 4)
=======
			if (CharacterStatus.Instance.SkillLevel [5] < 4)
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
			{
				if (charAlive)
				{
					if (charAlive)
					{
<<<<<<< HEAD
						if (CharStatus.HealthPoint > 0)
						{
							int deFendDamage;
							deFendDamage = _damage - (CharStatus.SkillLevel [5] * 1);
=======
						if (CharacterStatus.Instance.HealthPoint > 0)
						{
							int deFendDamage;
							deFendDamage = _damage - (CharacterStatus.Instance.SkillLevel [5] * 1);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
							Debug.Log (deFendDamage);
							if (deFendDamage < 0)
							{
								deFendDamage = 0;
							}
<<<<<<< HEAD
							CharStatus.DecreaseHealthPoint (deFendDamage);
=======
                            CharacterStatus.Instance.DecreaseHealthPoint (deFendDamage);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

							if (State != CharacterState.Skill1 && State != CharacterState.Skill2 && State != CharacterState.Skill3 && State != CharacterState.Skill4)
							{
								CharState ((int)CharacterState.HitDamage);
							}
						}
<<<<<<< HEAD
						if (CharStatus.HealthPoint <= 0)
=======
						if (CharacterStatus.Instance.HealthPoint <= 0)
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
						{
							CharState ((int)CharacterState.Death);
							charAlive = false;
						}
					}
				}
			}
<<<<<<< HEAD
			else if (CharStatus.SkillLevel [5] == 4)
			{
				Debug.Log (CharStatus.HealthPoint);
				if (charAlive)
				{
					if (CharStatus.HealthPoint > 0)
					{
						int deFendDamage;
						deFendDamage = _damage - (CharStatus.SkillLevel [5] * 1);
=======
			else if (CharacterStatus.Instance.SkillLevel [5] == 4)
			{
				Debug.Log (CharacterStatus.Instance.HealthPoint);
				if (charAlive)
				{
					if (CharacterStatus.Instance.HealthPoint > 0)
					{
						int deFendDamage;
						deFendDamage = _damage - (CharacterStatus.Instance.SkillLevel [5] * 1);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

						if (deFendDamage < 0)
						{
							deFendDamage = 0;
						}
<<<<<<< HEAD
						CharStatus.DecreaseHealthPoint (deFendDamage);
=======
                        CharacterStatus.Instance.DecreaseHealthPoint (deFendDamage);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
	
						CharState ((int)CharacterState.HitDamage);

						if (State != CharacterState.Skill1 && State != CharacterState.Skill2 && State != CharacterState.Skill3 && State != CharacterState.Skill4)
						{
							CharState ((int)CharacterState.HitDamage);
						}
					}
<<<<<<< HEAD
					else if (CharStatus.HealthPoint <= 0)
=======
					else if (CharacterStatus.Instance.HealthPoint <= 0)
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
					{
					
						CharState ((int)CharacterState.Death);

						charAlive = false;

						if (!rise)
						{
							rise = true;
							charAlive = true;
							animator.SetBool ("Rise", false);
							StartCoroutine (colltimeCheck ());
<<<<<<< HEAD
							CharStatus.DecreaseHealthPoint ((-100));
=======
                            CharacterStatus.Instance.DecreaseHealthPoint ((-100));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
					
						}
						else if (rise)
						{
							animator.SetBool ("Rise", true);
						}
					}
				}
			}
		}
	}

	IEnumerator unbeatableCall()
	{
		poweroverwhelming = true;

		//무적시간
		yield return new WaitForSeconds (1f);

		poweroverwhelming = false;
	}

    public void NormalAttackEffect2(int _attackNum)
    {
        if (_attackNum == 0)
        {
            GameObject attack1 = Instantiate(attackEffect[_attackNum], gameObject.transform.position, attackEffect[_attackNum].transform.localRotation) as GameObject;
            attack1.transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y + 1.1f, transform.position.z + 2.7f);
        }
        else if (_attackNum == 1)
        {
            GameObject attack2 = Instantiate(attackEffect[_attackNum], gameObject.transform.position, attackEffect[_attackNum].transform.localRotation) as GameObject;
            attack2.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y + 0.7f, transform.position.z + 2.2f);
        }
        else
        {
            GameObject attack3 = Instantiate(attackEffect[_attackNum], gameObject.transform.position, attackEffect[_attackNum].transform.localRotation) as GameObject;
            attack3.transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z + 2.5f);
        }
    }

    public void AttackEffect(int _attack)
	{
        if(_attack == 0)
        {
       //     trailRenderer.enabled = true;
        } else
        {
//            trailRenderer.enabled = false;
        }
	}

	public IEnumerator colltimeCheck ()
	{
		while (rise)
		{
			riseCooltime += 1f;
			yield return new WaitForSeconds (1f);
			Debug.Log (riseCooltime);
			if (riseCooltime > 10)
			{
				riseCooltime = 0;
				rise = false;
			}
		}
	}

	public override void classSound()
	{
		base.classSound ();

		if (true)
		{
			Skill1Sound = Resources.Load<AudioClip> ("Sound/ManMealStrom");
			Skill2Sound = Resources.Load<AudioClip> ("Sound/ManCutOff");
			Skill3Sound = Resources.Load<AudioClip> ("Sound/ManSwordDance");
			Skill4Sound = Resources.Load<AudioClip> ("Sound/ManGiganticSwordStart");
			giganticSwordFinishSound = Resources.Load<AudioClip> ("Sound/ManGiganticSwordFinish");
			swordFinishSound = Resources.Load<AudioClip> ("Sound/ManSwordDanceFinish");
		}
		else if (false)
		{
			Skill1Sound = Resources.Load<AudioClip> ("Sound/WomanMealStrom");
			Skill2Sound = Resources.Load<AudioClip> ("Sound/WomanCutOff");
			Skill3Sound = Resources.Load<AudioClip> ("Sound/WomanSwordDance");
			Skill4Sound = Resources.Load<AudioClip> ("Sound/WomanGiganticSwordStart");
			giganticSwordFinishSound = Resources.Load<AudioClip> ("Sound/WoManGiganticSwordFinish");

			swordFinishSound = Resources.Load<AudioClip> ("Sound/WomanSwordDanceFinish");
		}

	}

	public void AttackSound1()
	{
		CharAudio.PlayOneShot (attack1);
		weapon.AttackEffectSound1 ();
	}
	public void AttackSound2()
	{
		CharAudio.PlayOneShot (attack2);
		weapon.AttackEffectSound2 ();
	}
	public void AttackSound3()
	{
		CharAudio.PlayOneShot (attack3);
		weapon.AttackEffectSound3 ();
	}
	public void SwordDanceSound()
	{
		CharAudio.PlayOneShot (Skill3Sound);
		weapon.SwordDanceEffectSound ();
	}
	public void MealStromSound()
	{
		CharAudio.PlayOneShot (Skill1Sound);
		weapon.MealstromEffectSound ();
	}
	public void CutOffSound()
	{
		CharAudio.PlayOneShot (Skill2Sound);
		weapon.CutOffEffectSound ();
	}
	public void SwordDanceFinishSound()
	{
		CharAudio.PlayOneShot (swordFinishSound);
		weapon.SwordDanceFinishEffectSound();
	}
	public void GiganticSwordSoundStart()
	{
		CharAudio.PlayOneShot (Skill4Sound);
		weapon.GiganticSwordSound ();
	}
	public void GiganticSwordSoundFinish()
	{
		CharAudio.PlayOneShot (giganticSwordFinishSound);
	}
}
