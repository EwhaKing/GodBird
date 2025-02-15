﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class dailyEvent : MonoBehaviour
{
    public Text eventTxt, content;
    int dateNum = -1;
    // Start is called before the first frame update
    void Start()
    {
        dateNum = dateManager.dateNum % 7;

        int chBuff = churchManager.chAbility[churchManager.chLevel];
        int index = 0;
        int npcBuff = 1;

        foreach(bool isTrue in npcManager.npcList){
            if(isTrue) npcBuff *= npcManager.npcAbilty[index]; index++;
        }


        itemManager.birdNum += chBuff*npcBuff;
        eventTxt.text = "드디어 시작합니다."; content.text = "";
        if(dateManager.dateNum != 0) eventSelect();


    }

    // Update is called once per frame
    void Update()
    {

    }

    void eventSelect(){
        int eventNum = Random.Range(0,960);

        eventTxt.text = "오늘도 평온합니다."; content.text = "";

        if(dateNum == 3){ // 목요일 이벤트
            eventTxt.text = "오늘은 헌금의 날입니다.";
            content.text = "신도들에게서\n" + 
            itemManager.birdNum.ToString() + "콩을 받았습니다.";
            itemManager.beanNum += itemManager.birdNum;
        } 
        else if(dateNum == 6){ // 일요일 이벤트
            eventTxt.text = "오늘은 예배당 유지비를\n내는 날입니다.";
            content.text = "증축을 위해\n콩을 납부해주세요.";
        } 
        else if (eventNum > 700) { 

            if(eventNum < 750 && itemManager.beanNum >= 100){ // 몰수 이벤트
                int rand = Random.Range(50, 2 + itemManager.beanNum/2);
                eventTxt.text = "자금을 도둑 맞았습니다.";
                content.text = rand.ToString() + "콩이 사라졌습니다.";
                itemManager.beanNum -= rand;
            }
            else if (eventNum < 850){ // 콩 입수 이벤트
                int rand = Random.Range(50, 301);
                eventTxt.text = "기부금액이 들어왔습니다.";
                content.text = rand.ToString() + "콩을 얻었습니다.";
                itemManager.beanNum += rand;
            }
            else if (eventNum < 950 && itemManager.birdNum >= 4 ){ // 신자 감소
                int rand = Random.Range(1, (int) itemManager.birdNum/2);
                eventTxt.text = "유언비어로 인해\n안좋은 소문이 퍼졌습니다.";
                content.text = rand.ToString() + "마리의 신도가 사라졌습니다.";
                itemManager.birdNum -= rand;
            }
            else if (eventNum < 960 ){ // 신자 증가
                int rand = Random.Range(1, (int) itemManager.birdNum/3);
                eventTxt.text = "당신의 신앙에\n많은 새들이 감동받았습니다.";
                content.text = rand.ToString() + "마리의 신도가 들어왔습니다.";
                itemManager.birdNum += rand;
            }
        }
        

    }
}
