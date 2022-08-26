
using UnityEngine;
using UnityEngine.InputSystem;

public class EnableWristMenu : MonoBehaviour
{
    public InputActionAsset inputActions;

    private Canvas _wristUI;
    private InputAction _menu;
    // Start is called before the first frame update
    void Start()
    {
        _wristUI = GetComponent<Canvas>();
        _menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Enable-Wrist");
        _menu.Enable();
        _menu.performed += ToggleMenu;

    }

    // Update is called once per frame
    void onDestroy()
    {
        _menu.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context){
        _wristUI.enabled = !_wristUI.enabled;
    }
}
