using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FastechTest
{
    public class CFastechServo
    {
        public string ServoIP { get; set; } = "192.168.0.64";
        public int ServoID { get; set; } = 0;
        public uint JogSpeed { get; set; }
        public uint MotorSpeed { get; set;}
        public int AccelTime { get; set; }
        public int DecelTime { get; set; }
        public int Wait_Pos { get; set; }
        public int Insp_Pos { get; set; }

        public CFastechServo Load()
        {
            string path = $"{Application.StartupPath}\\RECIPE\\Recipe.json";

            CFastechServo newData = null;

            if (File.Exists(path))
            {
                newData = JsonConvert.DeserializeObject<CFastechServo>(File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if (newData != null)
                    return newData;
            }

            newData = new CFastechServo();
            newData.Save();


            return newData;
        }

        public void Save()
        {
            string path = $"{Application.StartupPath}\\RECIPE\\Recipe.json";
            string forderpath = $"{Application.StartupPath}\\RECIPE\\";
            string currRecipe;

            try
            {
                currRecipe = JsonConvert.SerializeObject(this, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });

                if (!Directory.Exists(forderpath)) Directory.CreateDirectory(forderpath);

                if (File.Exists(path))
                {
                    //이전값과 비교하여 바뀐 부분 로깅
                    string prevRecipe = File.ReadAllText(path);

                    JObject previousObject = JObject.Parse(prevRecipe);
                    JObject currentObject = JObject.Parse(currRecipe);

                    var result = JToken.DeepEquals(previousObject, currentObject);

                }

                File.WriteAllText(path, currRecipe);
            }
            catch (JsonException ex)
            {
            }
            catch (Exception ex)
            {
            }
        }
    }
}
