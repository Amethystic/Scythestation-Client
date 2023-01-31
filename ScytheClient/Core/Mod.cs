namespace ScytheStation.Core
{
    public class Module
    {
        public virtual void Start()
        {
        }
        public virtual void QuickMenuInit()
        {
        }
        public virtual void SocialMenuInit(VRC.Core.APIUser aPIUser)
        {
        }
        public virtual void HUDMenuInit(VRC.UI.Elements.UIMenu uIMenu)
        {
        }
        public virtual void LocalPlayerLoaded(VRC.Core.ApiAvatar apiAvatar)
        {
        }
        public virtual void LocalPlayerLoaded(VRC.Core.APIUser apiUser)
        {
        }
        public virtual void WorldLoaded(VRC.Core.ApiWorld world, VRC.Core.ApiWorldInstance instance)
        {
        }
        public virtual void SceneLoaded(int buildIndex, string sceneName)
        {
        }
        public virtual void PlayerJoined(VRC.Player player)
        {
        }
        public virtual void PlayerLeft(VRC.Player player)
        {
        }
    }
}
