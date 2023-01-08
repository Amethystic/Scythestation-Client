using ScytheStation.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MelonLoader;
using System.Threading.Tasks;
using VRC;

namespace ScytheStation.Components
{
    internal class CloningState
    {
        public static void Allow()
        {
            //Force clone button? nah this just defaults everyone's cloning to on ez win
            try
            {
                foreach (var player in PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0)
                {
                    if (player.prop_APIUser_0.allowAvatarCopying.Equals(false))
                    {
                        player.prop_APIUser_0.allowAvatarCopying = true;
                    }
                }
            }
            catch { }
        }
    }
}
