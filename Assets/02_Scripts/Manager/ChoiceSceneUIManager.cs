using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSceneUIManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject selectCanvas;
    public GameObject joinCanvas;

    [HideInInspector] public ChoiceSceneUIController uiController;

    public static ChoiceSceneUIManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("Destroy");
            Destroy(gameObject);
        }

        uiController = GetComponent<ChoiceSceneUIController>();
    }


    private void Start()
    {
        selectCanvas.SetActive(true);
    }





    public void ClickJoin()
    {
        // �̸� �޾Ƽ� ���ӸŴ������� �� �Ѿ��
        // ĳ���� �����Ŵ������� ���������� �� ĳ���� ����
    }

}
