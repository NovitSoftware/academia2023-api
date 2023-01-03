﻿namespace NovitSoftware.Academia.Persistence.Entities;

public class Role
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public ICollection<User> Users { get; set; }
}
