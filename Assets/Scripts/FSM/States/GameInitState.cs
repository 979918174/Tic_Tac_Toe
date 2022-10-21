using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using TTTDemo.RunTime;


namespace TTTDemo.FSM
{
    public class GameInitState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.GameInit;
        }

        public override void EnterState(FSMBase fsm)
        {
            //���ν���
            GameManager.Instance.viewMask.SetActive(true);
            //����Grid
            //����ButtonView��ͬ����ʾ
            fsm.GetComponent<GameManager>().EnterGame();
        }

        public override void ExitState(FSMBase fsm)
        {
           
        }
    }
    


}
