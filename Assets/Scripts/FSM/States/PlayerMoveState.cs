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
            //������һغϣ��¼�֪ͨ
            EventCenter.Broadcast<string>(EventType.Event_PlayerMoveStart,"�ҷ��غ�");
            //�ر������ڵ�
            GameManager.Instance.viewMask.SetActive(false);

        }
        public override void ActionState(FSMBase fsm)
        {
         
        }
        public override void ExitState(FSMBase fsm)
        {
            //���������ڵ�
            GameManager.Instance.viewMask.SetActive(true);
        }
    }

}
