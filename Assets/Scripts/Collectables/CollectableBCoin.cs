using UnityEngine;

public class CollectableBCoin : CollectableBase
{
        
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddBCoins();

    }
}
