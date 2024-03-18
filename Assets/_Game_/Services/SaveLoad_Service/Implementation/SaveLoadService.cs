using Assets.Game.Services.ProgressService.api;
using System.IO;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using MoreMountains.Tools;

namespace WKosArch.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKEY = "Progress";
        public bool IsReady => _isReady;

        private readonly IProgressService _progressService;
        private bool _isReady;


        public SaveLoadService(IProgressService progressService)
        {
            _progressService = progressService;

            _isReady = true;
        }

        public GameProgress LoadProgress()
        {
            var json = PlayerPrefs.GetString(ProgressKEY);

            
            //var save = JsonUtility.FromJson<GameProgress>(json);
            var save = StrToObject<GameProgress>(json);

            //var save = PlayerPrefs.GetString(ProgressKEY)?.ToDeserialized<GameProgress>();
            //PlayerPrefs.();
            return save;
        }

        public void SaveProgress()
        {
            //var json = JsonUtility.ToJson(_progressService.Progress);
            var json = ObjectToStr<GameProgress>(_progressService.Progress);
            PlayerPrefs.SetString(ProgressKEY, json);

            //PlayerPrefs.SetString(ProgressKEY, _progressService.Progress.ToJson());
            PlayerPrefs.Save();
        }

        public void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
                SaveProgress();
        }

        public void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                SaveProgress();
        }

        public static string ObjectToStr<T>(T _saveMe)
        {
            BinaryFormatter _bin = new BinaryFormatter();
            MemoryStream _mem = new MemoryStream();
            _bin.Serialize(_mem, _saveMe);

            return Convert.ToBase64String(
                _mem.GetBuffer()
            );
        }

        public static T StrToObject<T>(string _data) where T : class
        {
            if (!String.IsNullOrEmpty(_data))
            {
                BinaryFormatter _bin = new BinaryFormatter();
                try
                {
                    MemoryStream _mem = new MemoryStream(Convert.FromBase64String(_data));

                    T _obj = _bin.Deserialize(_mem) as T;

                    return _obj;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            else
            {
                throw new Exception("_data is null or empty");
            }
        }
    }
}