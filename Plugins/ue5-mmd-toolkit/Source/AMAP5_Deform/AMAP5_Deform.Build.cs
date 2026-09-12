using UnrealBuildTool;

public class AMAP5_Deform : ModuleRules
{
    public AMAP5_Deform(ReadOnlyTargetRules Target) : base(Target)
    {
        bUsePrecompiled = true;
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine"
        });

        PrivateDependencyModuleNames.AddRange(new string[]
        {
			"AssetRegistry",
            "ComputeFramework",
            "OptimusCore",
            "UnrealEd"
        });
    }
}


