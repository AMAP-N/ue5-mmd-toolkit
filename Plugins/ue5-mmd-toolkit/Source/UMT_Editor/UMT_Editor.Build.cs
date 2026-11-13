using UnrealBuildTool;

public class UMT_Editor : ModuleRules
{
    public UMT_Editor(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicDependencyModuleNames.AddRange(
            new string[] { "Core", "CoreUObject", "Engine", "UMT_Runtime", "AnimGraphRuntime" }
        );

        PrivateDependencyModuleNames.AddRange(
            new string[] { "AnimGraph", "BlueprintGraph", "KismetCompiler", "Slate", "SlateCore", "Projects", "UnrealEd", "Kismet", "Json", "JsonUtilities", "InterchangeCore", "AssetRegistry" }
        );
    }
}
