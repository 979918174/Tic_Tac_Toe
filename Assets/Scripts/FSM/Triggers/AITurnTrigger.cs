
using TTTDemo.Common;
using TTTDemo.RunTime;

namespace TTTDemo.FSM
{
    /// <summary>
    /// ��ǰִ����ΪAI����
    /// </summary>
    public class AITurnTrigger : FSMTrigger
    {
        public override void Init()
        {
            TriggerID = FSMTriggerID.AITurn;
        }

        public override bool HandleTrigger(FSMBase fsm)
        {
            return fsm.GetComponent<GameManager>().currentCamp == CampType.AI;
        }
    }
}
