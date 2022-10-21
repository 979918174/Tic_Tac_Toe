using TTTDemo.Event;
using TTTDemo.RunTime;

namespace TTTDemo.FSM
{
    public class PlayerMoveState : FSMState
    {
       
        public override void Init()
        {
            StateID = FSMStateID.PlayerMove;
        }

        public override void EnterState(FSMBase fsm)
        {
            //进入玩家回合，事件通知
            EventCenter.Broadcast<string>(EventType.Event_PlayerMoveStart,"我方回合");
            //关闭棋盘遮挡
            GameManager.Instance.viewMask.SetActive(false);

        }
        public override void ActionState(FSMBase fsm)
        {
         
        }
        public override void ExitState(FSMBase fsm)
        {
            //开启棋盘遮挡
            GameManager.Instance.viewMask.SetActive(true);
        }
    }

}
