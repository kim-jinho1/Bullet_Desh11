using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Cinemachine;
public class CameraZoom : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Camera;
    private Rigidbody2D rigid;
    private CinemachineVirtualCamera cam;
    private float Orisize;
    [SerializeField] float speed;
    private float camSize = 6f;
    private float time =0.5f;
    private bool IsZoom = false;
    private Shoot shoot;
    private void Start()
    {
        shoot = player.GetComponent<Shoot>();   
        rigid = player.GetComponent<Rigidbody2D>();
        cam = Camera.GetComponent<CinemachineVirtualCamera>();
        Orisize = cam.m_Lens.OrthographicSize;
    }

   
    private void Update()
    {
        speed = rigid.velocity.magnitude;
        if (rigid.velocity.magnitude > 7 && !shoot.IsGround && !IsZoom)
        {
            cam.m_Lens.OrthographicSize = Mathf.Lerp(Orisize, camSize, 1f); ;
        }
        else if(shoot.IsGround)
        {  
            cam.m_Lens.OrthographicSize =Orisize; ;
        }
    }
}
