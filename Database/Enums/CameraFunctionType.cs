using System.ComponentModel;

namespace Database.Enums
{
    public enum CameraFunctionType
    {
        [Description("Stop PTZ movement")]
        PTZ_Stop,
        [Description("Move PTZ up")]
        PTZ_Up,
        [Description("Move PTZ down")]
        PTZ_Down,
        [Description("Move PTZ left")]
        PTZ_Left,
        [Description("Move PTZ right")]
        PTZ_Right,

        [Description("Calibrate PTZ")]
        PTZ_Calibrate,
        [Description("Zoom in")]
        PTZ_Zoom_In,
        [Description("Zoom out")]
        PTZ_Zoom_Out,
        [Description("Enable auto-focus")]
        PTZ_Auto_Focus,
        [Description("Enable manual focus")]
        PTZ_Manual_Focus,

        [Description("Move PTZ up and left")]
        PTZ_Up_And_Left,
        [Description("Move PTZ up and right")]
        PTZ_Up_And_Right,
        [Description("Move PTZ down and left")]
        PTZ_Down_And_Left,
        [Description("Move PTZ down and right")]
        PTZ_Down_And_Right,

        [Description("Start vertical patrol")]
        PTZ_Start_Vertical_Patrol,
        [Description("Stop vertical patrol")]
        PTZ_Stop_Vertical_Patrol,
        [Description("Start horizontal patrol")]
        PTZ_Start_Horizontal_Patrol,
        [Description("Stop horizontal patrol")]
        PTZ_Stop_Horizontal_Patrol,

        [Description("Move PTZ to home position")]
        PTZ_Go_To_Home,

        [Description("Turn digital output on")]
        Digital_Output_On,
        [Description("Turn digital output off")]
        Digital_Output_Off,

        [Description("Flip image horizontally")]
        Flip_Image_Horizontally,
        [Description("Flip image vertically")]
        Flip_Image_Vertically,

        [Description("Set exposure to auto")]
        Set_Exposure_To_Auto,
        [Description("Set exposure to manual")]
        Set_Exposure_To_Manual,

        [Description("Enable night vision")]
        Enable_Night_Vision,
        [Description("Disable night vision")]
        Disable_Night_Vision,

        [Description("Set IR LED mode to auto")]
        Set_IR_Led_To_Auto,
        [Description("Turn IR LED on")]
        Set_IR_Led_To_On,
        [Description("Turn IR LED off")]
        Set_IR_Led_To_Off,

        [Description("Enable motion detection")]
        Enable_Motion_Detection,
        [Description("Disable motion detection")]
        Disable_Motion_Detection,
        [Description("Enable sound detection")]
        Enable_Sound_Detection,
        [Description("Disable sound detection")]
        Disable_Sound_Detection,
        [Description("Turn alarm output on")]
        Set_Alarm_Output_On,
        [Description("Turn alarm output off")]
        Set_Alarm_Output_Off,

        [Description("Enable Wide Dynamic Range (WDR)")]
        Enable_Wide_Dynamic_Range,
        [Description("Disable Wide Dynamic Range (WDR)")]
        Disable_Wide_Dynamic_Range,
        [Description("Enable RTSP")]
        Enable_RTSP,
        [Description("Disable RTSP")]
        Disable_RTSP,
        [Description("Set RTSP port")]
        Set_RTSP_Port,
        [Description("Set HTTP port")]
        Set_HTTP_Port,
        [Description("Set HTTPS port")]
        Set_HTTPS_Port,
        [Description("Enable FTP")]
        Enable_FTP,
        [Description("Disable FTP")]
        Disable_FTP,
        [Description("Enable DDNS")]
        Enable_DDNS,
        [Description("Disable DDNS")]
        Disable_DDNS,
        [Description("Enable UPNP")]
        Enable_UPNP,
        [Description("Disable UPNP")]
        Disable_UPNP,
        [Description("Enable SSH")]
        Enable_SSH,
        [Description("Disable SSH")]
        Disable_SSH,
        [Description("Enable Telnet")]
        Enable_Telnet,
        [Description("Disable Telnet")]
        Disable_Telnet,
        [Description("Reset camera to factory settings")]
        Factory_Reset,
        [Description("Reboot camera")]
        Reboot,

        [Description("Test email configuration")]
        Test_Mail,
        [Description("Test FTP configuration")]
        Test_FTP,

