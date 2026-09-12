using UnrealBuildTool;

public class AMAP5_Editor : ModuleRules
{
    public AMAP5_Editor(ReadOnlyTargetRules Target) : base(Target)
    {
        bUsePrecompiled = true;
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

        // Cross-module headers live in Public/ (currently AnimGraphNode.h, which
        // AMAP5_Importer includes to apply PMX bone constraints); module-internal
        // headers live in Private/. UnrealBuildTool wires the include paths from
        // those folders, so no explicit PublicIncludePaths entry is needed.

        PublicDependencyModuleNames.AddRange(
            new string[] { "Core", "CoreUObject", "Engine", "AMAP5_Runtime", "AnimGraphRuntime" }
        );

        PrivateDependencyModuleNames.AddRange(
            new string[] { "AnimGraph", "BlueprintGraph", "KismetCompiler", "Slate", "SlateCore", "Projects", "UnrealEd", "Kismet", "Json", "JsonUtilities", "InterchangeCore", "AssetRegistry" }
        );
    }
}


