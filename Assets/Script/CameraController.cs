using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera Camera1;
    [SerializeField] private Camera Camera2;

    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;

    void Start()
    {
        currentView = views[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            OnEnable();
            currentView = views[1 - Array.IndexOf(views, currentView)]; // 2つの視点を切り替える
        }

        // スムーズに視点を切り替える
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;
    }

    private void OnEnable()
    {
        Camera1.enabled = !Camera1.enabled;
        Camera2.enabled = !Camera2.enabled;
    }
}
