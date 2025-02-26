using UnityEngine;

public class LineofSightDetector : MonoBehaviour
{
    [SerializeField]
    private LayerMask playerLayerMask;
    [SerializeField]
    private float detectionRange = 10.0f;
    [SerializeField]
    private float detectionHeight = 1f;
    [SerializeField]
    private bool showDebugVisuals = true;

    public GameObject PerformDetection(GameObject potentialTarget)
    {
        // Null check for potential target
        if (potentialTarget == null)
        {
            Debug.LogWarning("Potential target is null.");
            return null;
        }

        // Check if playerLayerMask is set
        if (playerLayerMask == 0)
        {
            Debug.LogWarning("Player Layer Mask is not set. Please assign a layer mask in the Inspector.");
            return null;
        }

        // Perform raycast
        RaycastHit hit;
        Vector3 direction = (potentialTarget.transform.position - transform.position).normalized;
        bool hasHit = Physics.Raycast(transform.position + Vector3.up * detectionHeight, direction, out hit, detectionRange, playerLayerMask);

        // Debug visuals
        if (showDebugVisuals && this.enabled)
        {
            Debug.DrawLine(transform.position + Vector3.up * detectionHeight, potentialTarget.transform.position, hasHit ? Color.green : Color.red);
        }

        // Check if the hit object is the potential target
        if (hasHit && hit.collider.gameObject == potentialTarget)
        {
            Debug.Log("Detected: " + hit.collider.gameObject.name);
            return hit.collider.gameObject;
        }

        return null;
    }

    private void OnDrawGizmos()
    {
        if (showDebugVisuals)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + Vector3.up * detectionHeight, 0.3f);
            Gizmos.DrawLine(transform.position + Vector3.up * detectionHeight, transform.position + Vector3.up * detectionHeight + transform.forward * detectionRange);
        }
    }
}