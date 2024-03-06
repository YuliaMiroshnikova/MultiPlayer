using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviourPunCallbacks
{
    private static GameController _game;
    
    
    private void Start()
    {
        if(_game != null)
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
        _game = this;
        
    }

    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= SceneManagerOnSceneLoaded;
    }

    private void SceneManagerOnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if (scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate("PlayerManager", Vector3.zero, Quaternion.identity);
            
        }
        
    }
    
    
    
    
}



