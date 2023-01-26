using Object = Il2CppSystem.Object;
using Photon.Realtime;
using SendOptions = ExitGames.Client.Photon.SendOptions;
using Photon.Pun;
using BinaryFormatter = System.Runtime.Serialization.Formatters.Binary.BinaryFormatter;
using MemoryStream = System.IO.MemoryStream;
using Obfuscation = System.Reflection.ObfuscationAttribute;

namespace ScytheStation.Components.Extensions
{
    internal class PhotonExtensions
    {
        [Obfuscation(Exclude = false)]
        public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions RaiseEventOptions)
        {
            Object customObject2 = Serialization.FromManagedToIL2CPP<Object>(customObject);
            OpRaiseEvent(code, customObject2, RaiseEventOptions);
        }
        public static void OpRaiseEvent(byte code, Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);
        }
    }
    internal static class Serialization
    {
        [Obfuscation(Exclude = false)]
        public static byte[] ToByteArray(Object obj)
        {
            bool flag = obj == null;
            byte[] result;
            if (flag)
            {
                result = null;
            }
            else
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream();
                binaryFormatter.Serialize(memoryStream, obj);
                result = memoryStream.ToArray();
            }
            return result;
        }
        public static byte[] ToByteArray(object obj)
        {
            bool flag = obj == null;
            byte[] result;
            if (flag)
            {
                result = null;
            }
            else
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream();
                binaryFormatter.Serialize(memoryStream, obj);
                result = memoryStream.ToArray();
            }
            return result;
        }
        public static T FromByteArray<T>(byte[] data)
        {
            bool flag = data == null;
            T result;
            if (flag)
            {
                result = default(T);
            }
            else
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (MemoryStream memoryStream = new MemoryStream(data))
                {
                    object obj = binaryFormatter.Deserialize(memoryStream);
                    result = (T)((object)obj);
                }
            }
            return result;
        }
        public static T IL2CPPFromByteArray<T>(byte[] data)
        {
            bool flag = data == null;
            T result;
            if (flag)
            {
                result = default(T);
            }
            else
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream(data);
                object obj = binaryFormatter.Deserialize(memoryStream);
                result = (T)((object)obj);
            }
            return result;
        }
        public static T FromIL2CPPToManaged<T>(Object obj)
        {
            return FromByteArray<T>(ToByteArray(obj));
        }
        public static T FromManagedToIL2CPP<T>(object obj)
        {
            return IL2CPPFromByteArray<T>(ToByteArray(obj));
        }
    }
}
