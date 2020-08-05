using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SML
{

    public partial class MainForm : Form
    {
        private Point MouseClickLocation;

        private Dictionary<int, ModPanel> ModList = new Dictionary<int, ModPanel>();
        private Dictionary<int, int> PanelHashList = new Dictionary<int, int>();
        private Dictionary<string, ModRegistryJSON> ListOfMods = new Dictionary<string, ModRegistryJSON>();
        private Panel SelectedPanel = new Panel();
        private string ModsDirectory = "";

        public MainForm()
        {
            InitializeComponent();          
            MainModPanel.AutoScroll = true;

            Title.TextAlign = ContentAlignment.MiddleCenter;
            Title.Location = new Point(362, 20);

            Subtitle.Location = new Point(406, 70);
            Subtitle.TextAlign = ContentAlignment.MiddleCenter;

            openFileDialog1.Filter = "JSON Files (JSON)|*.json";
            openFileDialog1.FileName = "";

            saveFileDialog1.Filter = "JSON Files (JSON)|*.json";
            saveFileDialog1.FileName = "";

            MouseDown += FormMouseDown;
            MouseMove += FormMouseMove;

            BackgroundImageLayout = ImageLayout.None;
            DoubleBuffered = true;

            if (Properties.Settings.Default.DirectoryPath == "")
            {
                ResetButton.Enabled = false;
                MoveUpButton.Enabled = false;
                MoveDownButton.Enabled = false;
                ImportListButton.Enabled = false;
                ExportListButton.Enabled = false;
                SaveButton.Enabled = false;
            }
            else
            {
                ModsDirectory = Properties.Settings.Default.DirectoryPath;
                ResetList();
            }
        }

        private void ResetList()
        {
            ClearList();

            if (JSONFormatting.ParseModRegistry(ModsDirectory + "\\mods_registry.json", out ListOfMods))
            {
                GameDataJSON GDJ = new GameDataJSON();
                if (JSONFormatting.ParseGameData(ModsDirectory + "\\game_data.json", out GDJ))
                {
                    DLCLoadJSON DLJ = new DLCLoadJSON();

                    if (JSONFormatting.ParseDLCLoadJSON(ModsDirectory + "\\dlc_load.json", out DLJ))
                    {
                        CreateList(ListOfMods, GDJ, DLJ);
                    }
                }
            } 
        }

        private void ClearList()
        {
            MainModPanel.Controls.Clear();
            ModList.Clear();
            PanelHashList.Clear();
            SelectedPanel = new Panel();
        }

        private void CreateList(Dictionary<string, ModRegistryJSON> ListOfMods, GameDataJSON GDJ, DLCLoadJSON DLJ)
        {
            int ModNumber = 1, TotalPanelHeight = 0;

            foreach (string ID in GDJ.modsOrder)
            {
                ModRegistryJSON Mod = new ModRegistryJSON();
                if (ListOfMods.TryGetValue(ID, out Mod))
                {
                    bool IsEnabled = false;
                    if (DLJ.enabled_mods.Find(x => x == Mod.gameRegistryId) != null) IsEnabled = true;

                    //Create new ModPanel
                    ModPanel mPanel = new ModPanel(ModNumber.ToString(), Mod.displayName, ID, Mod.gameRegistryId, IsEnabled);

                    //Add to container
                    MainModPanel.Controls.Add(mPanel.MainPanel);
                    //Set location
                    mPanel.MainPanel.Location = new Point(mPanel.MainPanel.Location.X, TotalPanelHeight);
                    //Set next Y position
                    TotalPanelHeight += mPanel.MainPanel.Height;

                    //Add panel to dictionary
                    ModList.Add(ModNumber, mPanel);
                    //Hash codes for referencing panels
                    PanelHashList.Add(mPanel.MainPanel.GetHashCode(), ModNumber);

                    //Mouse start hover
                    mPanel.MainPanel.MouseEnter += ModPanelMouseEnter;
                    mPanel.ModLabel.MouseEnter += ModPanelMouseEnter;
                    mPanel.OrderLabel.MouseEnter += ModPanelMouseEnter;
                    mPanel.Enabled.MouseEnter += ModPanelMouseEnter;

                    //Mouse end hover
                    mPanel.MainPanel.MouseLeave += ModPanelMouseLeave;
                    mPanel.ModLabel.MouseLeave += ModPanelMouseLeave;
                    mPanel.OrderLabel.MouseLeave += ModPanelMouseLeave;
                    mPanel.Enabled.MouseLeave += ModPanelMouseLeave;

                    //Select panel
                    mPanel.MainPanel.MouseClick += ModPanelSelected;
                    mPanel.ModLabel.MouseClick += ModPanelSelected;
                    mPanel.OrderLabel.MouseClick += ModPanelSelected;
                    mPanel.Enabled.MouseClick += ModPanelSelected;

                    //Increase mod number to keep count
                    ModNumber++;
                }
            }
        }

        private void UpdateList()
        {
            //Reset scroll for drawing - Need to find a cleaner way to achieve this
            Point ScrollPosition = MainModPanel.AutoScrollPosition;
            MainModPanel.AutoScrollPosition = new Point(AutoScrollPosition.X, 0);

            //Determines next panel's Y value
            int TotalPanelHeight = 0;
            //Go through dictionary via keys
            for (int ModNumber = 1; ModNumber <= ModList.Count; ModNumber++)
            {
                ModPanel mPanel = new ModPanel();
                if (ModList.TryGetValue(ModNumber, out mPanel))
                {
                    //Update position of panel
                    mPanel.MainPanel.Location = new Point(mPanel.MainPanel.Location.X, TotalPanelHeight);
                    //Set next panel's Y value
                    TotalPanelHeight += mPanel.MainPanel.Height;
                }
            }

            //Reset the scroll bar to where it was pre-update
            MainModPanel.AutoScrollPosition = new Point(Math.Abs(ScrollPosition.X), Math.Abs(ScrollPosition.Y));
        }

        private void ModPanelMouseEnter(object sender, EventArgs e)
        {
            switch (sender)
            {
                case Panel p:
                    p.Parent.BackColor = Color.LightSalmon;
                    break;
                case Label l:
                    l.Parent.BackColor = Color.LightSalmon;
                    break;
                case CheckBox c: 
                    c.Parent.BackColor = Color.LightSalmon;
                    break;
                default: break;
            }
        }

        private void ModPanelMouseLeave(object sender, EventArgs e)
        {
            Panel ParentPanel = new Panel();
            switch (sender)
            {
                case Panel p:
                    ParentPanel = (Panel)p.Parent;
                    break;
                case Label l:
                    ParentPanel = (Panel)l.Parent;
                    break;
                case CheckBox c:
                    ParentPanel = (Panel)c.Parent;
                    break;
                default:
                    ParentPanel = null;
                    break;
            }

            if (ParentPanel != null)
            {
                if (ParentPanel != SelectedPanel) ParentPanel.BackColor = Color.Transparent;
            }
        }

        private void ModPanelSelected(object sender, MouseEventArgs e)
        {
            Panel ParentPanel = new Panel();
            switch (sender)
            {
                case Panel p:
                    ParentPanel = (Panel)p.Parent;
                    break;
                case Label l:
                    ParentPanel = (Panel)l.Parent;
                    break;
                case CheckBox c:
                    ParentPanel = (Panel)c.Parent;
                    break;
                default:
                    ParentPanel = null;
                    break;
            }

            if (ParentPanel != null)
            {
                if (SelectedPanel != ParentPanel) SelectedPanel.BackColor = Color.Salmon;
                SelectedPanel = ParentPanel;
            }
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                (this.Location.X - MouseClickLocation.X) + e.X, (this.Location.Y - MouseClickLocation.Y) + e.Y);


                this.Update();
            }
        }
        
        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseClickLocation = e.Location;
            }
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (SelectedPanel != null)
            {
                int ModNumber = 0;
                if (PanelHashList.TryGetValue(SelectedPanel.GetHashCode(), out ModNumber))
                {
                    if (ModNumber != ModList.Count)
                    {
                        ModPanel temp = new ModPanel();
                        temp = ModList[ModNumber];

                        //Swap HashCodes
                        PanelHashList[ModList[ModNumber + 1].MainPanel.GetHashCode()] = ModNumber;
                        PanelHashList[SelectedPanel.GetHashCode()] = ModNumber + 1;

                        //Swap ModPanels
                        ModList[ModNumber] = ModList[ModNumber + 1];
                        ModList[ModNumber].SetOrder(ModNumber);
                        ModList[ModNumber + 1] = temp;
                        ModList[ModNumber + 1].SetOrder(ModNumber + 1);

                        UpdateList();
                    }
                }
            }
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (SelectedPanel != null)
            {
                int ModNumber = 0;
                if (PanelHashList.TryGetValue(SelectedPanel.GetHashCode(), out ModNumber))
                {
                    if (ModNumber != 1)
                    {
                        ModPanel temp = new ModPanel();
                        temp = ModList[ModNumber];

                        //Swap HashCodes
                        PanelHashList[ModList[ModNumber - 1].MainPanel.GetHashCode()] = ModNumber;
                        PanelHashList[SelectedPanel.GetHashCode()] = ModNumber - 1;

                        //Swap ModPanels
                        ModList[ModNumber] = ModList[ModNumber - 1];
                        ModList[ModNumber].SetOrder(ModNumber);
                        ModList[ModNumber - 1] = temp;
                        ModList[ModNumber - 1].SetOrder(ModNumber - 1);

                        UpdateList();
                    }
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            ResetList();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            JSONFormatting.SaveModOrder(ModList, ModsDirectory);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ImportListButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
                try
                {
                    ClearList();
                    CustomOrderList COL = JSONFormatting.ParseCustomOrderList(file);
                    GameDataJSON GDJ = new GameDataJSON(COL);
                    DLCLoadJSON DLJ = new DLCLoadJSON(COL);

                    CreateList(ListOfMods, GDJ, DLJ);
                }
                catch (IOException)
                {
                    Console.WriteLine("It's fucked");
                }
            }
        }
        
        private void ExportListButton_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                try
                {
                    JSONFormatting.ExportModOrder(ModList, file);
                }
                catch (IOException)
                {
                    Console.WriteLine("It's fucked");
                }
            }
        }

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                ModsDirectory = folderBrowserDialog1.SelectedPath;
                
                if (File.Exists(ModsDirectory + "\\mods_registry.json") && File.Exists(ModsDirectory + "\\dlc_load.json") && File.Exists(ModsDirectory + "\\game_data.json"))
                {
                    ResetButton.Enabled = true;
                    MoveUpButton.Enabled = true;
                    MoveDownButton.Enabled = true;
                    ImportListButton.Enabled = true;
                    ExportListButton.Enabled = true;
                    SaveButton.Enabled = true;
                    SelectDirectoryButton.Enabled = false;

                    Properties.Settings.Default.DirectoryPath = ModsDirectory;
                    Properties.Settings.Default.Save();

                    ResetList();
                }              
            }
        }
    }
}
