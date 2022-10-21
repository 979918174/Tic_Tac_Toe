using System.Collections.Generic;
using TTTDemo.GamePlay;
using UnityEngine;
using Common;
using TTTDemo.RunTime;

namespace TTTDemo.FSM
{
    /// <summary>
    /// 状态机
    /// </summary>
    public class FSMBase : MonoBehaviour
    {
        [HideInInspector]
        //条件判断参数
        public NormalTTT normalTtt;
        //状态列表
        public List<FSMState> _states;
        public FSMStateID fSMStateID;
        public FSMState currentState;
        //默认状态
        public FSMState defaultState;
        [Tooltip("默认状态ID")]
        public FSMStateID defaultStateID;

        public void OnEnable()
        {
            InitComponent();
            ConfigFSM();
            InitDefaultState();
        }

        //设置默认状态
        public virtual void InitDefaultState()
        {
            defaultState = ArrayHelper.Find_L(_states, s => s.StateID == defaultStateID);
            currentState = defaultState;
            currentState.EnterState(this);
        }

        //配置状态机，创建状态对象，设置状态（AddMap）
        public virtual void ConfigFSM()
        {
            //用反射创建状态对象
            /*for (int i = 0; i < UPPER; i++)
            {
                Type type = Type.GetType("GameDemo.FSM." + sId + "Trigger");
                FSMState state = Activator.CreateInstance(type) as FSMState;
                _states.Add(state);
            }*/
            
            //手动配置状态机
            _states = new List<FSMState>();
            PlayerMoveState playerMoveState = new PlayerMoveState();
            playerMoveState.AddMap(FSMTriggerID.AITurn, FSMStateID.AIMove);
            playerMoveState.AddMap(FSMTriggerID.GameOver, FSMStateID.GameOver);
            _states.Add(playerMoveState);
            
            AIMoveState aiMoveState = new AIMoveState();
            aiMoveState.AddMap(FSMTriggerID.PlayerTurn, FSMStateID.PlayerMove);
            aiMoveState.AddMap(FSMTriggerID.GameOver, FSMStateID.GameOver);
            _states.Add(aiMoveState);
            
            GameOverState gameOverState = new GameOverState();
            _states.Add(gameOverState);
            
            GameInitState gameInitState = new GameInitState();
            gameInitState.AddMap(FSMTriggerID.AITurn, FSMStateID.AIMove);
            gameInitState.AddMap(FSMTriggerID.PlayerTurn, FSMStateID.PlayerMove);
            _states.Add(gameInitState);
            
        }

        //初始化组件
        public virtual void InitComponent()
        {
            normalTtt = GetComponent<GameManager>().normalTtt;
        }

        //切换状态
        public void ChangeActiveState(FSMStateID stateId)
        {
            //离开上一个状态
            currentState.ExitState(this);
            //设置当前状态
            //如果需要切换的状态编号是：Default，直接返回默认状态
            if (stateId == FSMStateID.GameInit)
            {
                currentState = defaultState;
            }
            else
            {
                //否则从状态列表中查找
                currentState = ArrayHelper.Find_L(_states, s => s.StateID == stateId);
            }
            //进入下一个状态
            currentState.EnterState(this);
        }

        //每帧处理逻辑
        public virtual void Update()
        {
            fSMStateID = currentState.StateID;
            //判断条件是否满足
            currentState.Reason(this);
            //执行当前逻辑
            currentState.ActionState(this);
        }
        public virtual void FixedUpdate()
        {
            currentState.FixActionState(this);
        }
    }
}
