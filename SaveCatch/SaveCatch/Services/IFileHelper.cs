﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SaveCatch.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
    }
}
