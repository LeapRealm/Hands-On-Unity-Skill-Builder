using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float keyboardMoveSpeed;
    [SerializeField] private float mouseMoveSpeed;
    [SerializeField] private float wheelZoomSpeed;
    private Vector3 moveDirection;
    private Vector3 originMousePosition;
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        KeyboardMove();
        MouseMove();
        MouseZoomInOut();
    }

    private void KeyboardMove()
    {
        float moveX = Input.GetAxis("ArrowHorizontal");
        float moveZ = Input.GetAxis("ArrowVertical");

        moveDirection = new Vector3(moveX, 0f, moveZ).normalized;
        transform.position += moveDirection * keyboardMoveSpeed * Time.deltaTime;
    }

    private void MouseMove()
    {
        if (Input.GetMouseButtonDown(1))
            originMousePosition = Input.mousePosition;
        
        if (!Input.GetMouseButton(1))
            return;

        Vector3 moveDifference = Input.mousePosition - originMousePosition;
        moveDirection = new Vector3(moveDifference.x, 0f, moveDifference.y).normalized;
        transform.position += moveDirection * mouseMoveSpeed * Time.deltaTime;
    }

    private void MouseZoomInOut()
    {
        float wheelAxis = Input.GetAxis("Mouse ScrollWheel");

        playerCamera.fieldOfView += wheelAxis * wheelZoomSpeed * -1f;
        playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 10f, 60f);
    }
}