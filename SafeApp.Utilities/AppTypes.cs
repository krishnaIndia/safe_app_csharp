﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace SafeApp.Utilities {
  [PublicAPI]
  public enum MDataAction {
    Insert,
    Update,
    Delete,
    ManagePermissions
  }

  public struct MDataKeyFfi {
    public IntPtr DataPtr;
    public IntPtr Len;
  }

  public struct FfiResult {
    public int ErrorCode;
    public string Description;
  }

  [PublicAPI]
  public struct AppExchangeInfo {
    public string Id;
    public string Scope;
    public string Name;
    public string Vendor;
  }

  [PublicAPI]
  public struct PermissionSet {
    [MarshalAs(UnmanagedType.U1)] public bool Read;
    [MarshalAs(UnmanagedType.U1)] public bool Insert;
    [MarshalAs(UnmanagedType.U1)] public bool Update;
    [MarshalAs(UnmanagedType.U1)] public bool Delete;
    [MarshalAs(UnmanagedType.U1)] public bool ManagePermissions;
  }

  [PublicAPI]
  public struct ContainerPermissions {
    public string ContainerName;
    public PermissionSet Access;
  }

  [PublicAPI]
  public struct AuthReq {
    public AppExchangeInfo AppExchangeInfo;
    public bool AppContainer;
    public List<ContainerPermissions> Containers;
  }

  [PublicAPI]
  public struct ContainerReq
  {
    public AppExchangeInfo AppExchangeInfo;
    public List<ContainerPermissions> Containers;
  }

  [PublicAPI]
  public struct AuthReqFfi {
    public AppExchangeInfo AppExchangeInfo;
    [MarshalAs(UnmanagedType.U1)] public bool AppContainer;
    public IntPtr ContainersArrayPtr;
    public IntPtr ContainersLen;
    public IntPtr ContainersCap;
  }

  [PublicAPI]
  public struct ShareMData {
    public ulong TypeTag;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] Name;
    public PermissionSet AccessPermission;
  }

  [PublicAPI]
  public struct ShareMDataReqFfi
  {
    public AppExchangeInfo AppExchangeInfo;
    public IntPtr ShareMDataPtr;
    public IntPtr ShareMDataLen;
  }

  [PublicAPI]
  public struct ShareMDataReq
  {
    public AppExchangeInfo AppExchangeInfo;
    public List<ShareMData> ShareMData;
  }


  [PublicAPI]
  public struct ContainerReqFfi
  {
    public AppExchangeInfo AppExchangeInfo;
    public IntPtr ContainersArrayPtr;
    public IntPtr ContainersLen;
    public IntPtr ContainersCap;
  }

  [PublicAPI]
  public struct AppKeys {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] OwnerKeys;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] EncKey;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] SignPk;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] public byte[] SignSk;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] EncPk;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] EncSk;
  }

  [PublicAPI]
  public struct AccessContInfo {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] Id;
    public ulong Tag;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)] public byte[] SymNonce;
  }

  [PublicAPI]
  public struct AuthGrantedFfi {
    public AppKeys AppKeys;
    public AccessContInfo AccessContainer;
    public IntPtr BootStrapConfigPtr;
    public IntPtr BootStrapConfigLen;
    public IntPtr BootStrapConfigCap;
  }

  [PublicAPI]
  public struct AuthGranted {
    public AppKeys AppKeys;
    public AccessContInfo AccessContainer;
    public List<byte> BootStrapConfig;
  }

  [PublicAPI]
  public struct DecodeIpcResult {
    public AuthGranted? AuthGranted;
    public (IntPtr, IntPtr) UnRegAppInfo;
    public uint? ContReqId;
    public uint? ShareMData;
    public bool? Revoked;
  }

  [PublicAPI]
  public struct MDataInfo {
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)] public byte[] Name;
    public ulong TypeTag;
    [MarshalAs(UnmanagedType.U1)] public bool HasEncInfo;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] public byte[] EncKey;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)] public byte[] EncNonce;
    [MarshalAs(UnmanagedType.U1)] public bool HasNewEncInfo;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)] public byte[] NewEncKey;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)] public byte[] NewEncNonce;
  }
}
