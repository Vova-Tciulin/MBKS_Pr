﻿namespace MBKS_Pr2.Models;

public class Symbol
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public char S { get; set; }
}