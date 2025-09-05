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

    [SerializeField]
    private CinemachineCamera _tpsCamera;


    [SerializeField]
    private InputManager _inputManager;


    void Start()
    {
        _inputManager.OnChangePOV += SwitchCamera;
    }

    void OnDestroy()
    {
        _inputManager.OnChangePOV -= SwitchCamera;
    }

    public void SetFPSClampedCamera(bool isClamped, Vector3 playerRotation)
    {
        // CinemachinePOV pov = _fpsCamera.GetCinemachineComponent<CinemachinePOV>();
        CinemachinePanTilt pt = _fpsCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim) as CinemachinePanTilt;
        if (isClamped)
        {
            pt.PanAxis.Wrap = false;
            pt.PanAxis.Range = new Vector2(playerRotation.y - 45f, playerRotation.y + 45f);
        }
        else
        {
            pt.PanAxis.Range = new Vector2(-180f, 180f);
            pt.PanAxis.Wrap = true;
        }
    }

    private void SwitchCamera()
    {
        if (CameraState == CameraState.ThirdPerson)
        {
            CameraState = CameraState.FirstPerson;
            _tpsCamera.gameObject.SetActive(false);
            _fpsCamera.gameObject.SetActive(true);
        }
        else
        {
            CameraState = CameraState.ThirdPerson;
            _tpsCamera.gameObject.SetActive(true);
            _fpsCamera.gameObject.SetActive(false);
        }
    }

    public void SetTPSFieldOfView(float fieldOfView)
    {
        // _tpsCamera.m_Lens.FieldOfView = fieldOfView;
        _tpsCamera.Lens.FieldOfView = fieldOfView;
    }
}
