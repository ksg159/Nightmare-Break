﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public enum Result
{
    Success = 0,
    Fail,
}

public class DataHandler : MonoBehaviour
{
<<<<<<< HEAD
    GameManager gameManager;
    NetworkManager networkManager;
    DungeonManager dungeonManager;
    UIManager uiManager;
    CharacterStatus characterStatus;

=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    public Queue<DataPacket> receiveMsgs;
    object receiveLock;

    public delegate void P2PRecvNotifier(DataPacket packet, int udpId);
    public delegate void ServerRecvNotifier(DataPacket packet);
    P2PRecvNotifier p2pRecvNotifier;
    ServerRecvNotifier serverRecvNotifier;
    private Dictionary<int, P2PRecvNotifier> p2p_notifier = new Dictionary<int, P2PRecvNotifier>();
    private Dictionary<int, ServerRecvNotifier> server_notifier = new Dictionary<int, ServerRecvNotifier>();

    public DateTime dTime;

    public void Initialize(Queue<DataPacket> receiveQueue, Queue<DataPacket> sendQueue, object newLock)
    {
        receiveMsgs = receiveQueue;
        receiveLock = newLock;

<<<<<<< HEAD
        networkManager = GetComponent<NetworkManager>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

=======
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        SetServerNotifier();
        SetUdpNotifier();

        StartCoroutine(DataHandle());
    }

<<<<<<< HEAD
    public void SetCharacterStatus()
    {
        characterStatus = GameObject.FindWithTag("CharStatus").GetComponent<CharacterStatus>();
    }

    public void SetServerNotifier()
    {
=======
    public void SetServerNotifier()
    {
        server_notifier.Add((int)ServerPacketId.ServerConnectionCheck, ServerConnectionCheck);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        server_notifier.Add((int)ServerPacketId.CreateAccountResult, CreateAccountResult);
        server_notifier.Add((int)ServerPacketId.DeleteAccountResult, DeleteAccountResult);
        server_notifier.Add((int)ServerPacketId.LoginResult, LoginResult);
        server_notifier.Add((int)ServerPacketId.LogoutResult, LogoutResult);
        server_notifier.Add((int)ServerPacketId.CharacterList, CharacterList);
        server_notifier.Add((int)ServerPacketId.CreateCharacterResult, CreateCharacterResult);
        server_notifier.Add((int)ServerPacketId.DeleteChracterResult, DeleteCharacterResult);
<<<<<<< HEAD
        server_notifier.Add((int)ServerPacketId.RoomList, RoomList);
        server_notifier.Add((int)ServerPacketId.CharacterStatus, CharacterStatus);
=======
        server_notifier.Add((int)ServerPacketId.CharacterStatus, SetCharacterStatus);
        server_notifier.Add((int)ServerPacketId.RoomList, RoomList);
        server_notifier.Add((int)ServerPacketId.ReturnToSelectResult, ReturnToSelectResult);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        server_notifier.Add((int)ServerPacketId.CreateRoomNumber, CreateRoomNumber);
        server_notifier.Add((int)ServerPacketId.EnterRoomNumber, EnterRoomNumber);
        server_notifier.Add((int)ServerPacketId.ExitRoomNumber, ExitRoomNumber);
        server_notifier.Add((int)ServerPacketId.RoomData, RoomData);
        server_notifier.Add((int)ServerPacketId.StartGame, StartGame);
        server_notifier.Add((int)ServerPacketId.UdpConnection, UdpConnection);
        server_notifier.Add((int)ServerPacketId.MonsterSpawnList, MonsterSpawnList);
<<<<<<< HEAD
        server_notifier.Add((int)ServerPacketId.DungeonData, DungeonData);
=======
        server_notifier.Add((int)ServerPacketId.MonsterStatusData, MonsterStatusData);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        server_notifier.Add((int)ServerPacketId.StartDungeon, StartDungeon);
    }

    public void SetUdpNotifier()
    {
        p2p_notifier.Add((int)P2PPacketId.RequestConnectionCheck, RequestConnectionCheck);
        p2p_notifier.Add((int)P2PPacketId.UdpAnswer, AnswerCheck);
        p2p_notifier.Add((int)P2PPacketId.CreateUnit, CreateUnit);
        p2p_notifier.Add((int)P2PPacketId.UnitPosition, UnitPosition);
        p2p_notifier.Add((int)P2PPacketId.UnitState, UnitState);
    }

    public IEnumerator DataHandle()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.016f);

