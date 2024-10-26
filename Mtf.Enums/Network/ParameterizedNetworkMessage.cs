namespace Mtf.Enums.Network
{
    public enum ParameterizedNetworkMessage : int
    {
        /// <summary>Syntax: ACCT account-info
        /// This command is used to send account information on systems that require it. Typically sent after a PASS command.</summary>
        FTP_ACCT,
        /// <summary>Syntax: ALLO size [R max-record-size]
        /// Allocates sufficient storage space to receive a file. If the maximum size of a record also needs to be known, that is sent as a second numeric parameter following a space, the capital letter "R", and another space.</summary>
        FTP_ALLO,
        /// <summary>Syntax: APPE remote-filename
        /// Append data to the end of a file on the remote host. If the file does not already exist, it is created. This command must be preceded by a PORT or PASV command so that the server knows where to receive data from.</summary>
        FTP_APPE,
        /// <summary>Syntax: CWD remote-directory
        /// Makes the given directory be the current directory on the remote host.</summary>
        FTP_CWD,
        /// <summary>Syntax: DELE remote-filename
        /// Deletes the given file on the remote host.</summary>
        FTP_DELE,
        /// <summary>Syntax: HELP [command]
        /// If a command is given, returns help on that command; otherwise, returns general help for the FTP server (usually a list of supported commands).</summary>
        FTP_HELP,
        /// <summary>LIST [remote-filespec]
        /// If remote-filespec refers to a file, sends information about that file. If remote-filespec refers to a directory, sends information about each file in that directory. remote-filespec defaults to the current directory. This command must be preceded by a PORT or PASV command.</summary>
        FTP_LIST,
        /// <summary>Syntax: MDTM remote-filename
        /// Returns the last-modified time of the given file on the remote host in the format "YYYYMMDDhhmmss": YYYY is the four-digit year, MM is the month from 01 to 12, DD is the day of the month from 01 to 31, hh is the hour from 00 to 23, mm is the minute from 00 to 59, and ss is the second from 00 to 59.</summary>
        FTP_MDTM,
        /// <summary>Syntax: MKD remote-directory
        /// Creates the named directory on the remote host.</summary>
        FTP_MKD,
        /// <summary>Syntax: MODE mode-character
        /// Sets the transfer mode to one of:
        /// S - Stream
        /// B - Block
        /// C - Compressed
        /// The default mode is Stream.</summary>
        FTP_MODE,
        /// <summary>Syntax: NLST [remote-directory]
        /// Returns a list of filenames in the given directory (defaulting to the current directory), with no other information. Must be preceded by a PORT or PASV command.</summary>
        FTP_NLST,
        /// <summary>Syntax: PASS password
        /// After sending the USER command, send this command to complete the login process. (Note, however, that an ACCT command may have to be used on some systems.)</summary>
        FTP_PASS,
        /// <summary>Syntax: PORT a1,a2,a3,a4,p1,p2
        /// Specifies the host and port to which the server should connect for the next file transfer. This is interpreted as IP address a1.a2.a3.a4, port p1*256+p2.</summary>
        FTP_PORT,
        /// <summary>Syntax: REST position
        /// Sets the point at which a file transfer should start; useful for resuming interrupted transfers. For nonstructured files, this is simply a decimal number. This command must immediately precede a data transfer command (RETR or STOR only); i.e. it must come after any PORT or PASV command.</summary>
        FTP_REST,
        /// <summary>Syntax: RETR remote-filename
        /// Begins transmission of a file from the remote host. Must be preceded by either a PORT command or a PASV command to indicate where the server should send data.</summary>
        FTP_RETR,
        /// <summary>Syntax: RMD remote-directory
        /// Deletes the named directory on the remote host.</summary>
        FTP_RMD,
        /// <summary>Syntax: RNFR from-filename
        /// Used when renaming a file. Use this command to specify the file to be renamed; follow it with an RNTO command to specify the new name for the file.</summary>
        FTP_RNFR,
        /// <summary>Syntax: RNTO to-filename
        /// Used when renaming a file. After sending an RNFR command to specify the file to rename, send this command to specify the new name for the file.</summary>
        FTP_RNTO,
        /// <summary>Syntax: SITE site-specific-command
        /// Executes a site-specific command.</summary>
        FTP_SITE,
        /// <summary>Syntax: SIZE remote-filename
        /// Returns the size of the remote file as a decimal number.</summary>
        FTP_SIZE,
        /// <summary>Syntax: STAT [remote-filespec]
        /// If invoked without parameters, returns general status information about the FTP server process. If a parameter is given, acts like the LIST command, except that data is sent over the control connection (no PORT or PASV command is required).</summary>
        FTP_STAT,
        /// <summary>Syntax: STOR remote-filename
        /// Begins transmission of a file to the remote site. Must be preceded by either a PORT command or a PASV command so the server knows where to accept data from.</summary>
        FTP_STOR,
        /// <summary>Syntax: STOU
        /// Begins transmission of a file to the remote site; the remote filename will be unique in the current directory. The response from the server will include the filename.</summary>
        FTP_STOU,
        /// <summary>Syntax: STRU structure-character
        /// Sets the file structure for transfer to one of:
        /// F - File (no structure)
        /// R - Record structure
        /// P - Page structure
        /// The default structure is File.</summary>
        FTP_STRU,
        /// <summary>Syntax: TYPE type-character [second-type-character]
        /// Sets the type of file to be transferred. type-character can be any of:
        /// A - ASCII text
        /// E - EBCDIC text
        /// I - image (binary data)
        /// L - local format
        /// For A and E, the second-type-character specifies how the text should be interpreted. It can be:
        /// N - Non-print (not destined for printing). This is the default if second-type-character is omitted.
        /// T - Telnet format control (<CR>, <FF>, etc.)
        /// C - ASA Carriage Control
        /// For L, the second-type-character specifies the number of bits per byte on the local system, and may not be omitted.</summary>
        FTP_TYPE,
        /// <summary>Syntax: USER username
        /// Send this command to begin the login process. username should be a valid username on the system, or "anonymous" to initiate an anonymous login.</summary>
        FTP_USER,
        /// <summary>This is the start of an email message. The source email address is what will appear in the "From:" field of the message.</summary>
        SMTP_MAIL_FROM,
        /// <summary>This identifies the receipient of the email message. This command can be repeated multiple times for a given message in order to deliver a single message to multiple receipients.</summary>
        SMTP_RCPT_TO,
        /// <summary>The size command tells the remote sendmail system the size of the attached message in bytes. If ommited, mail readers and delivery agents will try to determine the size of a message based on indicators such as them being terminated by a "." on a line by themselves and headers being sent on a line separated from body text by a blank line. But these methods get confused when you have headers or header like information embedded in messages, attachements, etc.</summary>
        SMTP_SIZE,
        /// <summary>This command will request that the receiving SMTP server verify that a given email username is valid. The SMTP server will reply with the login name of the user. This feature can be turned off in sendmail because allowing it can be a security hole. VRFY commands can be used to probe for login names on a system. See the security section below for information about turning off this feature.</summary>
        SMTP_VRFY,
        /// <summary>EXPN is similar to VRFY, except that when used with a distribution list, it will list all users on that list. This can be a bigger problem than the "VRFY" command since sites often have an alias such as "all".</summary>
        SMTP_EXPN,
        SMTP_SEND_FROM,
        SMTP_SOML_FROM,
        SMTP_SAML_FROM,
        SMTP_HELP,
        SMTP_AUTH
    }
}