        [Description("PTZ save preset 0 position")]
        PTZ_Save_Preset_0,
        [Description("PTZ save preset 1 position")]
        PTZ_Save_Preset_1,
        [Description("PTZ save preset 2 position")]
        PTZ_Save_Preset_2,
        [Description("PTZ save preset 3 position")]
        PTZ_Save_Preset_3,
        [Description("PTZ save preset 4 position")]
        PTZ_Save_Preset_4,
        [Description("PTZ save preset 5 position")]
        PTZ_Save_Preset_5,
        [Description("PTZ save preset 6 position")]
        PTZ_Save_Preset_6,
        [Description("PTZ save preset 7 position")]
        PTZ_Save_Preset_7,
        [Description("PTZ save preset 8 position")]
        PTZ_Save_Preset_8,
        [Description("PTZ save preset 9 position")]
        PTZ_Save_Preset_9,
        [Description("PTZ save preset 10 position")]
        PTZ_Save_Preset_10,
        [Description("PTZ save preset 11 position")]
        PTZ_Save_Preset_11,
        [Description("PTZ save preset 12 position")]
        PTZ_Save_Preset_12,
        [Description("PTZ save preset 13 position")]
        PTZ_Save_Preset_13,
        [Description("PTZ save preset 14 position")]
        PTZ_Save_Preset_14,
        [Description("PTZ save preset 15 position")]
        PTZ_Save_Preset_15,
        [Description("PTZ save preset 16 position")]
        PTZ_Save_Preset_16,
        [Description("PTZ save preset 17 position")]
        PTZ_Save_Preset_17,
        [Description("PTZ save preset 18 position")]
        PTZ_Save_Preset_18,
        [Description("PTZ save preset 19 position")]
        PTZ_Save_Preset_19,
        [Description("PTZ save preset 20 position")]
        PTZ_Save_Preset_20,

        [Description("PTZ load preset 0 position")]
        PTZ_Load_Preset_0,
        [Description("PTZ load preset 1 position")]
        PTZ_Load_Preset_1,
        [Description("PTZ load preset 2 position")]
        PTZ_Load_Preset_2,
        [Description("PTZ load preset 3 position")]
        PTZ_Load_Preset_3,
        [Description("PTZ load preset 4 position")]
        PTZ_Load_Preset_4,
        [Description("PTZ load preset 5 position")]
        PTZ_Load_Preset_5,
        [Description("PTZ load preset 6 position")]
        PTZ_Load_Preset_6,
        [Description("PTZ load preset 7 position")]
        PTZ_Load_Preset_7,
        [Description("PTZ load preset 8 position")]
        PTZ_Load_Preset_8,
        [Description("PTZ load preset 9 position")]
        PTZ_Load_Preset_9,
        [Description("PTZ load preset 10 position")]
        PTZ_Load_Preset_10,
        [Description("PTZ load preset 11 position")]
        PTZ_Load_Preset_11,
        [Description("PTZ load preset 12 position")]
        PTZ_Load_Preset_12,
        [Description("PTZ load preset 13 position")]
        PTZ_Load_Preset_13,
        [Description("PTZ load preset 14 position")]
        PTZ_Load_Preset_14,
        [Description("PTZ load preset 15 position")]
        PTZ_Load_Preset_15,
        [Description("PTZ load preset 16 position")]
        PTZ_Load_Preset_16,
        [Description("PTZ load preset 17 position")]
        PTZ_Load_Preset_17,
        [Description("PTZ load preset 18 position")]
        PTZ_Load_Preset_18,
        [Description("PTZ load preset 19 position")]
        PTZ_Load_Preset_19,
        [Description("PTZ load preset 20 position")]
        PTZ_Load_Preset_20,

        [Description("Set saturation to 0")]
        Set_Saturation_To_0,
        [Description("Set saturation to 1")]
        Set_Saturation_To_1,
        [Description("Set saturation to 2")]
        Set_Saturation_To_2,
        [Description("Set saturation to 3")]
        Set_Saturation_To_3,
        [Description("Set saturation to 4")]
        Set_Saturation_To_4,
        [Description("Set saturation to 5")]
        Set_Saturation_To_5,
        [Description("Set saturation to 6")]
        Set_Saturation_To_6,
        [Description("Set saturation to 7")]
        Set_Saturation_To_7,
        [Description("Set saturation to 8")]
        Set_Saturation_To_8,
        [Description("Set saturation to 9")]
        Set_Saturation_To_9,
        [Description("Set saturation to 10")]
        Set_Saturation_To_10,

