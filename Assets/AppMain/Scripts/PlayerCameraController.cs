using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    // 回転操作用トランスフォーム.
    [SerializeField] private Transform rotationRoot;
    // 高さ操作用トランスフォーム.
    [SerializeField] private Transform heightRoot;
    // プレイヤーカメラ.
    [SerializeField] private Camera mainCamera;
    // カメラが写す中心のプレイヤーから高さ.
    [SerializeField] private float lookHeight = 1.0f;
    // カメラ回転スピード.
    [SerializeField] private float rotationSpeed = 0.01f;
    // カメラ高さ変化スピード.
    [SerializeField] private float heightSpeed = 0.001f;
    // カメラ移動制限MinMax.
    [SerializeField] private Vector2 heightLimit_MinMax = new Vector2(-1f, 3f);

    [SerializeField] private GameObject mainCame;              //メインカメラ格納用
    [SerializeField] private GameObject playerObject;            //回転の中心となるプレイヤー格納用
    [SerializeField] private float rotateSpeed;

    // タッチスタート位置.
    Vector2 cameraStartTouch = Vector2.zero;
    // 現在のタッチ位置.
    Vector2 cameraTouchInput = Vector2.zero;

    void Update()
    {
        rotateCamera();
    }

    public void UpdateRightTouch(Touch touch)
    {
        // タッチ開始.
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log("右タッチ開始");
            // 開始位置を保管.
            cameraStartTouch = touch.position;
        }
        // タッチ中.
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            Debug.Log("右タッチ中");
            // 現在の位置を随時保管.
            Vector2 position = touch.position;
            // 開始位置からの移動ベクトルを算出.
            cameraTouchInput = position - cameraStartTouch;
            // カメラ回転.
            var yRot = new Vector3(0, cameraTouchInput.x * rotationSpeed, 0);
            var rResult = rotationRoot.rotation.eulerAngles + yRot;
            var qua = Quaternion.Euler(rResult);
            rotationRoot.rotation = qua;

            // カメラ高低.
            var yHeight = new Vector3(0, -cameraTouchInput.y * heightSpeed, 0);
            var hResult = heightRoot.transform.localPosition + yHeight;
            if (hResult.y > heightLimit_MinMax.y) hResult.y = heightLimit_MinMax.y;
            else if (hResult.y <= heightLimit_MinMax.x) hResult.y = heightLimit_MinMax.x;
            heightRoot.localPosition = hResult;
        }
        // タッチ終了.
        else if (touch.phase == TouchPhase.Ended)
        {
            Debug.Log("右タッチ終了");
            cameraTouchInput = Vector2.zero;
        }        // タッチ開始.
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log("右タッチ開始");
            // 開始位置を保管.
            cameraStartTouch = touch.position;
        }
        // タッチ中.
        else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
        {
            Debug.Log("右タッチ中");
            // 現在の位置を随時保管.
            Vector2 position = touch.position;
            // 開始位置からの移動ベクトルを算出.
            cameraTouchInput = position - cameraStartTouch;
            // カメラ回転.
            var yRot = new Vector3(0, cameraTouchInput.x * rotationSpeed, 0);
            var rResult = rotationRoot.rotation.eulerAngles + yRot;
            var qua = Quaternion.Euler(rResult);
            rotationRoot.rotation = qua;

            // カメラ高低.
            var yHeight = new Vector3(0, -cameraTouchInput.y * heightSpeed, 0);
            var hResult = heightRoot.transform.localPosition + yHeight;
            if (hResult.y > heightLimit_MinMax.y) hResult.y = heightLimit_MinMax.y;
            else if (hResult.y <= heightLimit_MinMax.x) hResult.y = heightLimit_MinMax.x;
            heightRoot.localPosition = hResult;
        }
        // タッチ終了.
        else if (touch.phase == TouchPhase.Ended)
        {
            Debug.Log("右タッチ終了");
            cameraTouchInput = Vector2.zero;
        }
    }

    public void FixedUpdateCameraPosition(Transform player)
    {
        this.transform.position = player.position;
    }

    public void UpdateCameraLook(Transform player)
    {
        // カメラをキャラの少し上に固定.
        var cameraMarker = player.position;
        cameraMarker.y += lookHeight;
        var _camLook = (cameraMarker - mainCamera.transform.position).normalized;
        mainCamera.transform.forward = _camLook;
    }
    //カメラを回転させる関数
    private void rotateCamera()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //transform.RotateAround()をしてメインカメラを回転させる
        mainCame.transform.RotateAround(playerObject.transform.position, Vector3.up, angle.x);
        mainCame.transform.RotateAround(playerObject.transform.position, transform.right, angle.y);
    }
}
