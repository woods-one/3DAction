using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    // 周辺レーダーコライダーコール.
    [SerializeField] ColliderCallReceiver aroundColliderCall;

    // 自身のTransform
    [SerializeField] private Transform self;

    //! 遠距離攻撃コルーチン.
    Coroutine farAttackCor;

    void Start()
    {
        aroundColliderCall.TriggerEnterEvent.AddListener(OnAroundTriggerEnter);
        aroundColliderCall.TriggerStayEvent.AddListener(OnAroundTriggerStay);
    }

    void Update()
    {
        
    }

    void OnAroundTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log(123231412);
        }
    }

    void OnAroundTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            self.LookAt(other.gameObject.transform);
        }
    }
}
