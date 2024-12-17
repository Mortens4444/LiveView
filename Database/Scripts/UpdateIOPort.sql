UPDATE IOPorts
SET 
    device_id = @DeviceId,
    port_num = @PortNum,
    name = @Name,
    friendly_name = @FriendlyName,
    direction = @Direction,
    state = @State,
    min_trigger_time = @MinTriggerTime,
    max_count = @MaxCount,
    checksum = @Checksum
WHERE ID = @Id;
