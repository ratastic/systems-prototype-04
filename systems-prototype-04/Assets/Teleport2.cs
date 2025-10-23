using UnityEngine;

public class Teleport2 : MonoBehaviour
{
    public Transform teleport;
    public AudioSource ding;
    private void OnTriggerEnter(Collider col)
    {

        Vector3 localOffset = transform.InverseTransformPoint(col.transform.position);
        Quaternion relativeRotation = teleport.rotation * Quaternion.Inverse(transform.rotation);

        if (col.CompareTag("Player"))
        {
            ding.Play();
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.isKinematic = true;

                col.transform.position = teleport.TransformPoint(localOffset);
                col.transform.rotation = relativeRotation * col.transform.rotation;

                rb.isKinematic = false;
            }
        }
    }
}
