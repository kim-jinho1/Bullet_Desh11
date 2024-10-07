using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Shoot : MonoBehaviour
{
    private Vector2 _currentPosition;
    private Vector2 _mousePosition;
    private Rigidbody2D rigid;
    [SerializeField] private float Power = 1;
    [SerializeField] private GameObject DotLine;
    private bool isGround;
    public bool IsGround
    {
        get
        {
            return isGround;
        }
        set
        {
            isGround = value;
        }
    }

    private void Start()
    {
        
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            GetTransform();
            GetMousePosition();
            ChangeColor(IsGround);
            DotLine.SetActive(true);
            rotation();
        }
        if(Input.GetMouseButtonUp(0)&&IsGround)
        {
             Vector2 dir = GetDir(_currentPosition, _mousePosition);
            rigid.AddForce(dir*Power, ForceMode2D.Impulse);
            DotLine.SetActive(false);
        }
    }

    private void GetTransform()
    {
        _currentPosition = transform.position;

    }

    private void GetMousePosition()
    {
         _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        
    }
    private Vector2 GetDir(Vector2 current,Vector2 dir)
    {
        Vector2 ShootDir= new Vector2((dir.x-current.x),(dir.y-current.y));
        return ShootDir;
    }

    private void ChangeColor(bool isGround)
    {
        SpriteRenderer sprite = DotLine.GetComponent<SpriteRenderer>();
        if(!isGround)
        {
          sprite.color = Color.red;
        }
        else
        {
            sprite.color = Color.white;
        }
       
    }
    
    private void rotation()
    {
        Vector3 direction = _mousePosition - _currentPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}