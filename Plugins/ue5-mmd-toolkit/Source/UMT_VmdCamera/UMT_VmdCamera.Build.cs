using UnrealBuildTool;

public class UMT_VmdCamera : ModuleRules
{
    public UMT_VmdCamera(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        PublicIncludePaths.AddRange(
            new string[]
            {
            }
        );


        PrivateIncludePaths.AddRange(
            new string[]
            {
            }
        );

        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core",
                "MovieScene",
                "CinematicCamera",
                "Sequencer",
            }
        );

        PrivateDependencyModuleNames.AddRange(
            new string[]
            {
                "Projects",
                "InputCore",
                "EditorFramework",
                "UnrealEd",
                "ToolMenus",
                "CoreUObject",
                "Engine",
                "Slate",
                "SlateCore",
                "Sequencer",
                "MovieSceneTools",
                "LevelSequenceEditor",
                "DesktopPlatform",
                "CinematicCamera",
                "MovieSceneTracks",
            }
        );


        DynamicallyLoadedModuleNames.AddRange(
            new string[]
            {
            }
        );
    }
}
