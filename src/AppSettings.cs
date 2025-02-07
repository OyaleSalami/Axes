using System;
using System.Collections.Generic;
using System.IO;

namespace AxesCore
{
    public class AppSettings
    {
        private static string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Axes Core/";
        private static string filename = "Settings.ini";
        string filePath = Path.Combine(path, filename);

        public float speed;
        public float defaultFeedrate;
        public float maxFeedrate;

        public AppSettings()
        {
            speed = 10;
            defaultFeedrate = 50;
            maxFeedrate = 2000;
        }

        public AppSettings(Dictionary<string, object> settings)
        {
            try
            {
                speed = float.Parse(settings["speed"].ToString());
                defaultFeedrate = float.Parse(settings["defaultFeedrate"].ToString());
                maxFeedrate = float.Parse(settings["maxFeedrate"].ToString());
            }
            catch (Exception e)
            {
                ErrorHandler.Error("Error Loading Application Settings: " + e);
            }
        }

        public void Load() //Load settings file from local storage
        {
            if (File.Exists(filePath))
            {
                try
                {
                    /*
                    string temp = File.ReadAllText(filePath);
                    var settings = new Dictionary<String, int>(); //= JsonConvert.DeserializeObject<AppSettings>(temp);

                    speed = settings.speed;
                    defaultFeedrate = settings.defaultFeedrate;
                    maxFeedrate = settings.maxFeedrate;
                    */
                }
                catch (Exception e)
                {
                    ErrorHandler.Error("Error Loading Application Settings: " + e);
                }
            }
            ErrorHandler.Log("Application Settings Loaded");
        }

        public void Save()
        {
            string temp = this.ToJson();
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(temp);
                sw.Close(); sw.Dispose();
            }
            fs.Close(); fs.Dispose();
        }

        public void SetSpeed(float value)
        {
            speed = value;
            Save();
        }

        public void SetDefaultFeedrate(float value)
        {
            defaultFeedrate = value;
            Save();
        }

        public void SetMaxFeedrate(float value)
        {
            maxFeedrate = value;
            Save();
        }

        /// <summary>Returns This Object As A Json String</summary>
        public string ToJson()
        {
            return ""; //JsonConvert.SerializeObject(this);
        }
    }
}
