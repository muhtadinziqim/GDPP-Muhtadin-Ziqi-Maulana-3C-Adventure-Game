using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    public CameraState CameraState;

    [SerializeField]
    private CinemachineCamera _fpsCamera;

    public void SetFPSClampedCamera(bool isClamped, Vector3 playerRotation)
    {
        // CinemachinePOV pov = _fpsCamera.GetCinemachineComponent<CinemachinePOV>();
        CinemachinePanTilt pt = _fpsCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim) as CinemachinePanTilt;
        if (isClamped)
        {
            pt.PanAxis.Wrap = false;
            pt.PanAxis.Range = new Vector2(playerRotation.y - 45f, playerRotation.y + 45f);
            // pt.Tilt.Axis.Range = new Vector2(-30, 30);
            // pt.m_HorizontalAxis.m_Wrap = false;
            // pt.m_HorizontalAxis.m_MinValue = playerRotation.y - 45;
            // pt.m_HorizontalAxis.m_MaxValue = playerRotation.y + 45;
        }
        else
        {
            pt.PanAxis.Range = new Vector2(-180f, 180f);
            pt.PanAxis.Wrap = true;
            // pov.m_HorizontalAxis.m_MinValue = -180;
            // pov.m_HorizontalAxis.m_MaxValue = 180;
            // pov.m_HorizontalAxis.m_Wrap = true;
        }
    }
}
