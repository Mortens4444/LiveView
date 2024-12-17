SELECT 
    ID as Id,
    device_id as DeviceId,
    port_num as PortNum,
    name as Name,
    friendly_name as FriendlyName,
    direction as Direction,
    state as State,
    min_trigger_time as MinTriggerTime,
    max_count as MaxCount,
    checksum as Checksum
FROM IOPorts;
