using UnityEngine;

namespace Settings
{
    public static class GameSaver
    {
        private static readonly int _defaultCount = 0;
        private static readonly string _clicks = "Clicks";

        public static int ClicksCount => PlayerPrefs.GetInt(_clicks, _defaultCount);

        public static void SaveClicks(int value)
        {
            if (value <= ClicksCount)
                return;

            PlayerPrefs.SetInt(_clicks, value);
            PlayerPrefs.Save();
        }
    }
}