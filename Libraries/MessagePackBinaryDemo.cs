﻿using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = MessagePack.KeyAttribute;

namespace LesserKnown.NET;

[MessagePackObject]
public class MessagePackBinaryDemo
{
    // Key attributes take a serialization index (or string name)
    // The values must be unique and versioning has to be considered as well.
    // Keys are described in later sections in more detail.
    [Key(0)]
    public int Age { get; set; }

    [Key(1)]
    public string FirstName { get; set; }

    [Key(2)]
    public string LastName { get; set; }

    // All fields or properties that should not be serialized must be annotated with [IgnoreMember].
    [IgnoreMember]
    public string FullName { get { return FirstName + LastName; } }
}

[MessagePackObject(keyAsPropertyName: true)]
public class MessagePackJsonDemo
{
    public int Age { get; set; }
    public string Name { get; set; }
}
