using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private PhotonView _photonView;
    public float speed = 5f, rotateSpeed = 1f;
    public int _attackDamage = 25;
    private int _health = 100;

    
    public float shootforce;

    
    
    //
    public ParticleSystem shootEffect;
    public ParticleSystem targetEffect;
    //
    
    
    //
   public float mousespeed = 100f;
    //
    
    
    private void Awake()
    {
        
        _photonView = GetComponent<PhotonView>();
        _rb = GetComponent<Rigidbody>();

        
        
        if(!_photonView.IsMine)
            Destroy(GetComponentInChildren<Camera>().gameObject);
    }

    private void FixedUpdate()
    {
        if (!_photonView.IsMine)
            return;

        MovePlayer();
    }

    private void Update()
    {
        if (!_photonView.IsMine)
            return;

        RotatePlayer();
        
        //
        RotateCamera();
        //

        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Camera cam = transform.GetChild(0)?.GetComponent<Camera>();
            Ray ray = cam.ScreenPointToRay(new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0));
            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.DrawLine(cam.transform.position, hit.transform.position, Color.blue, 3f);
                if (hit.collider.CompareTag("Player"))

                {
                    hit.collider.GetComponent<PlayerController>().Damage(_attackDamage);
                    targetEffect.transform.position = hit.point;
                    targetEffect.Play();
                }
                else
                {
                    shootEffect.transform.position = hit.point;
                    shootEffect.Play();
                }
            }
            
            
        }
    }

    public void Damage(int damage)
    {
        _photonView.RPC("PunDamage", RpcTarget.All, damage);
        
    }

    [PunRPC]
    void PunDamage(int damage)
    {
        if (!_photonView.IsMine)
            return;
            
        
        _rb.AddForce(Vector3.up * shootforce);
       
        
        _health -= damage;
        if(_health <= 0)
            PhotonNetwork.Destroy(gameObject);

    }

    private void RotatePlayer()
    {
      
        transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal")); 
        
    }

    private void MovePlayer()
    {
        _rb.MovePosition(transform.position + (transform.forward * Time.fixedDeltaTime * speed * Input.GetAxis("Vertical")));
    }

    private void RotateCamera()
    {

        float mouseY = Input.GetAxis("Mouse Y");
            if (Mathf.Abs(mouseY) > 0.01) 
            {
                Camera cam = transform.GetChild(0)?.GetComponent<Camera>();
                cam.transform.Rotate(Vector3.right * -mouseY * mousespeed * Time.deltaTime);
            }
           
        

    }
        
    
    
   

}




