using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
public class GasBoom : MonoBehaviour
{
    private bool _isTucked = false;
    [SerializeField] GameObject _boom;
    SpriteRenderer SpriteRenderer;


    private void Start()
    {
        SpriteRenderer= _boom.GetComponent<SpriteRenderer>();
    }

    IEnumerator StaredBoom()
    {
        SpriteRenderer.DOColor(Color.red, 2f);
        yield return new WaitForSeconds(2f);
        Debug.Log("Æã");
        //Ä«¸Þ¶ó ½¦ÀÌÅ·
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StaredBoom());
        }
    }


}
