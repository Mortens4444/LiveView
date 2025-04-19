UPDATE VideoSources SET
    AgentId = @AgentId,
    Name = @Name,
    Port = @Port
WHERE Id = @Id;