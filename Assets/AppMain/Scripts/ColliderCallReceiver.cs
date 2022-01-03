using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// コライダーコールバックの受信ユーティリティクラス.
/// </summary>
public class ColliderCallReceiver : MonoBehaviour
{
    // トリガーイベント定義クラス.
    public class TriggerEvent : UnityEvent<Collider> { }

    // トリガーイベント定義クラス.
    public class CollisionEvent : UnityEvent<Collision> { }

    // トリガーエンターイベント.
    public TriggerEvent TriggerEnterEvent = new TriggerEvent();
    // トリガーステイイベント.
    public TriggerEvent TriggerStayEvent = new TriggerEvent();
    // トリガーイグジットイベント.
    public TriggerEvent TriggerExitEvent = new TriggerEvent();

    public CollisionEvent CollisionEnterEvent = new CollisionEvent();

    public CollisionEvent CollisionStayEvent = new CollisionEvent();

    public CollisionEvent CollisionExitEvent = new CollisionEvent();


    void Start()
    {

    }

    /// <summary>
    /// トリガーエンターコールバック.
    /// </summary>
    /// <param name="other"> 接触したコライダー. </param>
    void OnTriggerEnter(Collider other)
    {
        TriggerEnterEvent?.Invoke(other);
    }

    /// <summary>
    /// トリガーステイコールバック.
    /// </summary>
    /// <param name="other"> 接触したコライダー. </param>
    void OnTriggerStay(Collider other)
    {
        TriggerStayEvent?.Invoke(other);
    }

    /// <summary>
    /// トリガーイグジットコールバック.
    /// </summary>
    /// <param name="other"> 接触したコライダー. </param>
    void OnTriggerExit(Collider other)
    {
        TriggerExitEvent?.Invoke(other);
    }
}
