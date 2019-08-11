﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class successEvent : MonoBehaviour
{
    public GameObject scsPanel, touchXXX;
    public Text panelText;
    public static bool isClear;
    // Start is called before the first frame update
    void Start()
    {
        touchXXX.SetActive(true);
        scsPanel.SetActive(true);

        if(itemManager.beanNum >= debtManager.debt) {
            itemManager.beanNum -= debtManager.debt;
            debtManager.debt = 0;
            panelText.text = "축하합니다!\n\n" + "유지보수가 이뤄졌습니다.";
            isClear = true;
        } else {
            // 빚을 못갚으면 빚이 누적된다??
            panelText.text = "안타깝군요...\n\n" + "실망한 신자 몇명이 떠났습니다.";
            float decrese = itemManager.birdNum * 0.3f;
            itemManager.birdNum -= (int) decrese;
            // 첫번째 실패 -> 신도수 30% 감소
            // 그 이후 실패 -> 게임 오버 (아직 미구현)
            isClear = false;
        }
    }

}
