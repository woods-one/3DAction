using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject attackHit;
    [SerializeField] private Animator animator;
    [SerializeField] float jumpPower = 20f;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private ColliderCallReceiver footColliderCall;

    // PCキー横方向入力.
    private float horizontalKeyInput = 0;
    // PCキー縦方向入力.
    private float verticalKeyInput = 0;

    private bool isAttack = false;
    private bool isGround = false;

    void Start()
    {
        animator.SetBool("isGround", true);
        attackHit.SetActive(false);
    }

    void Update()
    {
        horizontalKeyInput = Input.GetAxis("Horizontal");
        verticalKeyInput = Input.GetAxis("Vertical");

        bool isKeyInput = (horizontalKeyInput != 0 || verticalKeyInput != 0);
        if (isKeyInput == true && isAttack == false)
        {
            bool currentIsRun = animator.GetBool("isRun");
            if (currentIsRun == false) animator.SetBool("isRun", true);
            Vector3 dir = rigid.velocity.normalized;
            dir.y = 0;
            this.transform.forward = dir;
        }
        else
        {
            bool currentIsRun = animator.GetBool("isRun");
            if (currentIsRun == true) animator.SetBool("isRun", false);
        }
    }

    void FixedUpdate()
    {
        if (isAttack == false)
        {
            Vector3 input = new Vector3(horizontalKeyInput, 0, verticalKeyInput);
            Vector3 move = input.normalized * 2f;
            Vector3 cameraMove = Camera.main.gameObject.transform.rotation * move;
            cameraMove.y = 0;
            Vector3 currentRigidVelocity = rigid.velocity;
            currentRigidVelocity.y = 0;

            rigid.AddForce(cameraMove - currentRigidVelocity, ForceMode.VelocityChange);
        }
    }

    /// <summary>
    /// 攻撃ボタンクリックコールバック.
    /// </summary>
    public void OnAttackButtonClicked()
    {
        if (isAttack == false)
        {
            // AnimationのisAttackトリガーを起動.
            animator.SetTrigger("isAttack");
            // 攻撃開始.
            isAttack = true;
        }
    }

    /// <summary>
    /// ジャンプボタンクリックコールバック.
    /// </summary>
    public void OnJumpButtonClicked()
    {
        if (isGround)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// FootSphereトリガーステイコール.
    /// </summary>
    /// <param name="col"> 侵入したコライダー. </param>
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            if (isGround == false) isGround = true;
            if (animator.GetBool("isGround") == false) animator.SetBool("isGround", true);
        }
    }
    
    /// <summary>
    /// FootSphereトリガーイグジットコール.
    /// </summary>
    /// <param name="col"> 侵入したコライダー. </param>
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = false;
            animator.SetBool("isGround", false);
        }
    }

    /// <summary>
    /// 攻撃アニメーションHitイベントコール.
    /// </summary>
    void Anim_AttackHit()
    {
        Debug.Log("Hit");
        // 攻撃判定用オブジェクトを表示.
        attackHit.SetActive(true);
    }

    /// <summary>
    /// 攻撃アニメーション終了イベントコール.
    /// </summary>
    void Anim_AttackEnd()
    {
        Debug.Log("End");
        // 攻撃判定用オブジェクトを非表示に.
        attackHit.SetActive(false);
        // 攻撃終了.
        isAttack = false;
    }
}
