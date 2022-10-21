using System;
using System.Collections;
using System.Collections.Generic;
using TTTDemo.Common;
using TTTDemo.Event;
using TTTDemo.FSM;
using UnityEngine;
using UnityEngine.UI;

namespace TTTDemo.RunTime
{
    /// <summary>
    /// 
    /// </summary>
    
    public class Tips : MonoBehaviour
    {
        public void Awake()
        {
            //ע���¼�
            EventCenter.AddListener<string>(EventType.Event_PlayerMoveStart , ChangeTips);
            EventCenter.AddListener<string>(EventType.Event_AIMoveStart , ChangeTips);
            EventCenter.AddListener<FSMBase>(EventType.Event_GameOver , OverTips);
        }

        public void ChangeTips(string tiptext)
        {
            GetComponentInChildren<Text>().text = tiptext;
        }
        public void OverTips(FSMBase fsm)
        {
            if (fsm.GetComponent<GameManager>().normalTtt.CheckWhoIsWin()==CampType.Player)
            {
                GetComponentInChildren<Text>().text = "ʤ����";
            }

            if (fsm.GetComponent<GameManager>().normalTtt.CheckWhoIsWin()==CampType.AI)
            {
                GetComponentInChildren<Text>().text = "ʧ�ܣ�";
            }
            
            if (fsm.GetComponent<GameManager>().normalTtt.CheckWhoIsWin()==CampType.Zero&&!fsm.GetComponent<GameManager>().normalTtt.IsRemainGrid())
            {
                GetComponentInChildren<Text>().text = "ƽ�֡�";
            }
        }
    }
}
