using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTTDemo.RunTime
{
    /// <summary>
    /// 
    /// </summary>
    public class ButtonViewGroup : MonoBehaviour
    {
        public void DelChild()
        {
            Transform transform_s;
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                transform_s = transform.GetChild(i);
                
                GameObject.Destroy(transform_s.gameObject);
            }
        }

    }
}
