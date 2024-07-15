using EntityComponent;
using JumpKing.Mods;
using JumpKing.PauseMenu.BT.Actions;
using JumpKing.PauseMenu;
using JumpKing.Player;
using JumpKing_GiantBootsSound.Menu;
using JumpKing_GiantBootsSound.Model;
using System.IO;
using System.Reflection;
using System;
using System.ComponentModel;

namespace JumpKing_GiantBootsSound
{
    [JumpKingMod("YutaGoto.JumpKing_GiantBootsSound")]
    public static class ModEntry
    {
        public const string SETTINS_FILE = "YutaGoto.GiantBootsSound.Settings.xml";
        private static string AssemblyPath { get; set; }

        [MainMenuItemSetting]
        [PauseMenuItemSetting]
        public static ITextToggle AddToggleEnabled(object factory, GuiFormat format)
        {
            return new ToggleEnabled();
        }

        /// <summary>
        /// Called by Jump King before the level loads
        /// </summary>
        [BeforeLevelLoad]
        public static void BeforeLevelLoad()
        {
            AssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                Preference.Preferences = XmlSerializerHelper.Deserialize<Preferences>(AssemblyPath + "\\" + SETTINS_FILE);
            }
            catch (Exception)
            {
                Preference.Preferences = new Preferences();
                XmlSerializerHelper.Serialize(AssemblyPath + "\\" + SETTINS_FILE, Preference.Preferences);
            }

            Preference.Preferences.PropertyChanged += SaveSettingsOnFile;
        }

        /// <summary>
        /// Called by Jump King when the level unloads
        /// </summary>
        [OnLevelUnload]
        public static void OnLevelUnload()
        {
            // Your code here
        }

        /// <summary>
        /// Called by Jump King when the Level Starts
        /// </summary>
        [OnLevelStart]
        public static void OnLevelStart()
        {
            PlayerEntity player = EntityManager.instance.Find<PlayerEntity>();

            if (player != null)
            {
                player.m_body.RegisterBehaviour(new Bahaviours.BootsSound());
            }
        }

        /// <summary>
        /// Called by Jump King when the Level Ends
        /// </summary>
        [OnLevelEnd]
        public static void OnLevelEnd()
        {
            // Your code here
        }

        private static void SaveSettingsOnFile(object sender, PropertyChangedEventArgs args)
        {
            try
            {
                XmlSerializerHelper.Serialize(AssemblyPath + "\\YutaGoto.GiantBootsSound.Settings.xml", Preference.Preferences);
            }
            catch (Exception)
            {

            }
        }
    }
}
