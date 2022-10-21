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
            //��Ϸ�������¼�֪ͨ
            EventCenter.Broadcast<FSMBase>(EventType.Event_GameOver,fsm);   
           
        }

        public override void ExitState(FSMBase fsm)
        {
           
        }
    }
    


}
