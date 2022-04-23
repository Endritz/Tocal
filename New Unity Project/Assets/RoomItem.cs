using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Text roomName;
    LobbyManager manager;
    private void Start(){
        manager = FindObjectOfType<LobbyManager>();
    }

    public void SetRoomName(string _roomName){
        roomName.text = _roomName;
    }

    public void OnClickITem(){
        manager.JoinRoom(roomName.text);
    }

    
}
