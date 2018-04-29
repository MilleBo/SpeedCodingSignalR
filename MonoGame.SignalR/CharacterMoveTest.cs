using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame.SignalR
{
    public class CharacterMoveTest
    {
        private readonly HubConnection _connection;
        private IHubProxy _characterMoveHub;
        private int _x;
        private int _y;
        private Texture2D _texture;

        public CharacterMoveTest()
        {
            _connection = new HubConnection("http://localhost:8080");
        }

        public void Connect()
        {
            _characterMoveHub = _connection.CreateHubProxy("characterMoveHub");
            _characterMoveHub.On<int, int>("updateState", (x, y) =>
            {
                _x = x;
                _y = y;
            });
            _connection.Start();
        }

        public void LoadContent(ContentManager contentManager)
        {
            _texture = contentManager.Load<Texture2D>("deer");
        }

        public void Update()
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                _characterMoveHub.Invoke("Move", 0, 1);
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                _characterMoveHub.Invoke("Move", 0, -1);
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                _characterMoveHub.Invoke("Move", 1, 0);
            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                _characterMoveHub.Invoke("Move", -1, 0);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, new Rectangle(_x, _y, 40, 40), Color.White);
        }

    }
}
