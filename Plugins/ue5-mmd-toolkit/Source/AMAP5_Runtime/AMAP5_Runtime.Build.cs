using UnrealBuildTool;

public class AMAP5_Runtime : ModuleRules
{
    public AMAP5_Runtime(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.NoPCHs;
        PrecompileForTargets = PrecompileTargetsType.Any;

        PublicDependencyModuleNames.AddRange(
            new string[] { "Core", "CoreUObject", "Engine", "AnimGraphRuntime", "InterchangeCore", "IKRig" }
        );

        PrivateDependencyModuleNames.AddRange(new string[] { });
    }
}



