DELETE FROM TemplateProcesses WHERE TemplateId = @Id;
DELETE FROM Templates WHERE Id = @Id;
