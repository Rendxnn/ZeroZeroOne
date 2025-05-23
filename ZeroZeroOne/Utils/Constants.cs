﻿namespace ZeroZeroOne.Utils
{
    public class FileConstants
    {
        public const string PostCommitPath = ".git/hooks/post-commit";
        public const string PostCommitPowershellPath = ".git/hooks/post-commit.ps1";
    }

    public class ZeroOneConstants
    {
        public const string EmasTCompanyId = "24b6c5d5-5653-4a98-be3b-48eed320f4cd";
        public const string HoursRegistryViewId = "5f5962bf-fbb5-4543-0ea4-08da32d06ff0";
    }

    public class CommandConstants
    {
        public const string StartProjectCommand = "startproject";
    }

    public class PostCommitConstants
    {
        public const string PostCommitContent = @"#!/bin/bash
powershell.exe -NoProfile -ExecutionPolicy Bypass -File .git/hooks/post-commit.ps1";
    }
}
