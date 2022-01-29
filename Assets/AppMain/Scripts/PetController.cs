using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    // 周辺レーダーコライダーコール.
    [SerializeField] ColliderCallReceiver aroundColliderCall;


    void Start()
    {
        aroundColliderCall.TriggerEnterEvent.AddListener(OnAroundTriggerEnter);
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
}
