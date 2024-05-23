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
        // [�������� 1] actionAsset���� Space �׼��� ã�� Ȱ��ȭ�մϴ�.
        spaceAction = actionAsset.FindAction("Space");
        if (spaceAction != null)
        {
            Debug.Log("ã��");
            spaceAction.performed += OnClick;
            spaceAction.Enable();
        }
    }

    // [�������� 2] ContextMenu ��Ʈ����Ʈ�� Ȱ���ؼ� �ν�����â���� ������ �� �ֵ��� ��
    [ContextMenu("Rebind")]
    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;

        // [�������� 3] ���� ���ε��� ��Ȱ��ȭ�ϰ� �� Ű�� ����ε�
        spaceAction.Disable();

        // ��� ���ε��� �����մϴ�.
        spaceAction.RemoveAllBindingOverrides();

        // ���ο� ���ε��� �߰��մϴ�.
        spaceAction.ApplyBindingOverride("<Keyboard>/escape");

        // �׼��� �ٽ� Ȱ��ȭ�մϴ�.
        spaceAction.Enable();

        Debug.Log("Done!");
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("����");
    }

    void OnDestroy()
    {
        // �׼��� ��Ȱ��ȭ�մϴ�.
        spaceAction?.Disable();
    }
}
