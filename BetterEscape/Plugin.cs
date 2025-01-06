using MapGeneration;
using PluginAPI.Core.Attributes;
using PluginAPI.Events;
using System.Linq;
using UnityEngine;

namespace BetterEscape
{
    public class Plugin
    {
        public static Plugin Instance { get; private set; }

        [PluginConfig]
        public static Config Config;

        [PluginEntryPoint("BetterEscape", "1.0.0", "Just BetterEscape.", "MrAfitol")]
        public void LoadPlugin()
        {
            Instance = this;
            EventManager.RegisterEvents(Instance);
        }

        [PluginEvent]
        public void OnRoundStart(RoundStartEvent ev)
        {
            RoomIdentifier Outside = RoomIdentifier.AllRoomIdentifiers.First(x => x.Name == RoomName.Outside);
            GameObject gameObject = new GameObject("Escape-1");
            gameObject.transform.SetParent(Outside.transform);
            gameObject.transform.localPosition = new Vector3(123.82f, -10f, 18.663f);
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.localScale = new Vector3(5f, 5f, 0.4f);
            gameObject.AddComponent<BoxCollider>().isTrigger = true;
            gameObject.AddComponent<EnteryEscape>();
        }
    }
}