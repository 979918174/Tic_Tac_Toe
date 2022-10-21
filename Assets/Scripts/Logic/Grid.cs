using TTTDemo.Common;

namespace TTTDemo.GamePlay
{
    /// <summary>
    /// 格子类
    /// </summary>
    public class Grid
    {
        //格子阵营类型
        public CampType campType;
        //格子行列位置信息
        public int rowValue;
        public int colValue;
        //标记tag
        public int tag;
        //权重，AI使用的属性
        public int prop;
    }
}