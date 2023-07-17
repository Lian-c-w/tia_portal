
namespace FunctionManager
{
    public class PublicFunctions
    {      
        /// <summary>
        /// 声明委托，并传入文本信息
        /// </summary>
        /// <param name="info"></param>
        public delegate void EventManager(string status);
        public delegate void UpdateTV();
        //public delegate void TreeEventManager();
        /// <summary>
        /// 定义事件
        /// </summary>
        static public event EventManager UpdateMessage;
        //public event TreeEventManager UpdateTreeMessage;
        /// <summary>
        /// 启动事件
        /// </summary>
        static public void StartMessage(string status)
        {
            UpdateMessage?.Invoke(status);
            //UpdateMessage(status);
        }
    }
}
