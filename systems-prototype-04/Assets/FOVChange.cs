using UnityEngine;

public class FOVChange : MonoBehaviour
{
    public Camera playerCam;
    public float fovMin = 9f;
    public float fovMax = 90f;
    public float speed = .2f; 

    void Start()
    {
        playerCam.fieldOfView = 60f;
    }

    void Update()
    {
        float startT = Mathf.InverseLerp(fovMin, fovMax, 60f);
        float t = Mathf.PingPong(Time.time * speed + startT, 1f);
        playerCam.fieldOfView = Mathf.Lerp(fovMin, fovMax, t);
    }
}