using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
 [SerializeField] Transform followTarget = null;
    [SerializeField] Player hotairBalloon = null;
    [SerializeField] Vector3 followVelocity;
    [SerializeField] float followSmoothMaxTime = 0.35f;
    [SerializeField] Camera cam = null;
    [SerializeField] GameObject limitCubeRight = null;

    void OnValidate() {
        UpdateLimitCubeRightReference();
    }

    private void UpdateLimitCubeRightReference() {
        limitCubeRight = GameObject.Find("Limit Cube Group/Limit Cube (Right)");
    }

    void Awake() {
        UpdateLimitCubeRightReference();
    }

    void Start() {
        UpdateHotairBalloon();
        followVelocity = new Vector3(1,1,1);
    }

    public void UpdateHotairBalloon() {
        hotairBalloon = GameObject.FindObjectOfType<Player>();

        if (hotairBalloon != null) {
            var balloonCameraTarget = hotairBalloon.transform.Find("Balloon/Balloon Camera Target");
            if (balloonCameraTarget != null) {
                followTarget = balloonCameraTarget.transform;
            }
        }
    }

    void LateUpdate() {
        if (followTarget != null && hotairBalloon != null) {
            var followTargetPosition = new Vector3(transform.position.x, followTarget.position.y, transform.position.z);
            var followSmoothTime = hotairBalloon.turnSpeed > 0 ? hotairBalloon.maxSpeed * followSmoothMaxTime : 0;
            transform.position = Vector3.SmoothDamp(transform.position, followTargetPosition, ref followVelocity, 3f);
           // transform.position = hotairBalloon.transform.position - transform.position;
        }

        var fovYDeg = cam.fieldOfView;
        var fovXDeg = GetFovXDegFromFovYDeg(fovYDeg, cam.aspect);

        //SushiDebug.Log($"fovYDeg = {fovYDeg}, fovXDeg = {fovXDeg}, aspect = {cam.aspect}");

    }

    public static float GetFovXDegFromFovYDeg(float fovYDeg, float aspect) {
        return 2 * Mathf.Atan(Mathf.Tan(fovYDeg * Mathf.Deg2Rad / 2) * aspect) * Mathf.Rad2Deg;
    }

    public static float GetFovYDegFromFovXDeg(float fovXDeg, float aspect) {
        return 2 * Mathf.Atan(Mathf.Tan(fovXDeg * Mathf.Deg2Rad / 2) / aspect) * Mathf.Rad2Deg;
    }
}
