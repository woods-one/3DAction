using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PowerUp : ItemBase
{
    [Header("Item Param")]
    // 
    [SerializeField] int powerUpPoint;

    protected override void Start()
    {
        base.Start();
    }

    // -------------------------------------------------------------
    /// <summary>
    /// アイテム取得時処理.
    /// </summary>
    /// <param name="col"> 侵入してきたコライダー. </param>
    // -------------------------------------------------------------
    protected override void ItemAction(Collider col)
    {
        base.ItemAction(col);
        var player = col.gameObject.GetComponent<PlayerController>();
        if (!player.isPowerUpTime)
        {
            player.PowerUpCoroutineStart(powerUpPoint);
        }
    }
}