            int readCount = receiveMsgs.Count;

            for (int i = 0; i < readCount; i++)
            {
                //패킷을 Dequeue 한다
                //패킷 : 메시지 타입 + 메시지 내용
                DataPacket packet;

                //lock (receiveLock)
                //{
                packet = receiveMsgs.Dequeue();
                //}

                HeaderData headerData = new HeaderData();
                HeaderSerializer headerSerializer = new HeaderSerializer();
                headerSerializer.SetDeserializedData(packet.msg);

                if (packet.endPoint == null)
                {
                    headerSerializer.Deserialize(ref headerData);
                    DataReceiver.ResizeByteArray(0, NetworkManager.packetSource + NetworkManager.packetId, ref packet.msg);

                    if (server_notifier.TryGetValue(headerData.id, out serverRecvNotifier))
                    {
                        serverRecvNotifier(packet);
                    }
                    else
                    {
                        Debug.Log("DataHandler::Server.TryGetValue 에러 " + headerData.id);
                    }
                }
                else
                {
                    headerSerializer.UdpDeserialize(ref headerData);
                    DataReceiver.ResizeByteArray(0, NetworkManager.packetSource + NetworkManager.packetId + NetworkManager.udpId, ref packet.msg);

                    if (p2p_notifier.TryGetValue(headerData.id, out p2pRecvNotifier))
                    {
                        p2pRecvNotifier(packet, headerData.udpId);
                    }
                    else
                    {
                        Debug.Log("DataHandler::P2P.TryGetValue 에러 " + headerData.id);
                    }
                }
            }

        }
    }
