using BL.AppServices;
using BL.ViewModels;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Day1.MyHubs
{
    //All Public MEthod Calling From Client As RPC
    //[HubName("ChatHub")]
    public class commentHub : Hub
    {
        CommentAppServices commentAppServices = new CommentAppServices();
        AccountAppServices accountAppServices = new AccountAppServices();
        //[HubMethodName("NewUser")]
        public void newUser(string name)
        {

        }
        //Call Cient //Server
        //[HubMethodName("NewMessage")]
        public void newMessage(string name, string text, int id)
        {
            //save db ,....
            //string name = "noorulhodaa";//HttpContext.Current.User.Identity.Name) };
            CommentVM commentvm = new CommentVM() { Content = text, courseID = id, userID = accountAppServices.GetIDByName(name) };
            commentAppServices.SaveNewComment(commentvm);
            //Boradcast "Server Call Clinet Side MEthod Push
            Clients.All.notifyNewMessage(name ,text, id); 
        }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }
    }
}