using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    public float smooth;
    private Vector3 initalOffset;
    private Vector3 cameraPosition;

    private void Start()
    {
        initalOffset = transform.position - followTransform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPosition = followTransform.position + initalOffset;
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smooth*Time.fixedDeltaTime);
    }
}