<<<<<<< HEAD
=======

    //Server - 연결 확인
    public void ServerConnectionCheck(DataPacket packet)
    {
        DataSender.Instance.ServerConnectionAnswer();
    }
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    
    //Server - 가입 결과
    public void CreateAccountResult(DataPacket packet)
    {
        Debug.Log("가입 결과 수신");
        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();
        
        if(resultData.Result == (byte)Result.Success)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "가입 성공"));
            uiManager.LoginUIManager.CreateAccountSuccess();
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(uiManager.Dialog(1.0f, "가입 실패"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "가입 성공"));
            UIManager.Instance.LoginUIManager.CreateAccountSuccess();
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "가입 실패"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 탈퇴 결과
    public void DeleteAccountResult(DataPacket packet)
    {
        Debug.Log("탈퇴 결과 수신");
        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "탈퇴 성공"));
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(uiManager.Dialog(1.0f, "탈퇴 실패"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "탈퇴 성공"));
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "탈퇴 실패"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 로그인 결과
    public void LoginResult(DataPacket packet)
    {
        Debug.Log("로그인 결과 수신");

        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "로그인 성공"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "로그인 성공"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
            SceneChanger.Instance.SceneChange(SceneChanger.SceneName.SelectScene, true);
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "로그인 실패"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "로그인 실패"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 로그아웃결과
    public void LogoutResult(DataPacket packet)
    {

    }

    //Server - 캐릭터 리스트 수신
    public void CharacterList(DataPacket packet)
    {
        Debug.Log("캐릭터 리스트 수신");

        CharacterListPacket characterListPacket = new CharacterListPacket(packet.msg);
        CharacterList characterList = characterListPacket.GetData();

<<<<<<< HEAD
        uiManager.SelectUIManager.CharacterList = characterList;
=======
        UIManager.Instance.SelectUIManager.CharacterList = characterList;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[(int)SceneChanger.SelectLoadingData.CharacterList] = true;
        }
        else
        {
<<<<<<< HEAD
            uiManager.SelectUIManager.SetCharacter();
=======
            UIManager.Instance.SelectUIManager.SetCharacter();
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }        
    }

    //Server - 캐릭터 생성 결과
    public void CreateCharacterResult(DataPacket packet)
    {
        Debug.Log("캐릭터 생성 결과 수신");
        
        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "캐릭터 생성 성공"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "캐릭터 생성 성공"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
            SceneChanger.Instance.SceneChange(SceneChanger.SceneName.SelectScene, false);
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "캐릭터 생성 실패"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "캐릭터 생성 실패"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 캐릭터 삭제 결과
    public void DeleteCharacterResult(DataPacket packet)
    {
        Debug.Log("캐릭터 삭제 결과 수신");

        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "캐릭터 삭제 성공")); 
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(uiManager.Dialog(1.0f, "캐릭터 삭제 실패"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "캐릭터 삭제 성공")); 
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "캐릭터 삭제 실패"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 캐릭터 선택 결과
    public void SelectCharacterResult(DataPacket packet)
    {
        Debug.Log("캐릭터 선택 결과 수신");

        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "캐릭터 선택 성공"));
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(uiManager.Dialog(1.0f, "캐릭터 선택 실패"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "캐릭터 선택 성공"));
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "캐릭터 선택 실패"));
        }
    }

    //Server - 캐릭터 정보 수신
    public void SetCharacterStatus(DataPacket packet)
    {
        Debug.Log("캐릭터 정보 수신");
        CharacterStatusPacket characterStatusPacket = new CharacterStatusPacket(packet.msg);
        CharacterStatusData characterStatusData = characterStatusPacket.GetData();

        CharacterStatus.Instance.SetCharacterStatus(characterStatusData);

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[1] = true;
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 방 목록 수신
    public void RoomList(DataPacket packet)
    {
        Debug.Log("방 목록 수신");
        RoomListPacket roomListPacket = new RoomListPacket(packet.msg);
        RoomListData roomListData = roomListPacket.GetData();

<<<<<<< HEAD
        uiManager.WaitingUIManager.SetRoomListData(roomListData);

        for (int i =0; i< WaitingUIManager.maxRoomNum; i++)
        {
            Debug.Log(roomListData.Rooms[i].RoomName);
            Debug.Log(roomListData.Rooms[i].PlayerNum);
=======
        UIManager.Instance.WaitingUIManager.SetRoomListData(roomListData);

        for (int roomIndex = 0; roomIndex < WaitingUIManager.maxRoomNum; roomIndex++)
        {
            Debug.Log(roomIndex + "번 방 유저 정보");
            for (int userIndex = 0; userIndex < WaitingUIManager.maxPlayerNum; userIndex ++)
            {
                Debug.Log(roomListData.Rooms[roomIndex].RoomUserData[userIndex].UserClass);
                Debug.Log(roomListData.Rooms[roomIndex].RoomUserData[userIndex].UserGender);
                Debug.Log(roomListData.Rooms[roomIndex].RoomUserData[userIndex].UserName);
                Debug.Log(roomListData.Rooms[roomIndex].RoomUserData[userIndex].UserLevel);
            }
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[0] = true;
        }
        else if(SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.WaitingScene)
        {
            UIManager.Instance.WaitingUIManager.SetRoom();
        }
    }

<<<<<<< HEAD
    //Server - 캐릭터 정보 수신
    public void CharacterStatus(DataPacket packet)
    {
        Debug.Log("캐릭터 정보 수신");
        CharacterStatusPacket characterStatusPacket = new CharacterStatusPacket(packet.msg);
        CharacterStatusData characterStatusData = characterStatusPacket.GetData();

        characterStatus.SetCharacterStatus(characterStatusData);

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[1] = true;
=======
    //Server - 선택 창으로 돌아가기 결과 수신
    public void ReturnToSelectResult(DataPacket packet)
    {
        Debug.Log("선택 창으로 돌아가기 결과");

        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
            SceneChanger.Instance.SceneChange(SceneChanger.SceneName.SelectScene, true);
        }
        else
        {
            Debug.Log("선택창으로 돌아가기 실패");
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 방 생성 결과 수신
    public void CreateRoomNumber(DataPacket packet)
    {
        Debug.Log("방 생성 결과 수신");
        RoomNumberPacket resultPacket = new RoomNumberPacket(packet.msg);
        RoomNumberData resultData = resultPacket.GetData();

        if (resultData.RoomNum < 0)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "방 생성 실패"));
        }
        else if (resultData.RoomNum <= WaitingUIManager.maxRoomNum)
        {
            StartCoroutine(uiManager.Dialog(1.0f, "방 생성 성공"));
            uiManager.WaitingUIManager.CreateRoom(resultData.RoomNum);
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "방 생성 실패"));
        }
        else if (resultData.RoomNum <= WaitingUIManager.maxRoomNum)
        {
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "방 생성 성공"));
            DataSender.Instance.EnterRoom(resultData.RoomNum);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Server - 방 입장 결과 수신
    public void EnterRoomNumber(DataPacket packet)
    {
        Debug.Log("방 입장 결과 수신");
        RoomNumberPacket roomNumberPacket = new RoomNumberPacket(packet.msg);
        RoomNumberData roomNumberData = roomNumberPacket.GetData();

        Debug.Log(roomNumberData.RoomNum);
        
        if (roomNumberData.RoomNum < 0)
        {
<<<<<<< HEAD
            StartCoroutine(uiManager.Dialog(1.0f, "방 입장 실패"));
        }
        else if (roomNumberData.RoomNum <= WaitingUIManager.maxPlayerNum)
        {
            StartCoroutine(uiManager.Dialog(1.0f, "방 입장 성공"));
=======
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "방 입장 실패"));
        }
        else if (roomNumberData.RoomNum <= WaitingUIManager.maxPlayerNum)
        {
            StartCoroutine(UIManager.Instance.Dialog(1.0f, "방 입장 성공"));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

            SceneChanger.Instance.SceneChange(SceneChanger.SceneName.RoomScene, false);
        }
    }

    //Server - 방 유저 정보 수신
    public void RoomData(DataPacket packet)
    {
        Debug.Log("방 유저 정보 수신");
        RoomDataPacket roomDataPacket = new RoomDataPacket(packet.msg);
        RoomData roomData = roomDataPacket.GetData();

        Debug.Log(roomData.DungeonName);

        for (int i = 0; i < WaitingUIManager.maxPlayerNum; i++)
        {
            Debug.Log(roomData.RoomUserData[i].UserName);
            Debug.Log(roomData.RoomUserData[i].UserGender);
            Debug.Log(roomData.RoomUserData[i].UserClass);
            Debug.Log(roomData.RoomUserData[i].UserLevel);
        }

        UIManager.Instance.RoomUIManager.SetRoom(roomData);
    }

    //Server - 방 퇴장 결과 수신
    public void ExitRoomNumber(DataPacket packet)
    {
        Debug.Log("방 퇴장 결과 수신");
        RoomNumberPacket roomNumberPacket = new RoomNumberPacket(packet.msg);
        RoomNumberData roomNumberData = roomNumberPacket.GetData();

        Debug.Log(roomNumberData.RoomNum);

        if (roomNumberData.RoomNum == (int)Result.Fail)
        {

        }
        else if (roomNumberData.RoomNum == (int)Result.Success)
        {
            SceneChanger.Instance.SceneChange(SceneChanger.SceneName.WaitingScene, false);
        }
    }

    //Server - 게임 시작
    public void StartGame(DataPacket packet)
    {
        Debug.Log("게임 시작");

        ResultPacket resultPacket = new ResultPacket(packet.msg);
        ResultData resultData = resultPacket.GetData();

        if (resultData.Result == (byte)Result.Success)
        {
            Debug.Log("게임 시작");
            SceneChanger.Instance.SceneChange(SceneChanger.SceneName.InGameScene, true);
        }
        else if (resultData.Result == (byte)Result.Fail)
        {
            Debug.Log("게임 시작 실패");
        }
    }

    //Server - 던전 몬스터 소환 데이터 수신
    public void MonsterSpawnList(DataPacket packet)
    {
        Debug.Log("던전 몬스터 소환 데이터 수신");

        MonsterSpawnListPacket monsterSpawnListPacket = new MonsterSpawnListPacket(packet.msg);
        DungeonData monsterSpawnData = monsterSpawnListPacket.GetData();

<<<<<<< HEAD
<<<<<<< HEAD
        dungeonManager.SetMonsterSpawnList(monsterSpawnData);
=======
        DungeonManager.Instance.SetMonsterSpawnList(monsterSpawnData);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
=======
        DungeonManager.Instance.SetMonsterSpawnList(monsterSpawnData);
>>>>>>> acda1eac855fd78aa614b3b12b9c25d4335cb819

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[0] = true;
        }
    }

    //Server - 던전 데이터 수신
