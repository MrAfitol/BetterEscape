using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.Handlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using MapGeneration;
using System;
using System.Linq;
using UnityEngine;

namespace BetterEscape
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance { get; private set; }

        public override string Name => "BetterEscape";

        public override string Description => "Allows handcuffed MTF/Chaos to escape and adds an escape option for Facility Guard.";

        public override string Author => "MrAfitol";

        public override Version Version => new Version(1, 1, 0);

        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;

        public override void Enable()
        {
            Instance = this;
            ServerEvents.RoundStarting += OnRoundStart;
        }

        public override void Disable()
        {
            ServerEvents.RoundStarting -= OnRoundStart;
            Instance = null;
        }

        public void OnRoundStart(RoundStartingEventArgs ev)
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