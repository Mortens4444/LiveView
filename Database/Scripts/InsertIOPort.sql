INSERT INTO IOPorts (device_id, port_num, name, friendly_name, direction, state, min_trigger_time, max_count, checksum)
VALUES (@DeviceId, @PortNum, @Name, @FriendlyName, @Direction, @State, @MinTriggerTime, @MaxCount, @Checksum);
