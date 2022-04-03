using UnityEngine;

[ExecuteAlways]
public class LightManager : MonoBehaviour
{
    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightPreset Preset;
    [SerializeField] public int time;
    [SerializeField, Range (0, 100)] private float TimeOfDay = 50;

    private void Update() {
       if(Preset == null) {
           return;
       }
       if(Application.isPlaying){
           if(time == 0){
               time = 1;
           }
           TimeOfDay += Time.deltaTime;
           TimeOfDay %= time;
           Updatelighting(TimeOfDay /time);
       }
    } 
    
   private void Updatelighting(float timePrecent){
       RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePrecent);
       RenderSettings.fogColor = Preset.FogColor.Evaluate(timePrecent);

        if(DirectionalLight != null){
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePrecent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePrecent * 360f)- 90f, 170f,0));
        }
   }

    private void OnValidate() {
       if(DirectionalLight != null) {
           return;
       }
       if(RenderSettings.sun != null){
           DirectionalLight = RenderSettings.sun;
       }
       else{
           Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach (Light light in lights){
                if(light.type == LightType.Directional){
                    DirectionalLight = light;
                    return;
                }
            } 
       }
    }
}
