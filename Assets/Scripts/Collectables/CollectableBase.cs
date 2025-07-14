using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    public ParticleSystem particles;

    public GameObject graphicItem;


    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) graphicItem.SetActive(false);
        Debug.Log("Collect");
        OnCollect();
        Invoke("HideObject", 3f);
        
    }


    protected virtual void OnCollect()
    {
        if (particles != null) particles.Play();
    }
    
}
