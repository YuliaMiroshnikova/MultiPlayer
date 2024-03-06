using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateRoom : MonoBehaviour
{
    private Button _createRoomBtn;
    private TextField _userRoomName;
    public GameObject loadingUI;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _createRoomBtn = root.Q<Button>("CreateRoomBtn");
        _createRoomBtn.clicked += CreateRoomBtnOnClicked;
        
        _userRoomName = root.Q<TextField>("UserRoomName");
    }

    private void CreateRoomBtnOnClicked()
    {
        string userInput = _userRoomName.value;
        if (string.IsNullOrEmpty(userInput)) return;

        PhotonNetwork.CreateRoom(userInput);

        gameObject.SetActive(false);
        loadingUI.SetActive(true);
    }
}
