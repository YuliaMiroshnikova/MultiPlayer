using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{

    private Button _createRoomBtn, _joinRoomBtn;
    public GameObject createRoom, joinRoom;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _createRoomBtn = root.Q<Button>("CreateRoomBtn");
        _createRoomBtn.clicked += CreateRoomBtnOnClicked;
        
        _joinRoomBtn = root.Q<Button>("JoinRoomBtn");
        _joinRoomBtn.clicked += JoinRoomBtnOnClicked;
    }

    private void JoinRoomBtnOnClicked()
    {
        gameObject.SetActive(false);
        joinRoom.SetActive(true);
    }

    private void CreateRoomBtnOnClicked()
    {
        gameObject.SetActive(false);
        createRoom.SetActive(true);
    }
}