<<<<<<< HEAD
    public void DungeonData(DataPacket packet)
    {
        Debug.Log("던전 데이터 수신");
=======
    public void MonsterStatusData(DataPacket packet)
    {
        Debug.Log("몬스터 스텟 데이터 수신");
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

        MonsterStatusPacket dungeonDataPacket = new MonsterStatusPacket(packet.msg);
        MonsterStatusData dungeonData = dungeonDataPacket.GetData();

<<<<<<< HEAD
<<<<<<< HEAD
        dungeonManager.SetMonsterData(dungeonData);
=======
        DungeonManager.Instance.SetMonsterData(dungeonData);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
=======
        DungeonManager.Instance.SetMonsterData(dungeonData);
>>>>>>> acda1eac855fd78aa614b3b12b9c25d4335cb819

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[1] = true;
        }
    }

    //Server - 연결 시작
    public void UdpConnection(DataPacket packet)
    {
        Debug.Log("연결 시작");
        UDPConnectionPacket udpConnectionPacket = new UDPConnectionPacket(packet.msg);
        UDPConnectionData udpConnectionData = udpConnectionPacket.GetData();

        DataSender.Instance.udpId = new int[udpConnectionData.playerNum];
        
        for (int userIndex = 0; userIndex < udpConnectionData.playerNum; userIndex++)
        {
            string endPoint = udpConnectionData.endPoint[userIndex];

<<<<<<< HEAD
            if (endPoint == networkManager.ServerSock.LocalEndPoint.ToString())
            {
                networkManager.SetMyIndex(userIndex);
            }
        }

        networkManager.InitializeUdpConnection();
        networkManager.ReSendManager.Initialize(udpConnectionData.playerNum);
        DataSender.Instance.InitializeUdpSend(networkManager.ClientSock);
=======
            if (endPoint == NetworkManager.Instance.ServerSock.LocalEndPoint.ToString())
            {
                NetworkManager.Instance.SetMyIndex(userIndex);
            }
        }

        NetworkManager.Instance.InitializeUdpConnection();
        NetworkManager.Instance.ReSendManager.Initialize(udpConnectionData.playerNum);
        DataSender.Instance.InitializeUdpSend(NetworkManager.Instance.ClientSock);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

        for (int userIndex = 0; userIndex < udpConnectionData.playerNum; userIndex++)
        {
            string endPoint = udpConnectionData.endPoint[userIndex];
            string ip = endPoint.Substring(0, endPoint.IndexOf(":"));

            IPEndPoint newEndPoint = new IPEndPoint(IPAddress.Parse(ip), NetworkManager.clientPortNumber + userIndex);

<<<<<<< HEAD
            networkManager.UserIndex.Add(new UserIndex(newEndPoint, userIndex));

            if (endPoint != networkManager.ServerSock.LocalEndPoint.ToString())
            {
                Debug.Log("연결 아이피 : " + newEndPoint.ToString());
                networkManager.ConnectP2P(newEndPoint);
=======
            NetworkManager.Instance.UserIndex.Add(new UserIndex(newEndPoint, userIndex));

            if (endPoint != NetworkManager.Instance.ServerSock.LocalEndPoint.ToString())
            {
                Debug.Log("연결 아이피 : " + newEndPoint.ToString());
                NetworkManager.Instance.ConnectP2P(newEndPoint);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
            }
        }

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[2] = true;
        }
    }

    //Client - 연결 확인 답장
    public void RequestConnectionCheck(DataPacket packet, int udpId)
    {
        Debug.Log(packet.endPoint.ToString() + "연결 확인 요청 UdpId : " + udpId);

        DataSender.Instance.UdpAnswer(packet.endPoint, udpId);
    }

    //Client - 답신 확인
    public void AnswerCheck(DataPacket packet, int udpId)
    {
        Debug.Log(packet.endPoint.ToString() + "답신 받음 아이디 : " + udpId);

        SendData sendData = new SendData(udpId, packet.endPoint);
<<<<<<< HEAD
        networkManager.ReSendManager.RemoveReSendData(sendData);
=======
        NetworkManager.Instance.ReSendManager.RemoveReSendData(sendData);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    }

    //Server - 던전 시작
    public void StartDungeon(DataPacket packet)
    {
        Debug.Log("던전 시작");

        dTime = DateTime.Now;
        Debug.Log("시간 지정 : " + dTime.ToString("hh:mm:ss"));

        if (SceneChanger.Instance.CurrentScene == SceneChanger.SceneName.LoadingScene)
        {
            SceneChanger.Instance.LoadingCheck[3] = true;
        }
    }

    //Client - 유닛 생성
    public void CreateUnit(DataPacket packet, int udpId)
    {
        Debug.Log(packet.endPoint.ToString() + "유닛 생성");
        CreateUnitPacket createUnitPacket = new CreateUnitPacket(packet.msg);
        CreateUnitData createUnitData = createUnitPacket.GetData();

<<<<<<< HEAD
        int index = networkManager.GetUserIndex(packet.endPoint);

        dungeonManager.CreateUnit(createUnitData.ID, index, new Vector3(createUnitData.PosX, createUnitData.PosY, createUnitData.PosZ));
=======
        int index = NetworkManager.Instance.GetUserIndex(packet.endPoint);

        DungeonManager.Instance.CreateUnit(createUnitData.ID, index, new Vector3(createUnitData.PosX, createUnitData.PosY, createUnitData.PosZ));
>>>>>>> 712e498f70097a1120b4938553e24937614e8308

        DataSender.Instance.UdpAnswer(packet.endPoint, udpId);
    }

    //Client - 유닛 위치
    public void UnitPosition(DataPacket packet, int udpId)
    {
        UnitPositionPacket unitPositionPacket = new UnitPositionPacket(packet.msg);
        UnitPositionData unitPositionData = unitPositionPacket.GetData();
        
        if (unitPositionData.UnitType == (byte)UnitType.Hero)
        {
<<<<<<< HEAD
            dungeonManager.SetCharacterPosition(unitPositionData);
        }
        else if (unitPositionData.UnitType == (byte)UnitType.Monster)
        {
            dungeonManager.SetMonsterPosition(unitPositionData);
=======
            DungeonManager.Instance.SetCharacterPosition(unitPositionData);
        }
        else if (unitPositionData.UnitType == (byte)UnitType.Monster)
        {
            DungeonManager.Instance.SetMonsterPosition(unitPositionData);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }

    //Client - 유닛 애니메이션
    public void UnitState(DataPacket packet, int udpId)
    {
        UnitStatePacket unitStatePacket = new UnitStatePacket(packet.msg);
        UnitStateData unitStateData = unitStatePacket.GetData();

        if (unitStateData.UnitType == (byte)UnitType.Hero)
        {
<<<<<<< HEAD
            dungeonManager.CharacterState(unitStateData);
        }
        else if (unitStateData.UnitType == (byte)UnitType.Monster)
        {
            dungeonManager.MonsterState(unitStateData);
=======
            DungeonManager.Instance.CharacterState(unitStateData);
        }
        else if (unitStateData.UnitType == (byte)UnitType.Monster)
        {
            DungeonManager.Instance.MonsterState(unitStateData);
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
        }
    }
}