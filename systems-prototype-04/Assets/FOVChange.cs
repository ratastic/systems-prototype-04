using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;

public class FOVChange : MonoBehaviour
{
    public Camera playerCam;
    public Volume gv;
    private Vignette vignette;
    public float fovMin = 9f;
    public float fovMax = 90f;
    public float speed = .2f;
    public float vigMin = .4f;
    public float vigMax = .6f;

    void Start()
    {
        playerCam.fieldOfView = 60f;

        if (gv.profile.TryGet(out vignette))
        {
            Debug.Log("vigentte found");
        }
    }

    void Update()
    {
        FOV();
        Vignette();
    }

    public void FOV()
    {
        float startT = Mathf.InverseLerp(fovMin, fovMax, 60f);
        float t = Mathf.PingPong(Time.time * speed + startT, 1f);
        playerCam.fieldOfView = Mathf.Lerp(fovMin, fovMax, t);
    }

    public void Vignette()
    {
        float startV = Mathf.InverseLerp(vigMin, vigMax, .4f);
        float v = Mathf.PingPong(Time.time * speed + startV, 1f);
        vignette.intensity.value = Mathf.Lerp(vigMin, vigMax, v);
    }
}