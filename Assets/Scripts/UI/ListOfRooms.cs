using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;
using Photon.Realtime;

public class ListOfRooms : MonoBehaviourPunCallbacks
{
    public GameObject loadingUI;
    private VisualElement _listOfRooms;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _listOfRooms = root.Q<VisualElement>("ListOfRooms");
        ChangeRooms();
    }

    public void ChangeRooms()
    {
        if(_listOfRooms == null) return;
        
        _listOfRooms.Clear();
        foreach (string el in PhotonLauncher.RoomList)
        {
            Button button = new Button();
            button.text = el;
            button.clicked += () => JoinRoom(el);
            _listOfRooms.Add(button);
        }
    }

    private void JoinRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);
        loadingUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
