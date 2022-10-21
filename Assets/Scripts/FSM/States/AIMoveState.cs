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
            //����AI�غϣ��¼�֪ͨ
            EventCenter.Broadcast<string>(EventType.Event_AIMoveStart,"�з��غ�");
            //���ν���
            GameManager.Instance.viewMask.SetActive(true);
            NormalTTT normalTtt = fsm.GetComponent<GameManager>().normalTtt;
            //�ж�AI����ִ������
            fsm.GetComponent<GameManager>().tttai.ExecuteStep(normalTtt);
            GameManager.Instance.normalTtt.CheckGridsStatus();
            //ˢ�±���
            GameManager.Instance.RefreshView();
            //AI�غϽ������¼�֪ͨ
            EventCenter.Broadcast(EventType.Event_TurnOver);
        }

        public override void ExitState(FSMBase fsm)
        {
           
        }
    }
}
