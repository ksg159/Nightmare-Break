public enum ClientPacketId
{
    None = 0,
<<<<<<< HEAD
=======
    ServerConnectionAnswer,
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    CreateAccount,
    DeleteAccount,
    Login,
    Logout,
    GameClose,
    RequestCharacterList,
    CreateCharacter,
    DeleteCharacter,
    RequestCharacterStatus,
    RequestRoomList,
<<<<<<< HEAD
=======
    ReturnToSelect,
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    SkillUp,
    EquipUpgrade,
    CreateRoom,
    EnterRoom,
    ExitRoom,
    RequestRoomUserData,
    SwapPlayer,
    StartGame,
    RequestUdpConnection,
    RequestMonsterSpawnList,
    RequestMonsterStatusData,
    UdpConnectComplete,
}

public enum ServerPacketId
{
    None = 0,
<<<<<<< HEAD
=======
    ServerConnectionCheck,
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    CreateAccountResult,
    DeleteAccountResult,
    LoginResult,
    LogoutResult,
    CharacterList,
    CreateCharacterResult,
    DeleteChracterResult,
<<<<<<< HEAD
    RoomList,
    CharacterStatus,
=======
    CharacterStatus,
    RoomList,
    ReturnToSelectResult,
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    SkillUpResult,
    EquipUpgradeResult,
    CreateRoomNumber,
    EnterRoomNumber,
    RoomData,
    ExitRoomNumber,
    StartGame,
    MonsterSpawnList,
<<<<<<< HEAD
    DungeonData,
=======
    MonsterStatusData,
>>>>>>> 712e498f70097a1120b4938553e24937614e8308
    UdpConnection,
    StartDungeon,
}

public enum P2PPacketId
{
    None = 0,
    RequestConnectionCheck,
    ConnectionCheckAnswer,
    UdpAnswer,
    CreateUnit,
    UnitPosition,
    UnitState,
}