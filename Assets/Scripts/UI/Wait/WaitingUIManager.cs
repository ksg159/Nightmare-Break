﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaitingUIManager : MonoBehaviour
{
    public const int maxCharacterNum = 3;
    public const int maxRoomNum = 20;
    public const int maxPlayerNum = 4;

<<<<<<< HEAD
    [SerializeField]private int selectNum;

=======
    private Button refreshBtn;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    private Button roomCreateBtn;
    private Button roomEntereBtn;
    private Button skillAddBtn;
    private Button equipInfoBtn;
    private Button myInfoBtn;
<<<<<<< HEAD
=======
    private Button returnToSelectBtn;
    private Button gameExitBtn;
    private Button nextDungeonLevelBtn;
    private Button previousDungeonLevelBtn;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    private Button roomCreateExitBtn;
    private Button skillAddExitBtn;
    private Button equipInfoExitBtn;
    private Button myInfoExitBtn;
    private Button roomCreateYesBtn;
	private Button[] roomBtn;
<<<<<<< HEAD
=======
    private Button[] skillAddIcon;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

    private InputField createroomName;

	private GameObject roomCreateUI;
	private GameObject skillAddUI;
	private GameObject equipInfoUI;
	private GameObject myInfoUI;
	private GameObject roomInfoUI;

<<<<<<< HEAD
=======
    private Text dungeonLevelText;
    private Text[] roomIndex;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    private Text[] roomName;
    private Text[] roomDungeonLevel;
    private Text[] roomCurrentUser;
	private Text[] roomInfoUserName;

	private Image equipWeaponIcon;
	private Image[] roomInfoClassIcon;
	private Image[] roomInfoGenderIcon;
<<<<<<< HEAD
	private Image[] skillAddIcon;
=======
    private Image[] skillAddSelectImage;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

    Room[] rooms;

    int currentRoomNum;
    int dungeonId;
    int dungeonLevel;

    public Room[] Rooms { get { return rooms; } }
    public int CurrentRoomNum { get { return currentRoomNum; } }

    public void ManagerInitialize()
    {
<<<<<<< HEAD
        selectNum = -1;
=======
        currentRoomNum = -1;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        dungeonId = 0;
        dungeonLevel = 1;

        SetUIObject();
        InitializeAddListner();

        roomCreateUI.SetActive(false);
        skillAddUI.SetActive(false);
        equipInfoUI.SetActive(false);
        myInfoUI.SetActive(false);
        roomInfoUI.SetActive(false);
    }

    public void SetUIObject()
    {
		roomBtn = new Button[maxRoomNum];
        roomName = new Text[maxRoomNum];
        roomDungeonLevel = new Text[maxRoomNum];
        roomCurrentUser = new Text[maxRoomNum];
		roomInfoUserName = new Text[maxPlayerNum];
<<<<<<< HEAD
		roomInfoClassIcon = new Image[maxPlayerNum];
		roomInfoGenderIcon = new Image[maxPlayerNum];
		skillAddIcon = new Image[CharacterStatus.skillNum];

=======
        roomIndex = new Text[maxRoomNum];
        roomInfoClassIcon = new Image[maxPlayerNum];
		roomInfoGenderIcon = new Image[maxPlayerNum];
        skillAddIcon = new Button[CharacterStatus.skillNum];
        skillAddSelectImage = new Image[CharacterStatus.skillNum];
                
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        roomCreateUI = GameObject.Find("RoomCreateUI");
        skillAddUI = GameObject.Find("SkillAddUI");
        equipInfoUI = GameObject.Find("EquipInfoUI");
        myInfoUI = GameObject.Find("MyInfoUI");
        roomInfoUI = GameObject.Find("RoomInfoUI");
<<<<<<< HEAD
=======
        refreshBtn = GameObject.Find("RefreshBtn").GetComponent<Button>();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        roomCreateBtn = GameObject.Find("RoomCreateBtn").GetComponent<Button>();
        roomEntereBtn = GameObject.Find("RoomEnterBtn").GetComponent<Button>();
        roomCreateYesBtn = GameObject.Find("RoomCreateYesBtn").GetComponent<Button>();
        skillAddBtn = GameObject.Find("SkillAddBtn").GetComponent<Button>();
        equipInfoBtn = GameObject.Find("EquipBtn").GetComponent<Button>();
        myInfoBtn = GameObject.Find("MyInfoBtn").GetComponent<Button>();
<<<<<<< HEAD
		createroomName = GameObject.Find("RoomCreateInputField").GetComponent<InputField>();
=======
        returnToSelectBtn = GameObject.Find("ReturnToSelectBtn").GetComponent<Button>();
        gameExitBtn = GameObject.Find("GameExitBtn").GetComponent<Button>();
        dungeonLevelText = GameObject.Find("DungeonLevelText").GetComponent<Text>();
        createroomName = GameObject.Find("RoomCreateInputField").GetComponent<InputField>();
        nextDungeonLevelBtn = GameObject.Find("NextDungeonLevelBtn").GetComponent<Button>();
        previousDungeonLevelBtn = GameObject.Find("PreviousDungeonLevelBtn").GetComponent<Button>();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

        equipWeaponIcon = equipInfoUI.transform.FindChild("Weapon").GetComponent<Image>();
        roomCreateExitBtn = roomCreateUI.transform.FindChild("ExitBtn").GetComponent<Button>();
        skillAddExitBtn = skillAddUI.transform.FindChild("ExitBtn").GetComponent<Button>();
        equipInfoExitBtn = equipInfoUI.transform.FindChild("ExitBtn").GetComponent<Button>();
        myInfoExitBtn = myInfoUI.transform.FindChild("ExitBtn").GetComponent<Button>();

		for (int i = 0; i < skillAddIcon.Length; i++) {
<<<<<<< HEAD
			skillAddIcon [i] = skillAddUI.transform.GetChild (i).GetComponent<Image> ();
			skillAddIcon [i].sprite = Resources.Load<Sprite> ("UI/SkillIcon/" + CharacterStatus.Instance.HClass.ToString ()+"/Skill"+(i+1)) as Sprite;
		}
		for (int i = 0; i < maxRoomNum; i++) {
			roomBtn [i] = GameObject.Find ("Room" + (i + 1)).GetComponent<Button> ();
			roomName [i] = roomBtn [i].transform.GetChild (1).GetComponent<Text> ();
			roomDungeonLevel [i] = roomBtn [i].transform.GetChild (2).GetComponent<Text> ();
			roomCurrentUser [i] = roomBtn [i].transform.GetChild (3).GetComponent<Text> ();

			if (i < maxPlayerNum) {
				roomInfoClassIcon [i] = roomInfoUI.transform.GetChild (i).GetComponent<Image> ();
				roomInfoUserName [i] = roomInfoClassIcon [i].transform.GetChild (0).GetComponent<Text> ();
				roomInfoGenderIcon [i] = roomInfoClassIcon [i].transform.GetChild (1).GetComponent<Image> ();
=======
            skillAddSelectImage[i] = skillAddUI.transform.FindChild("SkillSelect" + (i + 1)).GetComponent<Image>();
            skillAddIcon[i] = skillAddUI.transform.FindChild("Skill" + (i + 1)).GetComponent<Button>();
            skillAddIcon[i].image.sprite = Resources.Load<Sprite> ("UI/SkillIcon/" + CharacterStatus.Instance.HClass.ToString ()+"/Skill"+(i+1));
            skillAddSelectImage[i].gameObject.SetActive(false);
		}
		for (int i = 0; i < maxRoomNum; i++) {
			roomBtn [i] = GameObject.Find ("Room" + (i + 1)).GetComponent<Button> ();
            roomIndex[i] = roomBtn[i].transform.GetChild(0).GetComponent<Text>();
            roomName [i] = roomBtn [i].transform.GetChild (1).GetComponent<Text> ();
            roomDungeonLevel [i] = roomBtn [i].transform.GetChild (2).GetComponent<Text> ();
			roomCurrentUser [i] = roomBtn [i].transform.GetChild (3).GetComponent<Text> ();
			if (i < maxPlayerNum) {
				roomInfoClassIcon [i] = roomInfoUI.transform.FindChild("ClassIcon" + (i+1)).GetComponent<Image> ();
				roomInfoUserName [i] = roomInfoClassIcon [i].transform.GetChild (0).GetComponent<Text> (); 
                roomInfoGenderIcon [i] = roomInfoClassIcon [i].transform.GetChild (1).GetComponent<Image> ();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
			}
		}
    }

    public void InitializeAddListner()
    {
<<<<<<< HEAD
=======
        refreshBtn.onClick.AddListener(() => OnClickRefreash());
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        roomCreateBtn.onClick.AddListener(() => RoomCreate());
        roomEntereBtn.onClick.AddListener(() => OnClickEnterRoomButton());
        roomCreateYesBtn.onClick.AddListener(() => OnClickCreateRoomButton()); 
        skillAddBtn.onClick.AddListener(() => SkillAdd());
        equipInfoBtn.onClick.AddListener(() => EquipInfo());
        myInfoBtn.onClick.AddListener(() => MyInfo());
<<<<<<< HEAD
=======
        returnToSelectBtn.onClick.AddListener(() => OnClickReturnToSelect());
        gameExitBtn.onClick.AddListener(() => OnClickGameExit());
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        roomCreateExitBtn.onClick.AddListener(() => UIActiveCheck());
        skillAddExitBtn.onClick.AddListener(() => UIActiveCheck());
        equipInfoExitBtn.onClick.AddListener(() => UIActiveCheck());
        myInfoExitBtn.onClick.AddListener(() => UIActiveCheck());
<<<<<<< HEAD

		roomBtn [0].onClick.AddListener (() => RoomInfo (0));
=======
        nextDungeonLevelBtn.onClick.AddListener(() => DungeonLevelUP());
        previousDungeonLevelBtn.onClick.AddListener(() => DungeonLevelDown());

        roomBtn [0].onClick.AddListener (() => RoomInfo (0));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
		roomBtn [1].onClick.AddListener (() => RoomInfo (1));
		roomBtn [2].onClick.AddListener (() => RoomInfo (2));
		roomBtn [3].onClick.AddListener (() => RoomInfo (3));
		roomBtn [4].onClick.AddListener (() => RoomInfo (4));
		roomBtn [5].onClick.AddListener (() => RoomInfo (5));
		roomBtn [6].onClick.AddListener (() => RoomInfo (6));
		roomBtn [7].onClick.AddListener (() => RoomInfo (7));
		roomBtn [8].onClick.AddListener (() => RoomInfo (8));
		roomBtn [9].onClick.AddListener (() => RoomInfo (9));
		roomBtn [10].onClick.AddListener (() => RoomInfo (10));
		roomBtn [11].onClick.AddListener (() => RoomInfo (11));
		roomBtn [12].onClick.AddListener (() => RoomInfo (12));
		roomBtn [13].onClick.AddListener (() => RoomInfo (13));
		roomBtn [14].onClick.AddListener (() => RoomInfo (14));
		roomBtn [15].onClick.AddListener (() => RoomInfo (15));
		roomBtn [16].onClick.AddListener (() => RoomInfo (16));
		roomBtn [17].onClick.AddListener (() => RoomInfo (17));
		roomBtn [18].onClick.AddListener (() => RoomInfo (18));
		roomBtn [19].onClick.AddListener (() => RoomInfo (19));

    }

    public void RoomCreate()
	{
		UIActiveCheck ();
		roomCreateUI.SetActive (true);
	}

	public void SkillAdd()
	{
		UIActiveCheck ();
		skillAddUI.SetActive (true);
	}

	public void EquipInfo()
	{
		UIActiveCheck ();
		equipInfoUI.SetActive(true);
	}

<<<<<<< HEAD
	public void MyInfo()
	{
		UIActiveCheck ();
		myInfoUI.SetActive (true);
	}

	public void UIActiveCheck()
	{
		if (roomCreateUI.activeSelf) {
			createroomName.text = "";
			roomCreateUI.SetActive (false);
=======
    public void MyInfo()
    {
        UIActiveCheck();
        myInfoUI.SetActive(true);
    }

    public void DungeonLevelUP()
    {
        dungeonLevel++;
        if (dungeonLevel > 10)
        {
            dungeonLevel = 1;
        }
        dungeonLevelText.text = dungeonLevel.ToString();
    }

    public void DungeonLevelDown()
    {
        dungeonLevel--;
        if (dungeonLevel < 1)
        {
            dungeonLevel = 1;
        }
        dungeonLevelText.text = dungeonLevel.ToString();
    }

    public void UIActiveCheck()
	{
		if (roomCreateUI.activeSelf) {
			createroomName.text = "";
            dungeonLevel = 0;
            roomCreateUI.SetActive (false);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
		} else if (skillAddUI.activeSelf) {
			skillAddUI.SetActive (false);
		} else if (equipInfoUI.activeSelf) {
			equipInfoUI.SetActive (false);
		} else if (myInfoUI.activeSelf) {
			myInfoUI.SetActive (false);
		} else if (roomInfoUI.activeSelf) {
			roomInfoUI.SetActive (false);
		}
    }

	public void RoomInfo(int roomNum)
	{
		UIActiveCheck ();
		//룸 리퀘스트 호출
		roomInfoUI.SetActive (true);
        for (int i = 0; i < maxPlayerNum; i++)
        {
            if (rooms[i].PlayerNum > 0)
            {
<<<<<<< HEAD
                roomInfoClassIcon[i].sprite = Resources.Load<Sprite>("RoomClassIcon/Class" + (rooms[roomNum].RoomUserData[i].UserClass + 1));
=======
                roomInfoClassIcon[i].sprite = Resources.Load<Sprite>("RoomClassIcon/Class" + (rooms[roomNum].RoomUserData[i].UserClass));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
                roomInfoUserName[i].text = rooms[roomNum].RoomUserData[i].UserName;
                roomInfoGenderIcon[i].sprite = Resources.Load<Sprite>("RoomClassIcon/Gender" + rooms[roomNum].RoomUserData[i].UserGender);
            }
        }

        currentRoomNum = roomNum;
    }

    public void SetRoomListData(RoomListData roomListData)
    {
        rooms = roomListData.Rooms;
    }

    public void SetRoom()
    {
		for (int i = 0; i < maxRoomNum; i++) {
            if (rooms[i].PlayerNum != 0)
			{
				roomName [i].text = rooms [i].RoomName;
				roomDungeonLevel [i].text = rooms [i].DungeonLevel.ToString();
				roomCurrentUser [i].text = (rooms [i].PlayerNum.ToString () + "/" + maxPlayerNum.ToString ());
			}
            else
            {
                roomName[i].text = "";
                roomDungeonLevel[i].text = "";
                roomCurrentUser[i].text = "";
            }
		}
    }

<<<<<<< HEAD
    public void CreateRoom(int roomNum)
    {
        Debug.Log("방 생성 성공");
        DataSender.Instance.EnterRoom(roomNum);
    }

=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    public void OnClickCreateRoomButton()
    {
        DataSender.Instance.CreateRoom(createroomName.text, dungeonId, dungeonLevel);
    }

    public void OnClickEnterRoomButton()
    {
<<<<<<< HEAD
        DataSender.Instance.EnterRoom(currentRoomNum);
    }

    public void OnClickExitRoomButton()
    {
        DataSender.Instance.ExitRoom(currentRoomNum);
    }

    public void OnClickStartGameButton()
    {
        DataSender.Instance.StartGame();
=======
        if (currentRoomNum >= 0)
        {
            DataSender.Instance.EnterRoom(currentRoomNum);
        }        
    }

    public void OnClickReturnToSelect()
    {
        DataSender.Instance.ReturnToSelect();
    }

    public void OnClickRefreash()
    {
        DataSender.Instance.RequestRoomList();
    }

    public void OnClickGameExit()
    {
        Application.Quit();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    }
}

public class Room
{
    string roomName;
    string dungeonName;
    int dungeonId;
    int dungeonLevel;
	int playerNum;
    RoomUserData[] roomUserData;

    public string RoomName { get { return roomName; } }
    public string DungeonName { get { return dungeonName; } }
    public int DungeonId { get { return dungeonId; } }
    public int DungeonLevel { get { return dungeonLevel; } }
	public int PlayerNum { get { return playerNum; } }
    public RoomUserData[] RoomUserData { get { return roomUserData; } }

    public Room()
    {
        roomName = "";
        dungeonName = "";
        playerNum = 0;
        dungeonId = 0;
        dungeonLevel = 0;
        roomUserData = new RoomUserData[WaitingUIManager.maxPlayerNum];

        for (int i = 0; i < WaitingUIManager.maxPlayerNum; i++)
        {
            roomUserData[i] = new RoomUserData();
        }
    }

    public Room(string newRoomName, string newDungeonName, int newDungeonId, int newDungeonLevel)
    {
        roomName = newRoomName;
        dungeonName = newDungeonName;
        dungeonId = newDungeonId;
        dungeonLevel = newDungeonLevel;
        playerNum = 0;
        roomUserData = new RoomUserData[WaitingUIManager.maxPlayerNum];

        for (int i = 0; i < WaitingUIManager.maxPlayerNum; i++)
        {
            roomUserData[i] = new RoomUserData();
        }
    }

    public Room(string newRoomName, int newDungeonId, int newDungeonLevel, RoomUserData[] newRoomUserData, int newPlayerNum)
    {
        roomName = newRoomName;
        dungeonName = "";
        dungeonId = newDungeonId;
        dungeonLevel = newDungeonLevel;
        playerNum = newPlayerNum;
        roomUserData = newRoomUserData;
    }

    public Room(string newRoomName, string newDungeonName, int newDungeonId, int newDungeonLevel, RoomUserData[] newRoomUserData, int newPlayerNum)
    {
        roomName = newRoomName;
        dungeonName = newDungeonName;
        dungeonId = newDungeonId;
        dungeonLevel = newDungeonLevel;
        playerNum = newPlayerNum;
        roomUserData = newRoomUserData;
    }
}

public class RoomUserData
{
    string userName;
    int userGender;
    int userClass;
    int userLevel;

    public string UserName { get { return userName; } }
    public int UserGender { get { return userGender; } }
    public int UserClass { get { return userClass; } }
    public int UserLevel { get { return userLevel; } }

    public RoomUserData()
    {
        userName = "";
        userGender = 0;
        userClass = 0;
        userLevel = 0;
    }

    public RoomUserData(string newUserName, int newUserGender, int newUserClass, int newUserLevel)
    {
        userName = newUserName;
        userGender = newUserGender;
        userClass = newUserClass;
        userLevel = newUserLevel;
    }
}