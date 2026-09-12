using UnrealBuildTool;

public class AMAP5_Runtime : ModuleRules
{
    public AMAP5_Runtime(ReadOnlyTargetRules Target) : base(Target)
    {
        bUsePrecompiled = true;
        PCHUsage = PCHUsageMode.NoPCHs;

        PublicDependencyModuleNames.AddRange(
            new string[] { "Core", "CoreUObject", "Engine", "AnimGraphRuntime", "InterchangeCore" }
        );

        PrivateDependencyModuleNames.AddRange(new string[] { });
    }
}



