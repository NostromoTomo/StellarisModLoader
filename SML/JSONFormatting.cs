using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SML
{

    class JSONFormatting
    {
        public static bool ParseModRegistry(in string url, out Dictionary<string, ModRegistryJSON> ModList)
        {
            ModList = new Dictionary<string, ModRegistryJSON>();

            try
            {
                JObject obj = JObject.Parse(File.ReadAllText(url));

                foreach (var x in obj)
                {
                    var temp = JsonConvert.DeserializeObject<ModRegistryJSON>(x.Value.ToString());
                    temp.objectKey = x.Key;
                    ModList.Add(x.Key, temp);
                }

                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);

                return false;
            }
        }

        public static bool ParseGameData(in string url, out GameDataJSON GDJ)
        {
            GDJ = new GameDataJSON();

            try
            {
                GDJ = JsonConvert.DeserializeObject<GameDataJSON>(File.ReadAllText(url));

                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);

                return false;
            }
        }

        public static bool ParseDLCLoadJSON(in string url, out DLCLoadJSON DLJ)
        {
            DLJ = new DLCLoadJSON();

            try
            {
                DLJ = JsonConvert.DeserializeObject<DLCLoadJSON>(File.ReadAllText(url));

                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);

                return false;
            }

        }

        public static CustomOrderList ParseCustomOrderList(string url)
        {
            CustomOrderList COL = new CustomOrderList();

            try
            {
                COL = JsonConvert.DeserializeObject<CustomOrderList>(File.ReadAllText(url));
            }
            catch (Exception exp)
            {
                MessageBox.Show("An error occurred while attempting to load the file. The error is:"
                                + System.Environment.NewLine + exp.ToString() + System.Environment.NewLine);
            }

            return COL;
        }

        public static bool SaveModOrder(Dictionary<int, ModPanel> ModList, string filepath)
        {
            DLCLoadJSON DLJ = new DLCLoadJSON();
            GameDataJSON GDJ = new GameDataJSON();

            for (int ModNumber = 1; ModNumber <= ModList.Count; ModNumber++)
            {
                //Set dlc_load json
                if (ModList[ModNumber].Enabled.Checked) DLJ.enabled_mods.Add(ModList[ModNumber].ModDirectory);
                else DLJ.disabled_dlcs.Add(ModList[ModNumber].ModDirectory);

                GDJ.modsOrder.Add(ModList[ModNumber].ModIdentification);
            }

            GDJ.isEulaAccepted = true;

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(filepath + "\\dlc_load.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, DLJ);
            }

            using (StreamWriter sw = new StreamWriter(filepath + "\\game_data.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, GDJ);
            }

            return true;
        }

        public static bool ExportModOrder(Dictionary<int, ModPanel> ModList, string filepath)
        {
            CustomOrderList COL = new CustomOrderList();

            for (int ModNumber = 1; ModNumber <= ModList.Count; ModNumber++)
            {
                //Set dlc_load json
                if (ModList[ModNumber].Enabled.Checked) COL.enabled_mods.Add(ModList[ModNumber].ModDirectory);
                else COL.disabled_dlcs.Add(ModList[ModNumber].ModDirectory);

                COL.modsOrder.Add(ModList[ModNumber].ModIdentification);
                COL.modsOrderSteamID.Add(ModList[ModNumber].ModSteamID);
            }

            COL.isEulaAccepted = true;

            JsonSerializer serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (StreamWriter sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, COL);
            }

            return true;
        }
    }
}
