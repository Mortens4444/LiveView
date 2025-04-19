UPDATE Agents SET
    ServerIp = @ServerIp,
    AgentPort = @AgentPort,
    VncServerPort = @VncServerPort
WHERE Id = @Id;