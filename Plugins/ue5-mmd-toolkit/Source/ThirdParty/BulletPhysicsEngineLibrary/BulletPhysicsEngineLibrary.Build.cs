// Fill out your copyright notice in the Description page of Project Settings.

using System.IO;
using UnrealBuildTool;

public class BulletPhysicsEngineLibrary : ModuleRules
{
	public BulletPhysicsEngineLibrary(ReadOnlyTargetRules Target) : base(Target)
	{
        bUsePrecompiled = true;
		Type = ModuleType.External;


		   bool bDebug = Target.Configuration == UnrealTargetConfiguration.Debug || Target.Configuration == UnrealTargetConfiguration.DebugGame;
        bool bDevelopment = Target.Configuration == UnrealTargetConfiguration.Development;

        string BuildFolder = bDebug ? "Debug":
            bDevelopment ? "RelWithDebInfo" : "Release";
        string BuildSuffix = bDebug ? "_Debug":
            bDevelopment ? "_RelWithDebugInfo" : "";

        // Library path
        string LibrariesPath = Path.Combine(ModuleDirectory, "lib", BuildFolder);
        PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "BulletCollision" + BuildSuffix + ".lib")); 
        PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "BulletDynamics" + BuildSuffix + ".lib")); 
        PublicAdditionalLibraries.Add(Path.Combine(LibrariesPath, "LinearMath" + BuildSuffix + ".lib")); 

        // Include path (I'm just using the source here since Bullet has mixed src & headers)
       PublicIncludePaths.Add( Path.Combine( ModuleDirectory, "src" ) );
       PublicDefinitions.Add("WITH_BULLET_BINDING=1");
			
			
			
        
      
	}
}


