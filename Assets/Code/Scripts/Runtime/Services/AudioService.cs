using System;
using System.Collections.Generic;
using Code.Services.Audio;
using Code.Services.Interfaces;
using JSAM;
using UnityEngine;

namespace Code.Services
{
    /// <summary>
    /// Реализация интерфейса <see cref="IAudioService"/>
    /// </summary>
    public sealed class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField, Tooltip("Библиотека аудио")]
        private AudioLibrary library;

        private Dictionary<string, Sound> _nameToSound;

        private Dictionary<string, Music> _nameToMusic;

        public float MasterVolume
        {
            get => AudioManager.MasterVolume;
            set => AudioManager.MasterVolume = value;
        }

        public float SoundVolume
        {
            get => AudioManager.SoundVolume;
            set => AudioManager.SoundVolume = value;
        }

        public float MusicVolume
        {
            get => AudioManager.MusicVolume;
            set => AudioManager.MusicVolume = value;
        }

        public void Awake()
        {
            AudioManager.InternalInstance.LoadAudioLibrary(library);
            CreateCache(_nameToSound);
            CreateCache(_nameToMusic);
        }

        public void PlaySound(string sound)
        {
            AudioManager.PlaySound(GetSound(sound));
        }

        public void StopSound(string sound, bool stopInstantly = true)
        {
            AudioManager.StopSound(GetSound(sound), stopInstantly: stopInstantly);
        }

        public void PlayMusic(string music)
        {
            AudioManager.PlayMusic(GetMusic(music));
        }

        public void StopMusic(string music, bool stopInstantly = true)
        {
            AudioManager.StopMusic(GetMusic(music), stopInstantly: stopInstantly);
        }

        /// <summary>
        /// Получить объект звука
        /// </summary>
        private SoundFileObject GetSound(string sound)
        {
            if (!_nameToSound.TryGetValue(sound, out var e))
                return null;

            return AudioManager.InternalInstance.AudioFileFromEnum(e) as SoundFileObject;
        }

        /// <summary>
        /// Получить объект музыки
        /// </summary>
        private MusicFileObject GetMusic(string music)
        {
            if (!_nameToMusic.TryGetValue(music, out var e))
                return null;

            return AudioManager.InternalInstance.AudioFileFromEnum(e) as MusicFileObject;
        }

        /// <summary>
        /// Создать кэш имен аудио файлов
        /// </summary>
        private static void CreateCache<T>(Dictionary<string, T> nameToValue) where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            nameToValue = new Dictionary<string, T>(values.Length);

            foreach (T v in values)
            {
                nameToValue.Add(v.ToString(), v);
            }
        }
    }
}