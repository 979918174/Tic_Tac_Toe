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
    public class AIButton : MonoBehaviour
    {
        private void Update()
        {
            //��ȡ�Ⱥ���
            if (GameManager.Instance.AISetting == AIType.Easy)
            {
                GetComponentInChildren<Text>().text = "��";
                GetComponentInChildren<Text>().color = Color.black;
                GetComponent<Image>().color = Color.white;
            }

            if (GameManager.Instance.AISetting == AIType.Special)
            {
                GetComponentInChildren<Text>().text = "����";
                GetComponentInChildren<Text>().color = Color.white;
                GetComponent<Image>().color = Color.black;
            }
        }

        public void ChangeAI()
        {
            if (GameManager.Instance.AISetting == AIType.Easy)
            {
                GameManager.Instance.AISetting = AIType.Special;
                return;
            }

            if (GameManager.Instance.AISetting == AIType.Special)
            {
                GameManager.Instance.AISetting = AIType.Easy;
            }
            
        }
    }
}
