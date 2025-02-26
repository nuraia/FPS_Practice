using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Range Detector", story: "Update Range [Detector] and Assign [Target]", category: "Action", id: "74b36cf8e2a79585e715caa0548847b0")]
public partial class RangeDetectorAction : Action
{
    [SerializeReference] public BlackboardVariable<RangeDetector> Detector;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    protected override Status OnUpdate()
    {
        Target.Value = Detector.Value.UpdateDetector();
        return Target.Value == null? Status.Failure : Status.Success;
    }

 
}

