using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StopButton : MonoBehaviour
{

    [SerializeField] private GameObject _panel;
    [SerializeField] private bool _IsOpen = false;
    [SerializeField] private GameObject _stopImage;
    [SerializeField] private GameObject _restartImage;
    SceneManager _sceneManager;
    public void Pressed()
    {
        _IsOpen = !_IsOpen;
        _panel.SetActive(_IsOpen);
       if(_IsOpen)
        {
            _stopImage.SetActive(false);
            _restartImage.SetActive(true);
            Stop_Restart(_IsOpen);
            
        }
       else
        {
            _restartImage.SetActive(false);
            _stopImage.SetActive(true);
            Stop_Restart(_IsOpen);
        }
    }
    
    private void Stop_Restart(bool value)
    {
        if(value)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

}
