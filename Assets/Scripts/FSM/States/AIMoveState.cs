using TTTDemo.Event;
using TTTDemo.GamePlay;
using TTTDemo.RunTime;
namespace TTTDemo.FSM
{
    public class AIMoveState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.AIMove;
        }

        public override void EnterState(FSMBase fsm)
        {
            //进入AI回合，事件通知
            EventCenter.Broadcast<string>(EventType.Event_AIMoveStart,"敌方回合");
            //屏蔽交互
            GameManager.Instance.viewMask.SetActive(true);
            NormalTTT normalTtt = fsm.GetComponent<GameManager>().normalTtt;
            //判断AI类型执行落子
            fsm.GetComponent<GameManager>().tttai.ExecuteStep(normalTtt);
            GameManager.Instance.normalTtt.CheckGridsStatus();
            //刷新表现
            GameManager.Instance.RefreshView();
            //AI回合结束，事件通知
            EventCenter.Broadcast(EventType.Event_TurnOver);
        }

        public override void ExitState(FSMBase fsm)
        {
           
        }
    }
}
