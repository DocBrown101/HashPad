﻿using System;

namespace HashPad.Models;

internal static class OsVersion
{
	/// <summary>
	/// Whether OS is Windows 11 (10.0.22000) or greater
	/// </summary>
	public static bool Is11OrGreater => IsEqualToOrGreaterThan(ref _is11OrGreater, 10, 0, 22000);
	private static bool? _is11OrGreater;

	/// <summary>
	/// Whether OS is Windows 11 (10.0.22621) or greater
	/// </summary>
	public static bool Is11Build22621OrGreater => IsEqualToOrGreaterThan(ref _is11Build22621OrGreater, 10, 0, 22621);
	private static bool? _is11Build22621OrGreater;

	/// <summary>
	/// Whether OS is Windows 11 (10.0.26100) or greater
	/// </summary>
	public static bool Is11Build26100OrGreater => IsEqualToOrGreaterThan(ref _is11Build26100OrGreater, 10, 0, 26100);
	private static bool? _is11Build26100OrGreater;

	private static bool IsEqualToOrGreaterThan(ref bool? storage, in int major, in int minor = 0, in int build = 0)
	{
		storage ??= (new Version(major, minor, build) <= Environment.OSVersion.Version);
		return storage.Value;
	}
}