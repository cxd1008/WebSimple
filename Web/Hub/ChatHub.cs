using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Web
{
    public class ChatHub : Hub
    {
        /// 群聊
        public void Hello(string name, string message)
        {
            Clients.All.helloBack(name, message);
        }
        /// 单聊
        public void HelloSingle(string sid, string name, string message)
        {
            Clients.Caller.helloSingleBack(sid, name, message);//自己也收到一份消息            
            Clients.Client(sid).helloSingleBack(sid, name, message);//发送给某人
        }
       
        //public void GetUserID(string sid)
        //{
        //    Clients.Caller.GetUserIDBack(Context.ConnectionId);
        //}
        //组聊
        public void HelloGroup(string sGroupName, string name, string message)
        {
            Clients.Group(sGroupName).helloGroupBack(sGroupName, name, message);
        }
        //加入一个组
        public void AddGroup(string sID, string sGroupName)
        {
            Groups.Add(sID, sGroupName);
        }
        //断线时执行
        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.helloBack(Context.ConnectionId, "轻轻的我走了");
            return base.OnDisconnected(stopCalled);
        }
        //第一次加载
        public override Task OnConnected()
        {            
            Clients.Caller.GetUserIDBack(Context.ConnectionId); //得到当前用户ID
            Clients.All.helloBack(Context.ConnectionId, "轻轻的我来了");
            return base.OnConnected();
        }

    }

}