using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TestUIManager : MonoBehaviour
{
    CharacterManager charManager;
    BattleUIManager battleUIManager;

    public BattleUIManager BattleUIManager { get { return battleUIManager; } }

    void Start()
    {
        SetBattleUIManager();
    }

    public void SetBattleUIManager()
    {
        charManager = GameObject.FindWithTag("Player").GetComponent<CharacterManager>();
        battleUIManager = new BattleUIManager();
        battleUIManager.SetUIObject();
    }

    public void PointEnter(int skillIndex)
    {
<<<<<<< HEAD
        battleUIManager.SetPointEnterUI(skillIndex, 2, (int)charManager.CharStatus.HClass);
=======
        battleUIManager.SetPointEnterUI(skillIndex, 2, (int)CharacterStatus.Instance.HClass);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    }

    public void OnPointExit()
    {
        battleUIManager.MouseOverUI.gameObject.transform.parent.gameObject.SetActive(false);
    }



}




