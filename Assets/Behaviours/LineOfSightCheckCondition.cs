using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Line of Sight check", story: "Check [Target] with Line of Sight [Detector]", category: "Conditions", id: "1dfc160b73a787da1c81c79b47ee25b5")]
public partial class LineOfSightCheckCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<LineofSightDetector> Detector;

    public override bool IsTrue()
    {
        Debug.Log(Detector.Value.PerformDetection(Target.Value) == null);
        return Detector.Value.PerformDetection(Target.Value) == null;

    }

  
}
