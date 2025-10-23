using System.Runtime.InteropServices;
using UnityEngine;

public class NewPlayerTeleporter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform teleportZoneObj;
    public AudioSource dingSound;


    private void OnTriggerEnter(Collider col)
    {

        Vector3 localOffset = transform.InverseTransformPoint(col.transform.position);
        Quaternion relativeRotation = teleportZoneObj.rotation * Quaternion.Inverse(transform.rotation);

        if (col.CompareTag("Player"))
        {
            dingSound.Play();
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = true;

                col.transform.position = teleportZoneObj.TransformPoint(localOffset);
                col.transform.rotation = relativeRotation * col.transform.rotation;

                rb.isKinematic = false;
            }
        }
    }
}
