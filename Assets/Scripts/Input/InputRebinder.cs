using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;

    void Start()
    {
        // [구현사항 1] actionAsset에서 Space 액션을 찾고 활성화합니다.
        spaceAction = actionAsset.FindAction("Space");
        if (spaceAction != null)
        {
            Debug.Log("찾음");
            spaceAction.performed += OnClick;
            spaceAction.Enable();
        }
    }

    // [구현사항 2] ContextMenu 어트리뷰트를 활용해서 인스펙터창에서 적용할 수 있도록 함
    [ContextMenu("Rebind")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        // [구현사항 3] 기존 바인딩을 비활성화하고 새 키로 재바인딩
        spaceAction.Disable();

        // 모든 바인딩을 제거합니다.
        spaceAction.RemoveAllBindingOverrides();

        // 새로운 바인딩을 추가합니다.
        spaceAction.ApplyBindingOverride("<Keyboard>/escape");

        // 액션을 다시 활성화합니다.
        spaceAction.Enable();

        Debug.Log("Done!");
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("누름");
    }

    void OnDestroy()
    {
        // 액션을 비활성화합니다.
        spaceAction?.Disable();
    }
}
