﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapIdetify : MonoBehaviour
{
    public Text textArea;
    // Start is called before the first frame update
    void Start()
    {
        textArea.text = "";
    }

    // Update is called once per frame
    void Update()
    {
    }

    int CheckMap(string str){ //string 정보를 번호로 교환
        int index = 0;
        switch(str){
            case "잔디공원": index = 0; break;
            case "바름배움촌": index = 1; break;
            case "회색도심": index = 2; break;
            case "야자바다": index = 3; break;
            case "정글숲": index = 4; break;
            case "북극설원": index = 5; break;
            default: break;
        }
        return index;
    }

    public void checkMap(){
                for(int i = 0; i < 4; i++){
            textArea.text += CheckMap(RandomCourse.placeNow[i].name).ToString();
        }
        textArea.text += "\n";
    }


}
