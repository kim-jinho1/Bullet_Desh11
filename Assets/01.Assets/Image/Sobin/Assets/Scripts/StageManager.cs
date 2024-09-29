using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [SerializeField] private List<Stage_UI> stage = new List<Stage_UI>();
    [SerializeField] int count;
    public static StageManager instance;

    private void Awake()
    {
        if (instance ==null)
        {
            DontDestroyOnLoad(gameObject);
        instance = GetComponent<StageManager>();

        }
        else { Destroy(gameObject); }

    }
    private void Start()
    {
        stage[0].Lock = false;
        count = -1;
    }

    private void Update()
    {
        CheckisLock();
    }

    public void AddStgUI(Stage_UI stage2)
    {
        stage.Add(stage2);
    }
  
    public void TuchCheck()
    {
        for (int i = 0; i < stage.Count; i++)
        {
            if (stage[i].isOn == true)
            {
                if (count == -1)// -1은 비어 있다고 생각하면 됩니다
                {
                    count = i;
                    stage[count].ScaleUP();
                    Debug.Log(1);
                }
                else if(count == i&& stage[i].Lock == false)
                {
                    MoveScene(i+1);
                }
                else if(count == i && stage[i].Lock == true)
                {
                    Debug.Log("잠김");
                }
                else
                {
                    stage[count].ScaleDown();
                    count = i;
                    stage[i].ScaleUP();
                    count = i;
                    Debug.Log(3);
                }
            }

        }
    }

    private void MoveScene(int value)
    {
        SceneManager.LoadScene(value);
    }

    private void CheckisLock()
    {
        for (int i = 1; i < stage.Count; i++)
        {
            if ( stage[i - 1].clear == true)
            {
                stage[i].Lock = false;
            }
           
        }

    }


}
