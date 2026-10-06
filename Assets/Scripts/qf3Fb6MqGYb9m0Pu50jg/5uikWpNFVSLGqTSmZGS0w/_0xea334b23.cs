using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public static class _0xea334b23
{
    public static class _0xa4801ffa
    {
        public static readonly int SCENE_0 = 0;
        public static readonly int SCENE_1 = 1;
    }

    public class _0x5a36e82d
    {
        private static readonly _0x5a36e82d _0xe578844c = new();
        public static readonly _0x5a36e82d[] ALL_SCENES_SETTING_SINGLETONS =
        {
            _0xe578844c,
            _0xe578844c,
            _0xe578844c,
        };
        private int _0xa2d3d492 => 0;
        private int _0xab359d3e => 10;
        private string _0xae953947 => _0xda63d878._0xa70de188(new byte[4] { 198, 238, 229, 254 }, 139);
        private string _0xea97ada7 => _0xda63d878._0xa70de188(new byte[8] { 146, 155, 136, 155, 146, 165, 238, 163 }, 222);

        private int _0xe910b6ae
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xda63d878._0xa70de188(new byte[25] { 185, 143, 136, 136, 159, 148, 142, 189, 150, 149, 152, 155, 150, 185, 146, 155, 138, 142, 159, 136, 179, 148, 158, 159, 130 }, 250)))
                    PlayerPrefs.SetInt(_0xda63d878._0xa70de188(new byte[25] { 51, 5, 2, 2, 21, 30, 4, 55, 28, 31, 18, 17, 28, 51, 24, 17, 0, 4, 21, 2, 57, 30, 20, 21, 8 }, 112), 0);
                return PlayerPrefs.GetInt(_0xda63d878._0xa70de188(new byte[25] { 19, 37, 34, 34, 53, 62, 36, 23, 60, 63, 50, 49, 60, 19, 56, 49, 32, 36, 53, 34, 25, 62, 52, 53, 40 }, 80));
            }

            set => PlayerPrefs.SetInt(_0xda63d878._0xa70de188(new byte[25] { 178, 132, 131, 131, 148, 159, 133, 182, 157, 158, 147, 144, 157, 178, 153, 144, 129, 133, 148, 131, 184, 159, 149, 148, 137 }, 241), value);
        }

        public int _0x2b68d4d9
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xae953947}CurrentLevelIndex"))
                    PlayerPrefs.SetInt($"{this._0xae953947}CurrentLevelIndex", 0);
                return PlayerPrefs.GetInt($"{this._0xae953947}CurrentLevelIndex");
            }

            set => PlayerPrefs.SetInt($"{this._0xae953947}CurrentLevelIndex", value);
        }

        public int _0xeda6d1fb
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xae953947}BestScore"))
                    this._0xeda6d1fb = 0;
                return PlayerPrefs.GetInt($"{this._0xae953947}BestScore");
            }

            set => PlayerPrefs.SetInt($"{this._0xae953947}BestScore", value);
        }

        public bool _0x70fd5b16
        {
            get
            {
                if (!PlayerPrefs.HasKey($"{this._0xae953947}IsGameTutorPassed"))
                    PlayerPrefs.SetInt($"{this._0xae953947}IsGameTutorPassed", Convert.ToInt32(false));
                return PlayerPrefs.GetInt($"{this._0xae953947}IsGameTutorPassed") == 1;
            }

            set => PlayerPrefs.SetInt($"{this._0xae953947}IsGameTutorPassed", Convert.ToInt32(value));
        }
    }

    public static class _0xdb0cb883
    {
        public static int _0xd71b9dc9
        {
            get
            {
                if (!PlayerPrefs.HasKey(_0xda63d878._0xa70de188(new byte[5] { 11, 39, 33, 38, 59 }, 72)))
                    PlayerPrefs.SetInt(_0xda63d878._0xa70de188(new byte[5] { 83, 127, 121, 126, 99 }, 16), 0);
                return PlayerPrefs.GetInt(_0xda63d878._0xa70de188(new byte[5] { 173, 129, 135, 128, 157 }, 238));
            }

            set
            {
                PlayerPrefs.SetInt(_0xda63d878._0xa70de188(new byte[5] { 24, 52, 50, 53, 40 }, 91), value);
                _0x9d5294e1.Instance._0x0bba6988();
            }
        }
    }

    public static class _0xca25cf66
    {
        public static readonly int PAUSE = 6;
        public static readonly int WIN = 7;
        public static readonly int LOSE = 8;
    }

    public static class _0x29a65535
    {
        public static readonly int SPLASH = 0;
        public static readonly int DEFAULT = 1;
        public static readonly int EMPTY = 2;
        public static readonly int TUTORIAL0 = 13;
        public static readonly int TUTORIAL1 = 14;
        public static readonly int TUTORIAL2 = 15;
        public static readonly int TUTORIAL3 = 16;
        public static readonly int TUTORIAL4 = 17;
        public static readonly int TUTORIAL5 = 18;
        public static readonly int TUTORIAL6 = 19;
    }
}

internal static class _0xda63d878
{
    internal static string _0xa70de188(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}