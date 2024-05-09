using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceSceneUIManager : MonoBehaviour
{
    public CharacterSlot slot;

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
    }






    public void ClickJoin()
    {
        // 이름 받아서 게임매니저에서 씬 넘어가기
        // 캐릭터 생성매니저에서 프리팹으로 된 캐릭터 생성
    }

}
