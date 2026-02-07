using UnityEngine;

public class BookFloatAndLook : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public Camera cam;
    public float maxTiltAngle = 10f;
    public float lookSpeed = 5f;

    [Header("Floating Settings")]
    public float floatHeight = 0.2f;
    public float floatSpeed = 1.5f;
    public float floatRotationAmount = 5f;

    Vector3 startPos;
    Quaternion startRot;

    float floatTimer;

    void Start()
    {
        startPos = transform.localPosition;
        startRot = transform.localRotation;

        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        ApplyFloating();
        ApplyMouseLook();
    }

    void ApplyFloating()
    {
        floatTimer += Time.deltaTime * floatSpeed;

        float yOffset = Mathf.Sin(floatTimer) * floatHeight;
        float rotOffset = Mathf.Sin(floatTimer * 0.7f) * floatRotationAmount;

        transform.localPosition =
            startPos + new Vector3(0, yOffset, 0);

        transform.localRotation *= Quaternion.Euler(0, 0, rotOffset * Time.deltaTime);
    }

    void ApplyMouseLook()
    {
        if (cam == null) return;

        Vector3 mousePos = Input.mousePosition;

        // convert mouse to viewport space (-1 to 1 range)
        Vector3 viewport = cam.ScreenToViewportPoint(mousePos);

        float xTilt = Mathf.Lerp(-maxTiltAngle, maxTiltAngle, viewport.y);
        float yTilt = Mathf.Lerp(-maxTiltAngle, maxTiltAngle, viewport.x);

        Quaternion targetTilt =
            startRot * Quaternion.Euler(xTilt, -yTilt, 0);

        transform.localRotation =
            Quaternion.Slerp(
                transform.localRotation,
                targetTilt,
                Time.deltaTime * lookSpeed
            );
    }
}
