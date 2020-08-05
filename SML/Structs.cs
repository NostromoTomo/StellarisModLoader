using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SML
{
    public struct ModPanel
    {
        public ModPanel(string OrderString, string ModString, string ModIdentification, string ModDirectory, bool IsEnabled)
        {
            this.ModIdentification = ModIdentification;
            this.ModDirectory = ModDirectory;

            MainPanel = new Panel();
            MainPanel.Size = new Size(782, 40);
            MainPanel.BackColor = Color.Transparent;

            OrderLabel = new Label();
            OrderLabel.Size = new Size(45, 40);
            OrderLabel.Font = new Font("Malgun Gothic", 12);
            OrderLabel.Text = OrderString;
            OrderLabel.TextAlign = ContentAlignment.MiddleCenter;
            OrderLabel.ForeColor = Color.White;
            MainPanel.Controls.Add(OrderLabel);
            OrderLabel.Location = new Point(0, 0);

            ModLabel = new Label();
            ModLabel.Size = new Size(695, 40);
            ModLabel.Font = new Font("Malgun Gothic", 12);
            ModLabel.Text = ModString;
            ModLabel.TextAlign = ContentAlignment.MiddleLeft;
            ModLabel.ForeColor = Color.White;
            MainPanel.Controls.Add(ModLabel);
            ModLabel.Location = new Point(45, 0);

            Enabled = new CheckBox();
            Enabled.Size = new Size(40, 40);
            Enabled.CheckAlign = ContentAlignment.MiddleCenter;
            MainPanel.Controls.Add(Enabled);
            Enabled.Location = new Point(740, 0);
            Enabled.Checked = IsEnabled;
        }

        public void SetOrder(int ModNumber)
        {
            OrderLabel.Text = ModNumber.ToString();
        }

        public Panel MainPanel { get; set; }
        public Label OrderLabel { get; set; }
        public Label ModLabel { get; set; }
        public CheckBox Enabled { get; set; }
        public string ModIdentification { get; set; }
        public string ModDirectory { get; set; }
    }

    public class ModRegistryJSON
    {
        public string objectKey { get; set; }
        public string steamId { get; set; }
        public string displayName { get; set; }
        public List<string> tags { get; set; }
        public int timeUpdated { get; set; }
        public string source { get; set; }
        public string thumbnailUrl { get; set; }
        public string dirPath { get; set; }
        public string status { get; set; }
        public string id { get; set; }
        public string gameRegistryId { get; set; }
        public string requiredVersion { get; set; }
        public string cause { get; set; }
        public string thumbnailPath { get; set; }
    }

    public class DLCLoadJSON
    {
        public DLCLoadJSON()
        {
            disabled_dlcs = new List<string>();
            enabled_mods = new List<string>();
        }

        public DLCLoadJSON(CustomOrderList COL)
        {
            disabled_dlcs = new List<string>(COL.disabled_dlcs);
            enabled_mods = new List<string>(COL.enabled_mods);
        }

        public List<string> disabled_dlcs { get; set; }
        public List<string> enabled_mods { get; set; }
    }

    public class GameDataJSON
    {
        public GameDataJSON()
        {
            modsOrder = new List<string>();
            isEulaAccepted = false;
        }

        public GameDataJSON(CustomOrderList COL)
        {
            modsOrder = new List<string>(COL.modsOrder);
            isEulaAccepted = COL.isEulaAccepted;
        }

        public List<string> modsOrder { get; set; }
        public bool isEulaAccepted { get; set; }
    }

    public class CustomOrderList
    {
        public CustomOrderList()
        {
            disabled_dlcs = new List<string>();
            enabled_mods = new List<string>();
            modsOrder = new List<string>();
            isEulaAccepted = false;
        }

        public List<string> disabled_dlcs { get; set; }
        public List<string> enabled_mods { get; set; }
        public List<string> modsOrder { get; set; }
        public bool isEulaAccepted { get; set; }
    }
}