        [Description("Set sharpness to 0")]
        Set_Sharpness_To_0,
        [Description("Set sharpness to 1")]
        Set_Sharpness_To_1,
        [Description("Set sharpness to 2")]
        Set_Sharpness_To_2,
        [Description("Set sharpness to 3")]
        Set_Sharpness_To_3,
        [Description("Set sharpness to 4")]
        Set_Sharpness_To_4,
        [Description("Set sharpness to 5")]
        Set_Sharpness_To_5,
        [Description("Set sharpness to 6")]
        Set_Sharpness_To_6,
        [Description("Set sharpness to 7")]
        Set_Sharpness_To_7,
        [Description("Set sharpness to 8")]
        Set_Sharpness_To_8,
        [Description("Set sharpness to 9")]
        Set_Sharpness_To_9,
        [Description("Set sharpness to 10")]
        Set_Sharpness_To_10,

        [Description("Set brightness to 0")]
        Set_Brightness_To_0,
        [Description("Set brightness to 1")]
        Set_Brightness_To_1,
        [Description("Set brightness to 2")]
        Set_Brightness_To_2,
        [Description("Set brightness to 3")]
        Set_Brightness_To_3,
        [Description("Set brightness to 4")]
        Set_Brightness_To_4,
        [Description("Set brightness to 5")]
        Set_Brightness_To_5,
        [Description("Set brightness to 6")]
        Set_Brightness_To_6,
        [Description("Set brightness to 7")]
        Set_Brightness_To_7,
        [Description("Set brightness to 8")]
        Set_Brightness_To_8,
        [Description("Set brightness to 9")]
        Set_Brightness_To_9,
        [Description("Set brightness to 10")]
        Set_Brightness_To_10,

        [Description("Set contrast to 0")]
        Set_Contrast_To_0,
        [Description("Set contrast to 1")]
        Set_Contrast_To_1,
        [Description("Set contrast to 2")]
        Set_Contrast_To_2,
        [Description("Set contrast to 3")]
        Set_Contrast_To_3,
        [Description("Set contrast to 4")]
        Set_Contrast_To_4,
        [Description("Set contrast to 5")]
        Set_Contrast_To_5,
        [Description("Set contrast to 6")]
        Set_Contrast_To_6,
        [Description("Set contrast to 7")]
        Set_Contrast_To_7,
        [Description("Set contrast to 8")]
        Set_Contrast_To_8,
        [Description("Set contrast to 9")]
        Set_Contrast_To_9,
        [Description("Set contrast to 10")]
        Set_Contrast_To_10,

        [Description("Set speed to 0")]
        Set_Speed_To_0,
        [Description("Set speed to 1")]
        Set_Speed_To_1,
        [Description("Set speed to 2")]
        Set_Speed_To_2,
        [Description("Set speed to 3")]
        Set_Speed_To_3,
        [Description("Set speed to 4")]
        Set_Speed_To_4,
        [Description("Set speed to 5")]
        Set_Speed_To_5,
        [Description("Set speed to 6")]
        Set_Speed_To_6,
        [Description("Set speed to 7")]
        Set_Speed_To_7,
        [Description("Set speed to 8")]
        Set_Speed_To_8,
        [Description("Set speed to 9")]
        Set_Speed_To_9,
        [Description("Set speed to 10")]
        Set_Speed_To_10,

        [Description("Set light frequency to 50 Hz")]
        Set_Light_Frequency_To_50_Hz,
        [Description("Set light frequency to 60 Hz")]
        Set_Light_Frequency_To_60_Hz,
        [Description("Set light frequency to outdoors")]
        Set_Light_Frequency_To_Outdoors,

        [Description("Set frame rate to 5 FPS")]
        Set_Frame_Rate_To_5_FPS,
        [Description("Set frame rate to 10 FPS")]
        Set_Frame_Rate_To_10_FPS,
        [Description("Set frame rate to 15 FPS")]
        Set_Frame_Rate_To_15_FPS,
        [Description("Set frame rate to 25 FPS")]
        Set_Frame_Rate_To_25_FPS,
        [Description("Set frame rate to 30 FPS")]
        Set_Frame_Rate_To_30_FPS,
        [Description("Set frame rate to 60 FPS")]
        Set_Frame_Rate_To_60_FPS,

        [Description("Set resolution to 320x240")]
        Set_Resolution_320_x_240,
        [Description("Set resolution to 640x480")]
        Set_Resolution_640_x_480,

        [Description("Check user")]
        Check_User,
        [Description("Get camera parameters")]
        Get_Camera_Parameters,
        [Description("Get status")]
        Get_Status,

        [Description("Set camera name")]
        Set_Camera_Name,
        [Description("Set date and time")]
        Set_Date_And_Time,
        [Description("Set users")]
        Set_Users,
        [Description("Set network")]
        Set_Network,
        [Description("Set WiFi")]
        Set_WiFi,
        [Description("Set mail")]
        Set_Mail,
        [Description("Set alarm")]
        Set_Alarm,
        [Description("Set misc")]
        Set_Misc,
    }
}
