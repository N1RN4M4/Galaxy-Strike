using UnityEngine;
using UnityEngine.InputSystem;
// using UnityEngine.UIElements; 

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;

    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }
    
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (var laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        if (crosshair == null) return;

        // If the new Input System package is enabled and a Mouse is available, use it.
        // This avoids InvalidOperationException when Player Settings is set to the Input System.
        Vector3 mousePos = Vector3.zero;
        #if ENABLE_INPUT_SYSTEM
                if (UnityEngine.InputSystem.Mouse.current != null)
                {
                    var mp = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
                    mousePos = new Vector3(mp.x, mp.y, 0f);
                    crosshair.position = mousePos;
                    return;
                }
        #endif

        // Fallback to legacy Input if available (or if Input System isn't present)
        mousePos = Input.mousePosition;
        crosshair.position = mousePos;
    }
}
