using System.Collections.Generic;
using System;
using Type = System.Type;

namespace TTTDemo.FSM
{
    /// <summary>
    /// ״̬��
    /// </summary>
    public abstract class FSMState
    {
        public FSMStateID StateID { set; get; }

        //ӳ���
        private Dictionary<FSMTriggerID, FSMStateID> map;

        //�����б�
        private List<FSMTrigger> Triggers;
        
        public FSMState()
        {
            map = new Dictionary<FSMTriggerID, FSMStateID>();
            Triggers = new List<FSMTrigger>();
            Init(); 
        }
        public abstract void Init();

        //��״̬������
        public void AddMap(FSMTriggerID triggerId,FSMStateID stateId)
        {
            //���ӳ��
            map.Add(triggerId,stateId);
            //������������,�����淶 GameDemo.FSM + ����ö�� + Trigger
            CreateTrigger(triggerId);
        }

        private void CreateTrigger(FSMTriggerID triggerId)
        {
            Type type = Type.GetType("TTTDemo.FSM." + triggerId + "Trigger");
            FSMTrigger trigger = Activator.CreateInstance(type) as FSMTrigger;
            Triggers.Add(trigger);
        }

        public virtual void EnterState(FSMBase fsm) { }

        public virtual void ActionState(FSMBase fsm) { }

        public virtual void ExitState(FSMBase fsm) { }

        public virtual void FixActionState(FSMBase fsm) { }

        //��⵱ǰ״̬�������Ƿ�����
        public void Reason(FSMBase fsm)
        {
            for (int i = 0; i < Triggers.Count; i++)
            {
                if (Triggers[i].HandleTrigger(fsm))
                {
                    //�л�״̬
                    FSMStateID stateId = map[Triggers[i].TriggerID];
                    fsm.ChangeActiveState(stateId);
                    return;
                }
            }
        }
    }
}
