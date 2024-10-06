using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timer;
    private float _time;
    
    private void Start()
    {
        _time = 0;
        _timer.text = "";
    }

    private void Update()
    {
         _time += Time.deltaTime/0.1f;
        _timer.text = $"{(_time/60).ToString("F2")} S";
    }
}