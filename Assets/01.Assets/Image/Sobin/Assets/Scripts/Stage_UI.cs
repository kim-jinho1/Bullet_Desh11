using DG.Tweening;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class Stage_UI : MonoBehaviour
{
    [SerializeField] private Vector3 scale;
    [SerializeField] private float DuringTime = 0.05f;
    private RectTransform rectTransform;
    public bool isOn = false;
    public bool clear = false;
    StageManager manager;
    [SerializeField] public GameObject LockUI;
    [SerializeField] public int Scenenum;

    public float _size = 0;
    public float _upSizeTime = 0.2f;
    public bool Lock;


    private void Update()
    {
        StageUnLock();
    }
    private void Awake()
    {
        
        rectTransform = GetComponent<RectTransform>();
        manager = FindObjectOfType<StageManager>();
    }
    private void Start()
    {
        scale = rectTransform.localScale;
        StageManager.instance.AddStgUI(this);
    }

    public void ScaleUP()
    {
        rectTransform.DOScale(new Vector3(rectTransform.localScale.x + 0.05f, rectTransform.localScale.y + 0.1f, 0), DuringTime);

    }
    public void ScaleDown()
    {
        isOn = false;
        this.rectTransform.DOScale(scale, DuringTime);
    }

    public void Pressed()
    {
        isOn = true;
        Debug.Log(1+"Press");
    }

    private void StageUnLock()
    {
        if(Lock == false)
        {
            LockUI.SetActive(false);
        }
        else
        {
            LockUI.SetActive(true);
        }
   
    }
}