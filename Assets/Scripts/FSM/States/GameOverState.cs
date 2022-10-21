using TTTDemo.Event;

namespace TTTDemo.FSM
{
    public class GameOverState : FSMState
    {
        public override void Init()
        {
            StateID = FSMStateID.GameOver;
        }

        public override void EnterState(FSMBase fsm)
        {
            //游戏结束，事件通知
            EventCenter.Broadcast<FSMBase>(EventType.Event_GameOver,fsm);   
           
        }

        public override void ExitState(FSMBase fsm)
        {
           
        }
    }
    


}
