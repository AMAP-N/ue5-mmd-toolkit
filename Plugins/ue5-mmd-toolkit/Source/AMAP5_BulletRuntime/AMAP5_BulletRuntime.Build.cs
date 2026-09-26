using UnrealBuildTool;
using System.IO;

public class AMAP5_BulletRuntime : ModuleRules
{
    public AMAP5_BulletRuntime(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.NoPCHs;
        PrecompileForTargets = PrecompileTargetsType.Any;

        PublicIncludePaths.AddRange(new string[]
        {
            ModuleDirectory,
        });

        PrivateIncludePaths.AddRange(new string[]
        {
            ModuleDirectory,
        });

        string BulletSrc = Path.Combine(ModuleDirectory, "../ThirdParty/BulletPhysicsEngineLibrary/src");
        string BulletLib = Path.Combine(ModuleDirectory, "../ThirdParty/BulletPhysicsEngineLibrary/lib/Release");

        PublicDefinitions.Add("BT_THREADSAFE=0");

        PublicIncludePaths.Add(BulletSrc);
        PublicAdditionalLibraries.Add(Path.Combine(BulletLib, "BulletDynamics.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(BulletLib, "BulletCollision.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(BulletLib, "LinearMath.lib"));
        PublicAdditionalLibraries.Add(Path.Combine(BulletLib, "BulletSoftBody.lib"));

        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
            "AnimGraphRuntime",
            "Json",
            "JsonUtilities",
            "MovieScene",
            "MovieSceneTracks",
        });

        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "AnimationCore",
            "ComputeFramework",
            "OptimusCore",
            "RenderCore",
            "RHI",
        });
    }
}



