﻿namespace SmartPos.GeneralLibrary
{
public interface IIdentity
{
    int Id { get; }

    string FullName { get; }

    string ConnectionId { get; set; }
}
}
