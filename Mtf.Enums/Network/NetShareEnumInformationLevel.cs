namespace Mtf.Enums.Network
{
    public enum NetShareEnumInformationLevel
    {
        /// <summary>
        /// Return share names. The bufptr parameter points to an array of SHARE_INFO_0 structures. Windows Me/98/95: This value is not supported.
        /// </summary>
        SHARE_INFO_0 = 0,
        /// <summary>
        /// Return information about shared resources, including the name and type of the resource, and a comment associated with the resource. The bufptr parameter points to an array of SHARE_INFO_1 structures. Windows Me/98/95: The pbBuffer parameter points to an array of share_info_1 structures.
        /// </summary>
        SHARE_INFO_1 = 1,
        /// <summary>
        /// Return information about shared resources, including name of the resource, type and permissions, password, and number of connections. The bufptr parameter points to an array of SHARE_INFO_2 structures. Windows Me/98/95: This value is not supported.
        /// </summary>
        SHARE_INFO_2 = 2,

        /// <summary>
        /// Windows Me/98/95: Return information about shared resources, including the name and type of the resource, a comment associated with the resource, and passwords. The pbBuffer parameter points to an array of share_info_50 structures.
        /// </summary>
        SHARE_INFO_50 = 50,
        /// <summary>
        /// Return information about shared resources, including name of the resource, type and permissions, number of connections, and other pertinent information. The bufptr parameter points to an array of SHARE_INFO_502 structures. Windows Me/98/95: This value is not supported.
        /// </summary>
        SHARE_INFO_502 = 502,
        /// <summary>
        /// Return information about shared resources, including name of the resource, type and permissions, number of connections, and other pertinent information. The bufptr parameter points to an array of SHARE_INFO_503 structures. Windows 2003 and Windows XP: This information level is not supported.
        /// </summary>
        SHARE_INFO_503 = 503
    }

}
