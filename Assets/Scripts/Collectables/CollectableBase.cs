using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        Debug.Log("Collect");        
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect() { }
    
}
