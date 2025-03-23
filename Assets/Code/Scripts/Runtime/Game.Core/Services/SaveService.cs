using Game.Services.Interfaces;
using UnityEngine;

namespace Game.Services
{
    public class SaveService : ISaveService
    {
        private const string key = "save";

        public void Set(string data)
        {
            PlayerPrefs.SetString(key, data);
            PlayerPrefs.Save();
        }

        public string Get()
        {
            return PlayerPrefs.GetString(key);
        }

        public void Save()
        {
            PlayerPrefs.Save();
        }
    }
}