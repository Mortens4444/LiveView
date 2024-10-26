namespace Mtf.Enums.Network
{
    public enum NetServerEnumInformationLevel
    {
        /// <summary>
        /// Return server names and platform information. The bufptr parameter points to an array of SERVER_INFO_100 structures.
        /// </summary>
        SERVER_INFO_100 = 100,
        /// <summary>
        /// Return server names, types, and associated software. The bufptr parameter points to an array of SERVER_INFO_101 structures.
        /// </summary>
        SERVER_INFO_101 = 101
    }
}
