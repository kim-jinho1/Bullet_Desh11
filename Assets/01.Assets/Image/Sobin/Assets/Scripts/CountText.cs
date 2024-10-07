using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountText : MonoBehaviour
{
    [SerializeField] private Text count;
    private int _count;
    private void Start()
    {
        _count = 0;
        
    }
    public int Count
    {
        get
        {
            return _count;
        }

        set
        {
            _count = value;
        }
    }

    public void AddCount()
    {
        Count++;
        count.text = $"{Count}N";
    }
}
