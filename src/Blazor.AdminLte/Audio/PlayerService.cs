using System;
using System.ComponentModel.DataAnnotations;

namespace Blazor.AdminLte
{
    public class PlayerService : IPlayerService
    {
        public string Url { get; set; }

        public Player Player { get; set; }


        public void Pause()
        {
            throw new NotImplementedException();
        }

        public async void Play(string url)
        {
            Url = url;
            await Player.Submit(forcePlay: true);
        }

        public void Resume()
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlayerService
    {
        string Url { get; set; }
        Player Player { get; set; }
        void Pause();
        void Resume();
        void Play(string url);
    }
}
