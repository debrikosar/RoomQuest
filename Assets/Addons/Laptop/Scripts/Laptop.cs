using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laptop : MonoBehaviour, IInteract
{
    [SerializeField]
    private PlayerControl playerControl;

    [SerializeField]
    private Camera gameCamera;

    [SerializeField]
    private GameObject targetPosition;

    [SerializeField]
    private Canvas DesktopCanvas;

    private bool isCameraZoom;
    private float speed = 3f;
    private GameObject cameraTransformData;
    private Coroutine startedCoroutine;

    public void Start()
    {
        cameraTransformData = new GameObject();
    }

    public void ToInteract()
    {
        if (!isCameraZoom)
        {
            startedCoroutine = StartCoroutine(ZoomCoroutine(targetPosition.transform));
        }
        else
        {
            startedCoroutine = StartCoroutine(ZoomCoroutine(cameraTransformData.transform));
        }
        SwitchPlayerControl();
    }

    public IEnumerator ZoomCoroutine(Transform ZoomTo)
    {
        if (!isCameraZoom)
        {
            SaveCameraPosition();
            speed = 3;
        }
        else
            speed = 7;
            

        isCameraZoom = !isCameraZoom;

        while (Vector3.Distance(gameCamera.transform.position, ZoomTo.position) >= 0.1f || Quaternion.Angle(gameCamera.transform.rotation, ZoomTo.rotation) >= 0.1f)
        {
            gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, ZoomTo.position, speed * Time.deltaTime);
            gameCamera.transform.rotation = Quaternion.Lerp(gameCamera.transform.rotation, ZoomTo.rotation, speed * Time.deltaTime);

            Debug.Log(gameCamera.transform.position + "|||" + ZoomTo.transform.position);

            yield return new WaitForEndOfFrame();          
        }
        StopCoroutine(startedCoroutine);

        //while (gameCamera.transform.position.normalized != ZoomTo.position.normalized || gameCamera.transform.rotation.normalized != ZoomTo.rotation.normalized)
        //{
        //    gameCamera.transform.position = Vector3.Lerp(gameCamera.transform.position, ZoomTo.position, speed * Time.deltaTime);
        //    gameCamera.transform.rotation = Quaternion.Lerp(gameCamera.transform.rotation, ZoomTo.rotation, speed * Time.deltaTime);

        //    Debug.Log(gameCamera.transform.position + "|||" + ZoomTo.transform.position);

        //    yield return new WaitForEndOfFrame();
        //}
    }

    public void SaveCameraPosition()
    {
        cameraTransformData.transform.position = gameCamera.transform.position;
        cameraTransformData.transform.rotation = gameCamera.transform.rotation;
    }

    public void SwitchPlayerControl()
    {
        playerControl.enabled = !playerControl.enabled;
        Cursor.visible = !Cursor.visible;

        if (Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
        else
            Cursor.lockState = CursorLockMode.Locked;
    }

    public void OffButtonClick()
    {
        ToInteract();
        DesktopCanvas.enabled = false;
    }

    public void ShowHint()
    {
        throw new System.NotImplementedException();
    }
}
