using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace MonoGame.SignalR.Server.Hubs
{
    public class CharacterMoveHub : Hub
    {
        private static int _x;
        private static int _y;

        public override Task OnConnected()
        {
            Console.WriteLine("New user connected");
            Clients.Caller.UpdateState(_x, _y);
            return base.OnConnected();
        }

        public void Move(int x, int y)
        {
            _x += x;
            _y += y;
            Console.WriteLine($"Moving character to x: {_x}, y: {_y}");
            Clients.All.UpdateState(_x, _y);
        }
    }
}
