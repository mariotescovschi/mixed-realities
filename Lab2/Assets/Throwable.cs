using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Throwable : MonoBehaviour
{
    private Rigidbody rb;
    private XRGrabInteractable grabInteractable;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
            grabInteractable.selectExited.AddListener(OnRelease);
        }
    }
    
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log($"{gameObject.name} grab!");
    }
    
    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log($"{gameObject.name} release!");
    }
    
    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
            grabInteractable.selectExited.RemoveListener(OnRelease);
        }
    }
}
