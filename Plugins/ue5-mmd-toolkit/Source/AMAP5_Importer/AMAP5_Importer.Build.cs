using UnrealBuildTool;

public class AMAP5_Importer : ModuleRules
{
    public AMAP5_Importer(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
        PublicDependencyModuleNames.AddRange(new string[]
        {
            "Core",
            "CoreUObject",
            "Engine",
            "DeveloperSettings",
            "InterchangeCore",
            "PhysicsCore",
            "AMAP5_Runtime",
            "MeshDescription",
        });

        PrivateDependencyModuleNames.AddRange(new string[]
        {
            "UnrealEd",
            "RenderCore",
            "RHI",
            "StaticMeshDescription",
            "SkeletalMeshDescription",
            "AnimationCore",
            "AssetRegistry",
            "ImageCore",
            "ImageWrapper",
            "AnimGraph",
            "KismetCompiler",
            "MaterialEditor",
            "BlueprintGraph",
            "SkeletalMeshModifiers",
            "Slate",
            "SlateCore",
            "InputCore",
            "AssetTools",
            "AMAP5_Deform",
            "AMAP5_Editor",
            "AMAP5_BulletRuntime",
            "SkeletalMeshEditor",
            "ContentBrowser",
            "ContentBrowserData",
            "PropertyEditor",
            "IKRig",
            "IKRigEditor",
            "ControlRig",
            "ControlRigDeveloper",
            "ControlRigEditor",
            "RigVM",
            "RigVMDeveloper",
            "ToolMenus",
            "Projects",
            "Json",
            "EditorScriptingUtilities",
        });
    }
}
