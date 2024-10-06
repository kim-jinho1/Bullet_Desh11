using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private Vector2 _currentPosition;
    private Vector2 _mousePosition;
    private Rigidbody2D rigid;
    [SerializeField] private float Power = 1;
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
            transform.rotation = Quaternion.Euler(GetDir(_currentPosition, _mousePosition));
        }
        if(Input.GetMouseButtonUp(0))
        {
             Vector2 dir = GetDir(_currentPosition, _mousePosition);
            rigid.AddForce(dir*Power, ForceMode2D.Impulse);

            
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
}