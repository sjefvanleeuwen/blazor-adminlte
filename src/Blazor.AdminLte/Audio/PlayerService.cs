using System;

namespace Blazor.AdminLte
{
    public class PlayerService : IPlayerService
    {
        public Player Player { get; set; }


        public void Pause()
        {
            throw new NotImplementedException();
        }

        public async void Play(string url)
        {
            await Player.Submit();
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlayerService
    {
        Player Player { get; set; }
        void Pause();
        void Resume();
        void Play(string url);
    }
}
