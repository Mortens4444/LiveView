using System;

namespace Mtf.Enums.Display
{
    [Flags]
    public enum SetDisplayConfigFlags
    {
        /// <summary>
        /// The resulting topology, source, and target mode is set.
        /// </summary>
        SDC_APPLY = 0x00000080,
        /// <summary>
        /// A modifier to the SDC_APPLY flag. This causes the change mode to be forced all the way down to the driver for each active display.
        /// </summary>
        SDC_NO_OPTIMIZATION = 0x00000100,
        /// <summary>
        /// The topology, source, and target mode information that are supplied in the pathArray and the modeInfoArray parameters are used, rather than looking up the configuration in the database.
        /// </summary>
        SDC_USE_SUPPLIED_DISPLAY_CONFIG,
        /// <summary>
        /// The resulting topology, source, and target mode are saved to the database.
        /// </summary>
        SDC_SAVE_TO_DATABASE = 0x00000200,
        /// <summary>
        /// The system tests for the requested topology, source, and target mode information to determine whether it can be set.
        /// </summary>
        SDC_VALIDATE = 0x00000040,
        /// <summary>
        /// If required, the function can modify the specified source and target mode information in order to create a functional display path set.
        /// </summary>
        SDC_ALLOW_CHANGES = 0x00000400,
        /// <summary>
        /// The caller requests the last clone configuration from the persistence database.
        /// </summary>
        SDC_TOPOLOGY_CLONE = 0x00000002,
        /// <summary>
        /// The caller requests the last extended configuration from the persistence database.
        /// </summary>
        SDC_TOPOLOGY_EXTEND = 0x00000004,
        /// <summary>
        /// The caller requests the last internal configuration from the persistence database.
        /// </summary>
        SDC_TOPOLOGY_INTERNAL = 0x00000001,
        /// <summary>
        /// The caller requests the last external configuration from the persistence database.
        /// </summary>
        SDC_TOPOLOGY_EXTERNAL = 0x00000008,
        /// <summary>
        /// The caller provides the path data so the function only queries the persistence database to find and use the source and target mode.
        /// </summary>
        SDC_TOPOLOGY_SUPPLIED = 0x00000010,
        /// <summary>
        /// The caller requests a combination of all four SDC_TOPOLOGY_XXX configurations. This value informs the API to set the last known display configuration for the current connected monitors.
        /// </summary>
        SDC_USE_DATABASE_CURRENT = (SDC_TOPOLOGY_INTERNAL | SDC_TOPOLOGY_CLONE | SDC_TOPOLOGY_EXTEND | SDC_TOPOLOGY_EXTERNAL),
        /// <summary>
        /// When the function processes a SDC_TOPOLOGY_XXX request, it can force path persistence on a target to satisfy the request if necessary. For information about the other flags that this flag can be combined with, see the following list.
        /// </summary>
        SDC_PATH_PERSIST_IF_REQUIRED = 0x00000800,
        /// <summary>
        /// The caller requests that the driver is given an opportunity to update the GDI mode list while SetDisplayConfig sets the new display configuration. This flag value is only valid when the SDC_USE_SUPPLIED_DISPLAY_CONFIG and SDC_APPLY flag values are also specified.
        /// </summary>
        SDC_FORCE_MODE_ENUMERATION = 0x00001000,
        /// <summary>
        /// A modifier to the SDC_TOPOLOGY_SUPPLIED flag that indicates that SetDisplayConfig should ignore the path order of the supplied topology when searching the database. When this flag is set, the topology set is the most recent topology that contains all the paths regardless of the path order.
        /// </summary>
        SDC_ALLOW_PATH_ORDER_CHANGES = 0x00002000
    }

}
