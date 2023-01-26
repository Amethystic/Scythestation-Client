using MelonLoader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Components
{
    internal static class Settings
    {
        [Obfuscation(Exclude = false)]
        private static readonly string SavePath = Path.Combine(Main.Directory, "Configs", "Settings.json");
        private static readonly Dictionary<string, dynamic> Properties = new();
#pragma warning disable CS8632
        private static Dictionary<string, dynamic>? LoadedValues;
        internal static void Load()
        {
            if (!File.Exists(SavePath))
            {
                MelonLogger.Warning("[CONFIGSYSTEM] Settings file not found, will be created at next save.");
                return;
            }

            LoadedValues = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(File.ReadAllText(SavePath));

            if (LoadedValues == null)
                return;

            foreach (KeyValuePair<string, dynamic> property in Properties)
                foreach (KeyValuePair<string, dynamic> loadedValue in LoadedValues)
                    if (property.Key == loadedValue.Key)
                        property.Value.TrySet(loadedValue.Value);
        }

        internal static void Save()
        {
            Dictionary<string, dynamic> saveValues = new();

            foreach (KeyValuePair<string, dynamic> property in Properties)
                saveValues.Add(property.Key, property.Value.Value);

            if (!Directory.Exists(Main.Directory))
                Directory.CreateDirectory(Main.Directory);

            File.WriteAllText(SavePath, JsonConvert.SerializeObject(saveValues));
        }
        private static readonly SaveProperty<int> AutosaveDelay = new("Autosave Delay", 100000);
        private static Task? AutosaveTask;
        private static readonly CancellationTokenSource AutosaveTokenSource = new();
        internal static void StartAutosave()
        {
            AutosaveTask = Task.Run(async () =>
            {
                await Task.Delay(AutosaveDelay, AutosaveTokenSource.Token);

                Save();
                MelonLogger.Msg("[AUTOSAVER] Config AutoSaving");
            });
        }

        internal static void StopAutosave()
        {
            AutosaveTokenSource.Cancel();
            AutosaveTask?.Wait();
            MelonLogger.Msg("[AUTOSAVER] Config Stopped AutoSaving");
        }

        [Serializable]
        public sealed class SaveProperty<T>
        {
            public T Value { get; set; }

            public SaveProperty(string name, T defaultValue)
            {
                Value = defaultValue;

                if (LoadedValues != null && LoadedValues.TryGetValue(name, out dynamic? value))
                    TrySet(value);

                Properties.Add(name, this);
            }

            public static implicit operator T(SaveProperty<T> property) => property.Value;

            internal void TrySet(dynamic jsonValue)
            {
                dynamic? value;
                if (jsonValue is JObject valueObject)
                    value = valueObject.ToObject<T>();
                else if (jsonValue is JArray valueArray)
                    value = valueArray.ToObject<T>();
                else
                    value = (T)jsonValue;

                if (value != null)
                    Value = value;
            }
#pragma warning restore CS8632
        }
    }
}