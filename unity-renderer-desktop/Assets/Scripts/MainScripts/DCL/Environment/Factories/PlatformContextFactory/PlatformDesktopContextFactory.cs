using System;
using DCL.Rendering;
using UnityEngine;

namespace DCL
{
    public static class PlatformDesktopContextFactory
    {
        public static PlatformContext CreateDefault()
        {
            if (SceneReferences.i.bridgeGameObject != null)
                return CreateDefault(SceneReferences.i.bridgeGameObject);

            return CreateDefault(null);
        }

        public static PlatformContext CreateDefault(GameObject bridgesGameObject)
        {
            return new PlatformContext(
                memoryManager: new MemoryManagerDesktop(),
                cullingController: CullingController.Create(),
                clipboard: Clipboard.Create(),
                physicsSyncController: new PhysicsSyncController(),
                parcelScenesCleaner: new ParcelScenesCleaner(),
                webRequest: WebRequestController.Create(),
                serviceProviders: new ServiceProviders(),
                idleChecker: new IdleChecker(),
                avatarsLODController: new AvatarsLODController(),
                featureFlagController: new FeatureFlagController(bridgesGameObject));
        }
    }
}