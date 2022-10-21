using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common
{
    /// <summary>
    /// �ű������� ������Ψһ
    /// </summary>
    /// <typeparam name="T"></typeparam>
   public class MonoSingleton<T> : MonoBehaviour where T: MonoSingleton<T>
    {
        //T ��ʾ�������ͣ�Լ��Ϊ�����������
        //public static T Instance { get; private set; }
        private static T instance;

        public static T Instance 
        {
            get 
            {
                //�������
                if (instance == null) 
                {
                    //�ڳ����и������Ͳ�������
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        //�����ű���������ִ��awake��
                        instance = new GameObject("Singleton of " + typeof(T)).AddComponent<T>();
                    }
                    else
                    {
                        instance.Init();
                    }
                } 
                return instance; 
            }
        }

        public void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                Init();
            }
        }

        //��������ʼ��
        public virtual void Init() 
        { 
        
        }
    }
}
