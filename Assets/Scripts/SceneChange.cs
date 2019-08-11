﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject[] panel = new GameObject [2];
    public GameObject touchXXX;

    public void ChangeToMiniGame(){
        if(dateManager.gameRetry > 0) SceneManager.LoadScene("MiniGame");
        else PanelOpen(0,true);
    }

    public void ChangeToMain(){
        if(SceneManager.GetActiveScene().name == "eventScene"
        && dateManager.dateNum % 7 == 6)  SceneManager.LoadScene("SundayScene");
        else SceneManager.LoadScene("MainScreen");
    }

    public void ChangeToDateEvt(){
        // 미니게임을 끝내고 난 뒤 실행
        if(SceneManager.GetActiveScene().name == "MiniGame") ScoreLoad();
        SceneManager.LoadScene("eventScene");
    }

    public void ChangeToList(){
        PanelOpen(2,true);
        //SceneManager.LoadScene("ListScene");
    }

    public void CloseList(){
        if(!panel[1].activeSelf) touchXXX.SetActive(false);
        panel[2].SetActive(false);
    }

    public void ChangeToTalk(){
        PanelOpen(1,true);
    }

    public void StartTalk(){
        SceneManager.LoadScene("TalkScene");
    }

    public void ScoreLoad(){
        // 미니 게임 점수를 메인 화면에 표시
        itemManager.beanNum += scoreManager.beanScore;
        itemManager.diceNum += scoreManager.diceScore;
    }

    public void PanelOpen(int i, bool boolean){
        touchXXX.SetActive(boolean);
        panel[i].SetActive(boolean);
    }

    public void RemovePanel(){
        touchXXX.SetActive(false);
        for(int i = 0; i < panel.Length; i++)
        if(panel[i].activeSelf) panel[i].SetActive(false);
    }


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(450,800,false);
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
