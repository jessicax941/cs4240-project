using UnityEngine;
using UnityEngine.EventSystems;

using HTC.UnityPlugin.Pointer3D;
using HTC.UnityPlugin.Utility;

public class CustomTeleportable : MonoBehaviour, IPointer3DPressExitHandler
{
    public Transform target;
    public Transform pivot;

    private uint teleportButton = 1 << (int)PointerEventData.InputButton.Right;

    public virtual void OnPointer3DPressExit(Pointer3DEventData eventData)
    {
        var pointerRayCast = eventData.pointerCurrentRaycast;
        
        if (
            teleportButton == 0 || 
            !EnumUtils.GetFlag(teleportButton, (int)eventData.button) ||
            eventData.GetPress() || 
            !pointerRayCast.isValid
            ) { return; }

        if (target == null || pivot == null)
        {
            foreach (Camera camera in Camera.allCameras)
            {
                if (camera.stereoTargetEye != StereoTargetEyeMask.Both)
                {
                    continue;
                }
                pivot = camera.transform;
                
                if (camera.transform.root != null)
                {
                    target = camera.transform.root;
                } else
                {
                    target = camera.transform;
                }
            }
        }


        if (target != null && pivot != null)
        {

            var lookRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(pivot.forward, target.up), target.up);
            var rotation = Quaternion.Inverse(lookRotation) * pointerRayCast.gameObject.transform.rotation * Quaternion.identity;
            var lookVector = Vector3.ProjectOnPlane(pivot.position - target.position, target.up);
      

            target.position = pointerRayCast.worldPosition - (rotation * lookVector);

        }
    }
}