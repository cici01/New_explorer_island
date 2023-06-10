import os
import shutil

def findAllFiles(base,suffix):
    for root, ds, fs in os.walk(base):
        for f in fs:
            if f.endswith(suffix) == True:
                fullname = os.path.join(root, f)
                yield fullname


def removeFile(base,suffix):
    for i in findAllFiles(base,suffix):
        #print(i)
        if os.path.exists(i):
            os.remove(i)  

def osRemove(i):
    if os.path.exists(i):
        os.remove(i)      

def main():
    root = os.path.abspath(os.path.join(os.path.dirname(__file__), "../.."))
    root = root + '\\Project\\Assets\\'
    print(root)
    base = root + 'UMA'
    removeFile(base,'.cs')
    removeFile(base,'.cs.meta')
    removeFile(base,'.asmdef')
    removeFile(base,'.asmdef.meta')
    
    removeFile(base,'.pdf')
    removeFile(base,'.pdf.meta')
    removeFile(base,'.txt')
    removeFile(base,'.txt.meta')
    
    shutil.rmtree(base + '\\Content')
    shutil.rmtree(base + '\\Examples')
    shutil.rmtree(base + '\\SQL')
    
    shutil.rmtree(base + '\\Core\\Decals')
    shutil.rmtree(base + '\\Core\\DefaultMissingOverlays') 
    shutil.rmtree(base + '\\Core\\Editor\\Scenes') 
    shutil.rmtree(base + '\\Core\\Extensions\\DynamicCharacterSystem\\UMAAssetBundleManager\\GUI\\Prefabs') 
    shutil.rmtree(base + '\\Core\\Extensions\\UMAPhysics\\PhysicsDefinitions') 
    shutil.rmtree(base + '\\Core\\Scripts\\DNA\\Legacy') 
    
    shutil.rmtree(base + '\\Getting Started\\Deprecated')     
    osRemove(base + '\\Getting Started\\Arrow.fbx')
    osRemove(base + '\\Getting Started\\Arrow.fbx.meta')
    osRemove(base + '\\Getting Started\\ArrowMaterial.mat')
    osRemove(base + '\\Getting Started\\ArrowMaterial.mat.meta')    
    osRemove(base + '\\Getting Started\\Basic Sample Environment.prefab')
    osRemove(base + '\\Getting Started\\Basic Sample Environment.prefab.meta')      
    osRemove(base + '\\Getting Started\\Environment Variant.prefab')
    osRemove(base + '\\Getting Started\\Environment Variant.prefab.meta')          
    osRemove(base + '\\Getting Started\\Environment.prefab')
    osRemove(base + '\\Getting Started\\Environment.prefab.meta')       
    osRemove(base + '\\Getting Started\\GrayMaterial.mat')
    osRemove(base + '\\Getting Started\\GrayMaterial.mat.meta') 
    osRemove(base + '\\Getting Started\\IndicatorMaterial.mat')
    osRemove(base + '\\Getting Started\\IndicatorMaterial.mat.meta')     
    osRemove(base + '\\Getting Started\\light group.prefab')
    osRemove(base + '\\Getting Started\\light group.prefab.meta')                 
    osRemove(base + '\\Getting Started\\New Lighting Settings.lighting')
    osRemove(base + '\\Getting Started\\New Lighting Settings.lighting.meta')    
    osRemove(base + '\\Getting Started\\ReallyWhite.png')
    osRemove(base + '\\Getting Started\\ReallyWhite.png.meta')
    osRemove(base + '\\Getting Started\\UMA_GLIB.prefab')
    osRemove(base + '\\Getting Started\\UMA_GLIB.prefab.meta')       
    osRemove(base + '\\Getting Started\\UMADefaultUtilityEnvironment.prefab')
    osRemove(base + '\\Getting Started\\UMADefaultUtilityEnvironment.prefab.meta')        
    osRemove(base + '\\Getting Started\\UMADynamicCharacterAvatar.prefab')
    osRemove(base + '\\Getting Started\\UMADynamicCharacterAvatar.prefab.meta')         
    osRemove(base + '\\Getting Started\\UMADynamicCharacterAvatar-LOD.prefab')
    osRemove(base + '\\Getting Started\\UMADynamicCharacterAvatar-LOD.prefab.meta')          
    osRemove(base + '\\Getting Started\\UMARandomGeneratedCharacter.prefab')
    osRemove(base + '\\Getting Started\\UMARandomGeneratedCharacter.prefab.meta')      
        
    osRemove(base + '\\InternalDataStore\\AssetVersion.xml')
    osRemove(base + '\\InternalDataStore\\AssetVersion.xml.meta')          
    osRemove(base + '\\InternalDataStore\\Uma32.png')
    osRemove(base + '\\InternalDataStore\\Uma32.png.meta')   
    osRemove(base + '\\InternalDataStore\\UmaBanner.png')
    osRemove(base + '\\InternalDataStore\\UmaBanner.png.meta')    
    osRemove(base + '\\InternalDataStore\\UmaIconOverlay.png')
    osRemove(base + '\\InternalDataStore\\UmaIconOverlay.png.meta')    
    osRemove(base + '\\InternalDataStore\\UmaIconSlot.png')
    osRemove(base + '\\InternalDataStore\\UmaIconSlot.png.meta')        
    osRemove(base + '\\InternalDataStore\\UmaIconWardrobe.png')
    osRemove(base + '\\InternalDataStore\\UmaIconWardrobe.png.meta')          
    osRemove(base + '\\InternalDataStore\\UMAIndex.png')
    osRemove(base + '\\InternalDataStore\\UMAIndex.png.meta')  
    osRemove(base + '\\InternalDataStore\\InGame\\Resources\\UtilityMarker1.mat')
    osRemove(base + '\\InternalDataStore\\InGame\\Resources\\UtilityMarker1.mat.meta')      
    osRemove(base + '\\InternalDataStore\\InGame\\Resources\\UtilityMarker2.mat')
    osRemove(base + '\\InternalDataStore\\InGame\\Resources\\UtilityMarker2.mat.meta')      
    osRemove(base + '\\InternalDataStore\\InGame\\Resources\\UtilitySelectorMaterial.mat')
    osRemove(base + '\\InternalDataStore\\InGame\\Resources\\UtilitySelectorMaterial.mat.meta')         
    shutil.rmtree(base + '\\InternalDataStore\\InGame\\Resources\\PlaceholderAssets')             
        
        
    shutil.rmtree(base + '\\MeshAnimator\\Editor');
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Example_Crowd');      
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Example_CrowdAI');      
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Example_PerformanceComparison');      
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Example_PerformanceComparisonCubes');       
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Meshes\\BirdModel');         
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Meshes\\SkeletonModel');       
    shutil.rmtree(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel');           
     
    # shutil.rmtree(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations');              
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\CrowdController.controller')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\CrowdController.controller.meta')    
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\HumanCrowd.prefab')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\HumanCrowd.prefab.meta')        
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\HumanRunning.prefab')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\HumanRunning.prefab.meta')        
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\SkinnedController.controller')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\SkinnedController.controller.meta')                 
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@BreathingIdle.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@BreathingIdle.fbx.meta')        
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Cheering.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Cheering.fbx.meta')            
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Clapping.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Clapping.fbx.meta')        
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@LeftStrafe.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@LeftStrafe.fbx.meta')         
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@RightStrafe.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@RightStrafe.fbx.meta')      
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Running.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Running.fbx.meta')          
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@RunningBackward.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@RunningBackward.fbx.meta')       
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@StableSwordInwardSlash.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@StableSwordInwardSlash.fbx.meta')          
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@StableSwordOutwardSlash.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@StableSwordOutwardSlash.fbx.meta')             
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Victory.fbx')     
    # osRemove(base + '\\MeshAnimator\\Examples\\Meshes\\HumanModel\\Animations\\Human@Victory.fbx.meta')               
            
            
    osRemove(base + '\\MeshAnimator\\ShaderGraph\\Example_MeshAnimatorShaderGraph.shadergraph')     
    osRemove(base + '\\MeshAnimator\\ShaderGraph\\Example_MeshAnimatorShaderGraph.shadergraph.meta')                
    osRemove(base + '\\MeshAnimator\\ShaderGraph\\Example_MeshAnimatorShaderGraphMaterial.mat')     
    osRemove(base + '\\MeshAnimator\\ShaderGraph\\Example_MeshAnimatorShaderGraphMaterial.mat.meta')    
    osRemove(base + '\\MeshAnimator\\ShaderGraph\\MeshAnimatorSubGraph.shadersubgraph')     
    osRemove(base + '\\MeshAnimator\\ShaderGraph\\MeshAnimatorSubGraph.shadersubgraph.meta')    

    osRemove(base + '\\MeshAnimator\\documentation.html')     
    osRemove(base + '\\MeshAnimator\\documentation.html.meta')                    
            
    base = root + 'Plugins'
    removeFile(base,'.pdb')
    removeFile(base,'.pdb.meta')
    removeFile(base,'.mdb')
    removeFile(base,'.mdb.meta')
    
    
    

if __name__ == '__main__':
    main()