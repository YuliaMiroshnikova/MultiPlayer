// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Photon.Pun;
//
// public class PlayerManager : MonoBehaviour
// {
//     private PhotonView _photonView;
//     private void Start()
//     {
//         _photonView = GetComponent<PhotonView>();
//         if(_photonView.IsMine)
//             CreatePlayer();
//     }
//
//     private void CreatePlayer()
//     {
//         PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
//     }
// }



using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    
    public Vector3[] coordinates = new Vector3[3];
    
    private PhotonView _photonView;
    private void Start()
    {
        
        _photonView = GetComponent<PhotonView>();
        if(_photonView.IsMine)
            CreatePlayer();
    }
    [PunRPC] 
    private void CreatePlayer()
    {
        int randomCoordinateIndex = UnityEngine.Random.Range(0, coordinates.Length);
        Vector3 spawnPosition = coordinates[randomCoordinateIndex];
        PhotonNetwork.Instantiate("Player", spawnPosition, Quaternion.identity);
    }
}




