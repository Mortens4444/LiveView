using System;

namespace Mtf.Enums.Audio
{
    [Flags]
    public enum SoundFlags
    {
        /// <summary>
        /// Play syncronously (default)
        /// </summary>
        SND_SYNC = 0x00000000,
        /// <summary>
        /// Play asyncronously
        /// </summary>
        SND_ASYNC = 0x00000001,
        /// <summary>
        /// Silence (not default) if sound not found
        /// </summary>
        SND_NODEFAULT = 0x00000002,
        /// <summary>
        /// pszSound points to a memory file
        /// </summary>
        SND_MEMORY = 0x00000004,
        /// <summary>
        /// Loop the sound file until next sndPlaySound
        /// </summary>
        SND_LOOP = 0x00000008,
        /// <summary>
        /// Don't stop any currently playing sound
        /// </summary>
        SND_NOSTOP = 0x00000010,
        /// <summary>
        /// Stop playing wave
        /// </summary>
        SND_PURGE = 0x00000040,
        /// <summary>
        /// Don't wait if the driver is busy
        /// </summary>
        SND_NOWAIT = 0x00002000,
        /// <summary>
        /// Name is a registry alias
        /// </summary>
        SND_ALIAS = 0x00,
        /// <summary>
        /// Alias is a predefined id
        /// </summary>
        SND_ALIAS_ID = 0x00110000,
        /// <summary>
        /// Name is filename
        /// </summary>
        SND_FILENAME = 0x00020000,
        /// <summary>
        /// Name is resource name or atom
        /// </summary>
        SND_RESOURCE = 0x00040004,
    }
}
