using HarmonyLib;
using NewHorizons;
using NewHorizons.Components;
using NewHorizons.Utility;
using OWML.Common;
using OWML.ModHelper;
using System;
using System.Reflection;
using UnityEngine;

namespace PowerFail
{
    public class PowerFail : ModBehaviour
    {
        public INewHorizons NewHorizons;
        private static PowerFail _instance;
        public static PowerFail Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<PowerFail>();
                return _instance;
            }
        }

        public GameObject warpPad;

        public void Start()
        {

            // Starting here, you'll have access to OWML's mod helper.
            ModHelper.Console.WriteLine($"My mod {nameof(PowerFail)} is loaded!", MessageType.Success);

            // Get the New Horizons API and load configs
            NewHorizons = ModHelper.Interaction.TryGetModApi<INewHorizons>("xen.NewHorizons");
            NewHorizons.LoadConfigs(this);

            new Harmony("T3rtu.PowerFail").PatchAll(Assembly.GetExecutingAssembly());

            // Example of accessing game code.
            NewHorizons.GetStarSystemLoadedEvent().AddListener(OnCompleteSceneLoad);
        }


        public void OnCompleteSceneLoad(string newScene)
        {
            ModHelper.Console.WriteLine($"Loaded into {newScene}!", MessageType.Success);

            if (newScene != "Jam5") return;

            warpPad = SearchUtilities.Find("WildsRefuge_Body/Sector/AsteroidWarp");
            var warpHandler = warpPad?.AddComponent(typeof(WarpHandler));

            ModHelper.Console.WriteLine($"warpPad status: {warpPad == null} ; warpHandler status: {warpHandler == null}", MessageType.Success);
        }
    }
}
