namespace Mtf.Enums.Network
{
    public enum NetworkMessage : int
    {
        /// <summary>Control + @ (#0) - ASCII Control code (NULL - No Punch | NUL).</summary>
        ACC_Ctrl_At,
        /// <summary>Control + A (#1) - ASCII Control code (Start of heading | SOH).</summary>
        ACC_Ctrl_A,
        /// <summary>Control + B (#2) - ASCII Control code (Start of text | STX).</summary>
        ACC_Ctrl_B,
        /// <summary>Control + C (#3) - ASCII Control code (End of text | ETX).</summary>
        ACC_Ctrl_C,
        /// <summary>Control + D (#4) - ASCII Control code (End of transmission | EOT).</summary>
        ACC_Ctrl_D,
        /// <summary>Control + E (#5) - ASCII Control code (Enquiry / WRU - Who aRe yoU / Answerback | ENQ).</summary>
        ACC_Ctrl_E,
        /// <summary>Control + F (#6) - ASCII Control code (Acknowledge | ACK).</summary>
        ACC_Ctrl_F,
        /// <summary>Control + G (#7) - ASCII Control code (Bell | BEL).</summary>
        ACC_Ctrl_G,
        /// <summary>Control + H (#8) - ASCII Control code (Backspace | BS).</summary>
        ACC_Ctrl_H,
        /// <summary>Control + I (#9) - ASCII Control code (Horizontal tabulation | HT).</summary>
        ACC_Ctrl_I,
        /// <summary>Control + J (#10) - ASCII Control code (Line feed | LF).</summary>
        ACC_Ctrl_J,
        /// <summary>Control + K (#11) - ASCII Control code (Vertical tabulation | VT).</summary>
        ACC_Ctrl_K,
        /// <summary>Control + L (#12) - ASCII Control code (Form feed | FF).</summary>
        ACC_Ctrl_L,
        /// <summary>Control + M (#13) - ASCII Control code (Carriage return | CR).</summary>
        ACC_Ctrl_M,
        /// <summary>Control + N (#14) - ASCII Control code (Shift out | SO).</summary>
        ACC_Ctrl_N,
        /// <summary>Control + O (#15) - ASCII Control code (Shift in | SI).</summary>
        ACC_Ctrl_O,
        /// <summary>Control + P (#16) - ASCII Control code (Data link escape | DLE).</summary>
        ACC_Ctrl_P,
        /// <summary>Control + Q (#17) - ASCII Control code (Device Control 1 / X-ON | DC1).</summary>
        ACC_Ctrl_Q,
        /// <summary>Control + R (#18) - ASCII Control code (Device Control 2 | DC2).</summary>
        ACC_Ctrl_R,
        /// <summary>Control + S (#19) - ASCII Control code (Device Control 3 / X-OFF | DC3).</summary>
        ACC_Ctrl_S,
        /// <summary>Control + T (#20) - ASCII Control code (Device Control 4 | DC4).</summary>
        ACC_Ctrl_T,
        /// <summary>Control + U (#21) - ASCII Control code (Negative Acknowledge | NAK).</summary>
        ACC_Ctrl_U,
        /// <summary>Control + V (#22) - ASCII Control code (Synchronous idle | SYN).</summary>
        ACC_Ctrl_V,
        /// <summary>Control + W (#23) - ASCII Control code (End of transmission block | ETB).</summary>
        ACC_Ctrl_W,
        /// <summary>Control + X (#24) - ASCII Control code (Cancel | CAN).</summary>
        ACC_Ctrl_X,
        /// <summary>Control + Y (#25) - ASCII Control code (End of medium | EM).</summary>
        ACC_Ctrl_Y,
        /// <summary>Control + Z (#26) - ASCII Control code (Substitude | SUB).</summary>
        ACC_Ctrl_Z,
        /// <summary>Control + [ (#27) - ASCII Control code (Escape | ESC).</summary>
        ACC_Ctrl_LeftSquareBracket,
        /// <summary>Control + \ (#28) - ASCII Control code (File separator | FS).</summary>
        ACC_Ctrl_ReverseSolidus,
        /// <summary>Control + ] (#29) - ASCII Control code (Group separator | GS).</summary>
        ACC_Ctrl_RightSquareBracket,
        /// <summary>Control + ^ (#30) - ASCII Control code (Record separator | RS).</summary>
        ACC_Ctrl_CircumflexAccent,
        /// <summary>Control + _ (#31) - ASCII Control code (Unit separator | US).</summary>
        ACC_Ctrl_LowLine,
        /// <summary>Delete (#127) - ASCII Control code (Delete / RUB OUT | DEL).</summary>
        ACC_Delete,
        /// <summary>Enter (#10#13).</summary>
        Enter,
        /// <summary>ESC (#27).</summary>
        Escape,
        /// <summary>Aborts a file transfer currently in progress.</summary>
        FTP_ABOR,
        /// <summary>Makes the parent of the current directory be the current directory.</summary>
        FTP_CDUP,
        /// <summary>Does nothing except return a response.</summary>
        FTP_NOOP,
        /// <summary>Tells the server to enter "passive mode".
        /// In passive mode, the server will wait for the client to establish a connection with it rather than attempting to connect to a client-specified port.
        /// The server will respond with the address of the port it is listening on, with a message like:
        /// 227 Entering Passive Mode (a1,a2,a3,a4,p1,p2)
        /// where a1.a2.a3.a4 is the IP address and p1*256+p2 is the port number.</summary>
        FTP_PASV,
        /// <summary>Returns the name of the current directory on the remote host.</summary>
        FTP_PWD,
        /// <summary>Returns the name of the current directory on the remote host.</summary>
        FTP_QUIT,
        /// <summary>Reinitializes the command connection - cancels the current user/password/account information. Should be followed by a USER command for another login.</summary>
        FTP_REIN,
        /// <summary>Begins transmission of a file to the remote site; the remote filename will be unique in the current directory. The response from the server will include the filename.</summary>
        FTP_STOU,
        /// <summary>Returns a word identifying the system, the word "Type:", and the default transfer type (as would be set by the TYPE command). For example: UNIX Type: L8.</summary>
        FTP_SYST,
        /// <summary>Key A. (#65)</summary>
        Key_A,
        /// <summary>Key B. (#66)</summary>
        Key_B,
        /// <summary>Key C. (#67)</summary>
        Key_C,
        /// <summary>Key D. (#68)</summary>
        Key_D,
        /// <summary>Space (#32).</summary>
        Space,
        /// <summary>This command initiates the SMTP conversation. The host connecting to the remote SMTP server identifies itself by it's fully qualified DNS host name.</summary>
        SMTP_HELO,
        /// <summary>An alternative command for starting the conversation. This states that the sending server wants to use the extended SMTP (ESMTP) protocol.</summary>
        SMTP_EHLO,
        /// <summary>This command signifies that a stream of data, ie the email message body, will follow. The stream of data is terminated by a "." on a line by itself.</summary>
        SMTP_DATA,
        /// <summary>This terminates an SMTP connection. Multiple email messages can be transfered during a single TCP/IP connection. This allows for more efficient transfer of email. To start another email message in the same session, simply issue another "MAIL" command.</summary>
        SMTP_QUIT,
        /// <summary>RSET</summary>
        SMTP_RSET,
        /// <summary>TURN</summary>
        SMTP_TURN,
        /// <summary>No operation.</summary>
        SMTP_NOOP
    }
}
