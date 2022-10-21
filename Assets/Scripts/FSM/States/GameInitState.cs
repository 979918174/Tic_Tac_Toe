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
            //屏蔽交互
            GameManager.Instance.viewMask.SetActive(true);
            //创建Grid
            //绘制ButtonView并同步显示
            fsm.GetComponent<GameManager>().EnterGame();
        }

        public override void ExitState(FSMBase fsm)
        {
           
        }
    }
    


}
