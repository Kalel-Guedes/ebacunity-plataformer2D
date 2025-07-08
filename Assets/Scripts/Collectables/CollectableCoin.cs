using UnityEngine;

public class CollectableCoin : CollectableBase
{
    
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins();
        
    }
}
