using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class Rotate3DObject1 : MonoBehaviour
{
    #region Input Actions
    [SerializeField]
    private InputActionAsset _actions;

    public InputActionAsset actions
    {
        get => _actions;//get player input
        set => _actions = value;//set player input value 
    }

    protected InputAction leftClickPressedInputAction { get; set; }

    protected InputAction mouseLookInputAction { get; set; }

   

    #endregion

    #region Variables

    private bool rotateAllowed;//allowed only press the Left Button

    private Camera _camera;

    [SerializeField] private float speed;//speed for rotation

    [SerializeField] private bool inverted;//for inverting the axis rotation

    #endregion

    private void Awake()
    {
        InitializeInputSystem();
    }

    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;//hide the mouse arrow

        _camera = Camera.main;//get camera
    }

    private void InitializeInputSystem()
    {
        leftClickPressedInputAction = actions.FindAction("Left Click");//get PlayerInputSystem Actions "LeftClick"
        if (leftClickPressedInputAction != null)
        {
            leftClickPressedInputAction.started += OnLeftClickPressed;
            leftClickPressedInputAction.performed += OnLeftClickPressed;
            leftClickPressedInputAction.canceled += OnLeftClickPressed;
        }

        mouseLookInputAction = actions.FindAction("Mouse Look");//get PlayerInputSystem Action "MouseLook"

        actions.Enable();

       
    }

    protected virtual void OnLeftClickPressed(InputAction.CallbackContext context)
    {
        if (context.started || context.performed)
        {
            rotateAllowed = true;//started || performed->true//set rotateAllowed->true
        }
        else if (context.canceled)
            rotateAllowed = false;// release the leftclick, set rotateAllowed->false

    }

    protected virtual Vector2 GetMouseLookInput()
    {
        if (mouseLookInputAction != null)
            return mouseLookInputAction.ReadValue<Vector2>();//check inputaction->not null

        return Vector2.zero;
    }

    private void Update()
    {
        if (!rotateAllowed)
            return;//check rotateAllowed, if null return avoid EX calculation

        Vector2 MouseDelta = GetMouseLookInput();//store MouseDelta as Vector2

        MouseDelta *= speed * Time.deltaTime;

        transform.Rotate(Vector3.up * (inverted ? -1 : 1), MouseDelta.x, Space.World);//rotate GameObject by world location,left and right 
        //transform.Rotate(Vector3.right * (inverted ? 1 : -1), MouseDelta.y, Space.World);// rotate GameObject by world location, up and down
    }
}
