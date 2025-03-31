# LiveView Application Documentation

## Overview

The application can be started with the `LiveView.exe`. When you want to show a full-screen camera application on a display device, it will start the `CameraApp.exe`.

You can create predefined grids in the LiveView application, which can be shown in a Sequence application (`Sequence.exe`) continuously, or multiple grids with specific timings for each grid.

In a grid, you can display one or more cameras.

---

## LiveView.Agent.exe

### Configuration

The `LiveView.Agent.exe` uses an `App.config` file for its settings. Below is an example configuration:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings configProtectionProvider="DataProtectionConfigurationProvider">
    <EncryptedData>
      <CipherData>
        <CipherValue>....</CipherValue>
      </CipherData>
    </EncryptedData>
  </connectionStrings>
  <appSettings>
    <add key="StartCameras" value="[&quot;0&quot;,&quot;E:\\Video\\Natasha Bedingfield - Pocketful of Sunshine (Official Video).mp4&quot;]" />
    <add key="LiveViewServer.IpAddress" value="192.168.0.134" />
    <add key="LiveViewServer.ListenerPort" value="4444" />
  </appSettings>
</configuration>
```

### Configuration Parameters

- **LiveViewServer.IpAddress**: The IP address of the LiveView machine.
- **LiveViewServer.ListenerPort**: The port where LiveView listens for connections.
- **StartCameras**: Specifies which video files or video sources should be started.
  - Example: `<add key="StartCameras" value="1" />` starts the video source with index `1`.
  - Alternatively, a specific video file can be started by providing the file path.

---

## Usage

- **LiveView.exe**: The main application to manage and view live camera feeds.
- **CameraApp.exe**: The full-screen camera viewer, automatically started when needed.
- **Sequence.exe**: Manages the predefined grids and sequences for display.
- **LiveView.Agent.exe**: Handles background processing and configurations for video sources.

---

This document serves as a reference for setting up and configuring the LiveView application and its components.