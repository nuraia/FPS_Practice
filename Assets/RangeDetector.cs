using UnityEngine;

public class RangeDetector : MonoBehaviour
{
    [Header("Detection Setting")]
    [SerializeField] private float detectionRadius = 10f;
    [SerializeField] private LayerMask detectionMask;
    [SerializeField] private bool showDebugVisuals = true;

    public GameObject DetectTarget
    {  get; 
       set; 
    }
    
    public GameObject UpdateDetector()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionMask);
        if(colliders.Length > 0 )
        {
            DetectTarget = colliders[0].gameObject;
        }
        else 
        { 
            DetectTarget = null;
        }
        return DetectTarget;
    }
    public void OnDrawGizmos()
    {
        if(!showDebugVisuals || this.enabled == false) return;
        Gizmos.color = DetectTarget ? Color.green : Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
