using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
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
        //得到当前用户ID
        public void GetUserID(string sid)
        {
            Clients.Caller.GetUserIDBack(Context.ConnectionId);
        }
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
    }
}