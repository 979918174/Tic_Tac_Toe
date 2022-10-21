using System;
using System.Collections;
using System.Collections.Generic;
using TTTDemo.Common;
using TTTDemo.RunTime;
using UnityEngine;
using UnityEngine.UI;

namespace TTTDemo.RunTime
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderButton : MonoBehaviour
    {
        private void Update()
        {
            //读取先后手
            if (GameManager.Instance.OrderSetting == CampType.Player)
            {
                GetComponentInChildren<Text>().text = "先手";
                GetComponentInChildren<Text>().color = Color.black;
                GetComponent<Image>().color = Color.white;
            }

            if (GameManager.Instance.OrderSetting == CampType.AI)
            {
                GetComponentInChildren<Text>().text = "后手";
                GetComponentInChildren<Text>().color = Color.white;
                GetComponent<Image>().color = Color.black;
            }
        }

        public void ChangeOrder()
        {
            if (GameManager.Instance.OrderSetting == CampType.AI)
            {
                GameManager.Instance.OrderSetting = CampType.Player;
                return;
            }

            if (GameManager.Instance.OrderSetting == CampType.Player)
            {
                GameManager.Instance.OrderSetting = CampType.AI;
            }
            
        }
    }
}
