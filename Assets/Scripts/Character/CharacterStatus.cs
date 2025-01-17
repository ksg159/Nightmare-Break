﻿using System.Collections;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public enum Gender
    {
        Male = 0,
<<<<<<< HEAD
        FeMale = 1,
=======
        Female = 1,
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    }

    public enum CharClass
    {
        Warrior,
        Mage,
        ShildWarrior,
        Gunner
    }

    public const int skillNum = 6;
    public const int equipNum = 4;
    public const int maxLevel = 20;
<<<<<<< HEAD
=======
    public const int maxGender = 2;
    public const int maxClass = 2;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

    string hName;
    Gender hGender;
    int level;
    CharClass charClass;
    int maxExp;
    int exp;

    int maxHealthPoint;
    int healthPoint;
    int maxMagicPoint = 200;
    int magicPoint;
    int hpRegeneration;
    int mpRegeneration;
    int attack;
    int defense;

    float moveSpeed;
    int skillPoint;
    int dreamStone;
    int[] skillLevel;
    int[] equipLevel;
    bool[] activeSkillUse;

	private static CharacterStatus instance;

    public static CharacterStatus Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(CharacterStatus)) as CharacterStatus;

            if (!instance)
            {
                GameObject container = new GameObject();
                container.name = "CharacterStatus";
                container.tag = "CharStatus";
                instance = container.AddComponent(typeof(CharacterStatus)) as CharacterStatus;
            }

            return instance;
        }
    }

    public string HName { get { return hName; } }
    public Gender HGender { get { return hGender; } }
    public int Level { get { return level; } }
	public CharClass HClass { get { return charClass; } set{ charClass = value; }}
    public int MaxExp { get { return maxExp; } }
    public int Exp { get { return exp; } }

    public int MaxHealthPoint { get { return maxHealthPoint; } }
    public int HealthPoint { get { return healthPoint; } }
    public int MaxMagicPoint { get { return maxMagicPoint; } }
    public int MagicPoint { get { return magicPoint; } }
    public int HpRegeneration { get { return hpRegeneration; } }
    public int MpRegeneration { get { return mpRegeneration; } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }
	public int MaxSkillNum { get { return skillNum; } }

    public float MoveSpeed { get { return moveSpeed; } }
    public int SkillPoint { get { return skillPoint; } }
    public int DreamStone { get { return dreamStone; } }
    public int[] SkillLevel { get { return skillLevel; } }
    public int[] EquipLevel { get { return equipLevel; } }
    public bool[] ActiveSkillUse { get { return activeSkillUse; } }

    public void SetCharacterStatus()
    {
        hName = "Hero";
        level = 0;
        charClass = 0;
        exp = 0;
        healthPoint = 2000;
        maxMagicPoint = 2000;
        magicPoint = maxMagicPoint;
        hpRegeneration = 0;
        mpRegeneration = 0;
		moveSpeed = 7;
        attack = 100;
        defense = 10;
        dreamStone = 0;
        skillLevel = new int[skillNum];
        activeSkillUse = new bool[equipNum];
        equipLevel = new int[equipNum];

		for (int i = 0; i < skillLevel.Length; i++)
		{
			skillLevel [i] = 1;
		}

        for (int i = 0; i < activeSkillUse.Length; i++)
        {
            activeSkillUse[i] = true;
        }       
    }

    public void SetCharacterStatus(CharacterStatusData characterStatusData)
    {
        hName = characterStatusData.Name;
        level = characterStatusData.Level;
        hGender = (Gender)characterStatusData.Gender;
        charClass = (CharClass)characterStatusData.HClass;
        exp = characterStatusData.Exp;
        maxExp = characterStatusData.Exp;
        healthPoint = characterStatusData.HealthPoint;
        maxHealthPoint = characterStatusData.HealthPoint;
        magicPoint = characterStatusData.MagicPoint;
        hpRegeneration = characterStatusData.HpRegeneration;
        mpRegeneration = characterStatusData.MpRegeneration;
        attack = characterStatusData.Attack;
        defense = characterStatusData.Defense;
        dreamStone = characterStatusData.DreamStone;
        skillLevel = new int[skillNum];
        equipLevel = new int[equipNum];

        for (int i = 0; i < skillNum; i++)
        {
            skillLevel[i] = characterStatusData.SkillLevel[i];
        }

        for (int i = 0; i < equipNum; i++)
        {
            equipLevel[i] = characterStatusData.EquipLevel[i];
        }
    }

    public void DecreaseHealthPoint(int amount)
    {
        healthPoint -= amount;

    }

    public void DecreaseMagicPoint(int amount)
    {
        magicPoint -= amount;
    }

    public IEnumerator SkillCoolTimer(int activeSkillIndex, int skillCoolTime)
    {
        activeSkillUse[activeSkillIndex] = false;
        yield return new WaitForSeconds(skillCoolTime);
        activeSkillUse[activeSkillIndex] = true;
    }
}
