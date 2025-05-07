### **Live View Setup Documentation**

1. Copy the Live View binary files to your destination folder.  
   - After building the **LiveView** solution, you can find the binaries in:  
     `LiveView\LiveView\bin\Release\net9.0-windows`  
     or  
     `LiveView\LiveView\bin\Release\net462`

2. In the `LiveView\Database` folder, you’ll find the `EncryptedConnectionStringInConfigFile.ps1` (or possibly `.bat`) script, which creates an **encrypted connection string**.  
   You need to insert this string into all `*.config` files — all config files can contain the same connection string.

3. In the `<appSettings>` section of your config, you can define a `StartCameras` key.  
   This allows you to set video sources or video files as camera sources for the Live View Agents.

   ```xml
   <add key="StartCameras" value="[&quot;0&quot;,&quot;E:\\Video\\Natasha Bedingfield - Pocketful of Sunshine (Official Video).mp4&quot;]" />
   ```

   - `"0"` – Refers to the first physical camera.  
   - `"E:\\Video\\..."` – Refers to a video file used as input.

4. You can install the **LiveView.Agent.MAUI** application onto your Android device from the following link:  
   [LiveView.Agent.MAUI](https://play.google.com/apps/internaltest/4701020197417887694)
