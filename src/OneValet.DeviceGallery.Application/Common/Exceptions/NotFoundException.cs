﻿using System;

namespace OneValet.DeviceGallery.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Record not found.") { }

        public NotFoundException(string message) : base(message) { }

        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.") { }
    }
}
