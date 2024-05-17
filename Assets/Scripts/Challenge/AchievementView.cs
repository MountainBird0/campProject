﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    [SerializeField] private Transform content;
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        // achievement 데이터에 따라 슬롯을 생성함
        for(int i = 0; i <  achievements.Length; i++)
        {
            var ob = Instantiate(achievementSlotPrefab);
            ob.transform.SetParent(content);
            ob.transform.localScale = Vector3.one;
            var slot = achievementSlotPrefab.GetComponent<AchievementSlot>();
            slot.Init(achievements[i]);

            achievementSlots.Add(achievements[i].threshold, slot);
        }
    }

    public void UnlockAchievement(int threshold)
    {
        // UI 반영 로직
        achievementSlots[threshold].MarkAsChecked();
    }
}